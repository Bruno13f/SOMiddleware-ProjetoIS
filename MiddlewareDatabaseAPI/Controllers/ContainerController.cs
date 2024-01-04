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
    public class ContainerController : SomiodController
    {

        [Route("{application}/{container}")]
        [HttpGet]
        public IHttpActionResult GetContainerOrAllDataOrAllSubscriptions(string application, string container)
        {

            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to app");


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
            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to app");

            if (value == null)
                return BadRequest("The request body is empty.");

            if (value.name == null)
                return BadRequest("The 'name' parameter is null.");

            bool flag = false;
            string nameValue;
            if (!UniqueName(value.name))
            {
                flag = true;
                nameValue = NewName(value.name);
            }
            else
                nameValue = value.name;

            string queryString = "UPDATE Container SET name=@name WHERE id=@idCont";

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@idCont", values[2]);
                    command.Parameters.AddWithValue("@name", nameValue);

                    try
                    {
                        command.Connection.Open();
                        if (command.ExecuteNonQuery() == 0)
                        {
                            return NotFound();
                        }
                        else
                        {                          
                            return flag ? Ok("Container " + nameValue + " was edited - specified name in use") : Ok("Container " + nameValue + " was edited");
                        }

                    }
                    catch (Exception) 
                    {
                        return InternalServerError();
                    }
                
                }

            }catch(Exception)
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
            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to app");

            //No Array de Bool (verificacao) as posicoes correspondem a:
            //0 --> Data
            //1 --> Subscription

            /*bool[] verificacao = VerificacaoDataESubscriptionTemDados(container);


            bool flagDataEleminadaOuNaoExiste = true;
            bool flagSubscriptionEleminadaOuNaoExiste = true;

            //Verificar se existe Data no Container. Se exister elemina e enviar para a variavel se a operação correu bem
            if (verificacao[0])
            {
                flagDataEleminadaOuNaoExiste = 
            }

            //Verificar se existe Subscription no Container. Se exister elemina e enviar para a variavel se a operação correu bem
            if (verificacao[1])
            {
                flagSubscriptionEleminadaOuNaoExiste = 
            }*/

            DeleteDataOrSubscription(container, "Data");
            DeleteDataOrSubscription(container, "Subscription");

            try
            {
                

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                        string queryString = "DELETE FROM Container WHERE name=@name";
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@name", container);

                        try
                        {
                            command.Connection.Open();
                            int rows = command.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                return Ok("Container " + container + " deleted");
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

        /*public bool[] VerificacaoDataESubscriptionTemDados(string container)
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

        } */

        public void DeleteDataOrSubscription(string container, string table)
        {
            string queryDeleteData = "DELETE FROM " + table + " WHERE parent=(SELECT id FROM Container WHERE name=@nameContainer)";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand commandDelete = new SqlCommand(queryDeleteData, connection);
                commandDelete.Parameters.AddWithValue("@nameContainer", container);

                try
                {
                    commandDelete.Connection.Open();
                    commandDelete.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    InternalServerError(ex);
                }
            }
        }


        //===================================================PERGUNTAR À STORA===================================================

        [Route("{application}/{container}")]
        [HttpPost]
        public IHttpActionResult PostDataOrSubscription(string application, string container, [FromBody] RequestDataOrSubscription value)
        {

            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to App");

            value.parent = values[2];

            if (value == null)
                return BadRequest("The request body is empty.");

            if (value.name == null)
                return BadRequest("The 'name' parameter is empty.");

            if (value.res_type == null)
                return BadRequest("The 'res_type' parameter is null. Must be either 'data' or 'subscription'");

            // Assuming DataAndSubscriptionController has a parameterless constructor
            DataAndSubscriptionController controller = new DataAndSubscriptionController();
            int result;
            bool flag = true;

            if (value.res_type == "data")
            {
                if (value.content == null)
                    return BadRequest("Error - Trying to create Data with empty content");

                result = controller.PostData(new Data { name = value.name, content = value.content, parent = value.parent });
                flag = false;

            }else if (value.res_type == "subscription")
            {
                if (value.event_mqtt == null)
                    return BadRequest("Error - Trying to create Subscription with empty event");

                if (value.event_mqtt != "1" || value.event_mqtt != "2")
                    return BadRequest("Error - Trying to create Subscription with wrong value for event (1,2)");

                if (value.endpoint == null)
                    return BadRequest("Error - Trying to create Subscription with empty endpoint");

                //return Ok(new Subscription { name = value.name, event_mqqt = value.event_mqtt, endpoint = value.endpoint, parent = value.parent });

                result = controller.PostSubscription(new Subscription { name = value.name, event_mqqt = value.event_mqtt, endpoint = value.endpoint, parent = value.parent });
            }
            else
            {
                return BadRequest("Invalid res_type");
            }

            switch (result)
            {
                case -1:
                    return InternalServerError();
                case 0:
                    return NotFound();
                default:
                    return flag ? Ok("Subscription " + value.name + " created") : Ok("Data " + value.name + " created");
            }
        }

        public class RequestDataOrSubscription
        {
            public string res_type { get; set; }
            public string name {  get; set; }
            public int parent { get; set; }
            public string content { get; set; }
            public string event_mqtt { get; set; }
            public string endpoint { get; set; }
        }
    }
}