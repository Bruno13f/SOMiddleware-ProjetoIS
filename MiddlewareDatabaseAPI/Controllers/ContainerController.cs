using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Security.AccessControl;
using MiddlewareDatabaseAPI.Models;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace MiddlewareDatabaseAPI.Controllers
{
    [RoutePrefix("api/somiod")]
    public class ContainerController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;

        [Route("{application}/{container}")]
        [HttpGet]
        public IHttpActionResult GetContainerOrAllDataOrAllSubscriptions(string application, string container)
        {

            int[] values = verifyOwnership(application, container);
            if (values[0] != values[1])
                return NotFound();


            HttpRequestMessage request = Request;
            //Verificação se no cabeçalho do Header existe a opção somiod-discover
            if (request.Headers.TryGetValues("somiod-discover", out IEnumerable<string> headerValues))
            {

                string somiodDiscoverHeaderValue = headerValues.FirstOrDefault();

                //Verificação se no cabeçalho do Header a opção somiod-discover têm o valor data
                if (string.Equals(somiodDiscoverHeaderValue, "data", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        List<string> listOfDatas = new List<string>();
                        string queryString = "SELECT name FROM Data WHERE parent=(SELECT id FROM Container WHERE name=@nameContainer AND parent=(SELECT id FROM Application WHERE name=@nameApplication))";

                        using (SqlConnection connection = new SqlConnection(connStr))
                        {
                            SqlCommand command = new SqlCommand(queryString, connection);
                            connection.Open();
                            command.Parameters.AddWithValue("@nameContainer", container);
                            command.Parameters.AddWithValue("@nameApplication", application);


                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    listOfDatas.Add((string)reader["name"]);
                                }
                            }
                        }

                        return Ok(listOfDatas);

                    }
                    catch (Exception)
                    {
                        return InternalServerError();
                    }
                }    //Verificação se no cabeçalho do Header a opção somiod-discover têm o valor subscription
                else if (string.Equals(somiodDiscoverHeaderValue, "subscription", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        List<string> listOfSubscriptions = new List<string>();
                        string queryString = "SELECT name FROM Subscription WHERE parent=(SELECT id FROM Container WHERE name=@nameContainer AND parent=(SELECT id FROM Application WHERE name=@nameApplication))";

                        using (SqlConnection connection = new SqlConnection(connStr))
                        {
                            SqlCommand command = new SqlCommand(queryString, connection);
                            connection.Open();
                            command.Parameters.AddWithValue("@nameContainer", container);
                            command.Parameters.AddWithValue("@nameApplication", application);


                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    listOfSubscriptions.Add((string)reader["name"]);
                                }
                            }
                        }

                        return Ok(listOfSubscriptions);

                    }
                    catch (Exception)
                    {
                       return InternalServerError();
                    }
                }
                else
                {
                    return BadRequest("Invalid value for somiod-discover header");
                }
            }
            else
            {
                try
                {
                    string queryString = "SELECT * FROM Container WHERE name = @nameContainer AND parent=(SELECT id FROM Application WHERE name=@nameApplication)";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("@nameContainer", container);
                        command.Parameters.AddWithValue("@nameApplication", application);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Container cont = new Container
                                {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    creation_dt = (DateTime)reader["creation_dt"],
                                    parent = (int)reader["parent"]
                                };
                                return Ok(cont);
                            }
                        }
                    }
                    return NotFound();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }

        
        /*[Route("{application}")]
        [HttpPost]
        public void PostContainer([FromBody] string value)
        {
        }*/
        

        [Route("{application}/{container}")]
        [HttpPut]
        public IHttpActionResult PutContainer(string application, string container, [FromBody] Container value)
        {
            int[] values = verifyOwnership(application, container);
            if (values[0] != values[1])
                return NotFound();

            string queryString = "UPDATE Container SET name=@name WHERE id=@idCont";

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@idCont", values[2]);
                    command.Parameters.AddWithValue("@name", value.name);

                    try
                    {
                        command.Connection.Open();
                        if (command.ExecuteNonQuery() == 0)
                        {
                            return NotFound();
                        }
                        else
                        {
                            return Ok();
                        }

                    }
                    catch (Exception ex) 
                    {
                        return InternalServerError();
                    }
                
                }

            }catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("{application}/{container}")]
        [HttpDelete]
        public IHttpActionResult DeleteContainer(string application, string container)
        {
            // falta eliminar data e subscriptions se existirem

            //Verificação se a aplicação e o container estão relacionados 
            int[] values = verifyOwnership(application, container);
            if (values[0] != values[1])
                return NotFound();

            //No Array de Bool (verificacao) as posicoes correspondem a:
            //0 --> Data
            //1 --> Subscription

            bool[] verificacao = verificacaoDataESubscriptionTemDados(container);


            bool flagDataEleminadaOuNaoExiste = true;
            bool flagSubscriptionEleminadaOuNaoExiste = true;

            //Verificar se existe Data no Container. Se exister elemina e enviar para a variavel se a operação correu bem
            if (verificacao[0])
            {
                flagDataEleminadaOuNaoExiste = deleteDataOrSubscription(container, "Data");
            }

            //Verificar se existe Subscription no Container. Se exister elemina e enviar para a variavel se a operação correu bem
            if (verificacao[1])
            {
                flagSubscriptionEleminadaOuNaoExiste = deleteDataOrSubscription(container, "Subscription");
            }


            if (flagDataEleminadaOuNaoExiste && flagSubscriptionEleminadaOuNaoExiste)
            {
                //Inicio da Eleminação do Container
                try
                {
                    string queryString = "DELETE Container WHERE name=@name";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@name", container);

                        try
                        {
                            command.Connection.Open();
                            int rows = command.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                return Ok();
                            }
                            else
                            {
                                return NotFound();
                            }
                        }
                        catch (Exception ex)
                        {
                            return InternalServerError(ex);
                        }
                    }

                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            else
            {
                return InternalServerError();
            }

        }

        public int[] verifyOwnership (string application, string container)
        {
            int idApp = 0, idContParent = 0, idCont = 0;
            string queryApp = "SELECT id FROM Application WHERE name = @nameApplication";
            string queryCont = "SELECT id, parent FROM Container WHERE name = @nameContainer";

            using (SqlConnection connection = new SqlConnection(connStr)) { 

                SqlCommand commandCont = new SqlCommand(queryCont, connection);
                commandCont.Parameters.AddWithValue("@nameContainer", container);
                commandCont.Connection.Open();

                try
                {
                    using (SqlDataReader reader = commandCont.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idContParent = (int)reader["parent"];
                            idCont = (int)reader["id"];
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }


                commandCont.Connection.Close();

                SqlCommand commandApp = new SqlCommand(queryApp, connection);
                commandApp.Parameters.AddWithValue("@nameApplication", application);
                commandApp.Connection.Open();

                try
                {
                    using (SqlDataReader reader = commandApp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idApp = (int)reader["id"];
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }

            }

            return new int[] { idApp, idContParent, idCont };
        }

        

        public bool[] verificacaoDataESubscriptionTemDados(string container)
        {
            //Estrutura para guardar a informação se o container tem na sua composição Data e Subscription
            bool[] verificacao = new bool[2];
            verificacao[0] = false;
            verificacao[1] = false;

            //Querys Para ir buscar os dados
            string queryGetDatas = "SELECT id FROM Data WHERE parent=(SELECT id FROM Container WHERE name=@nameContainer)";
            string queryGetSubscriptios = "SELECT id FROM Subscription WHERE parent=(SELECT id FROM Container WHERE name=@nameContainer)";


            using (SqlConnection connection = new SqlConnection(connStr))
            {
                //Pesquisa na Base de dados por Data's
                SqlCommand commandGetDatas = new SqlCommand(queryGetDatas, connection);
                commandGetDatas.Parameters.AddWithValue("@nameContainer", container);
                try
                {
                    commandGetDatas.Connection.Open();
                    using (SqlDataReader reader = commandGetDatas.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            verificacao[0] = true;
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }

                commandGetDatas.Connection.Close();

                //Pesquisa na Base de dados por Subscription's
                SqlCommand commandGetSubscriptions = new SqlCommand(queryGetSubscriptios, connection);
                commandGetSubscriptions.Parameters.AddWithValue("@nameContainer", container);
                try
                {
                    commandGetSubscriptions.Connection.Open();
                    using (SqlDataReader reader = commandGetSubscriptions.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            verificacao[1] = true;
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }

                commandGetDatas.Connection.Close();

            }

            return verificacao;

        } 

        

        public bool deleteDataOrSubscription(string container, string whatIs)
        {
            string queryDeleteData = "DELETE FROM " + whatIs + " WHERE parent=(SELECT id FROM Container WHERE name=@nameContainer)";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand commandDelete = new SqlCommand(queryDeleteData, connection);
                commandDelete.Parameters.AddWithValue("@nameContainer", container);

                try
                {
                    commandDelete.Connection.Open();
                    int rows = commandDelete.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    InternalServerError(ex);
                    return false;
                }
            }
        }


        //===================================================PERGUNTAR À STORA===================================================

        /*[Route("{application}/{container}")]
        [HttpPost]
        public IHttpActionResult PostDataOrSubscription([FromBody] RequestDataOrSubscription value)
        {
            // Assuming DataAndSubscriptionController has a parameterless constructor
            DataAndSubscriptionController controller = new DataAndSubscriptionController();

            if (value.res_type == "data")
            {
                return controller.PostData(new Data { name = value.name, content = value.content, parent = value.parent });
            }

            if (value.res_type == "subscription")
            {
                return controller.PostSubscription((Subscription)value);
            }

            return BadRequest("Invalid res_type");
        }

        public class RequestDataOrSubscription
        {
            public string res_type { get; set; }
            public string name {  get; set; }
            public int parent { get; set; }
            public string content { get; set; }
            public string event_mqtt { get; set; }
            public string endpoint { get; set; }
        }*/
    }
}