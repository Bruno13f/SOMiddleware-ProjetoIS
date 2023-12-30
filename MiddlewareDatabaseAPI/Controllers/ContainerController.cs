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

            int[] values = verifyOwnership(application, container);
            if (values[0] != values[1])
                return NotFound();

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
                        return InternalServerError();
                    }
                }

            }
            catch (Exception)
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