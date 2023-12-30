using System;
using MiddlewareDatabaseAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Security.AccessControl;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace MiddlewareDatabaseAPI.Controllers
{
    [RoutePrefix("api/somiod")]
    public class DataAndSubscriptionController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;

        [Route("{application}/{container}/data/{data}")]
        [HttpGet]
        public IHttpActionResult GetData(string application, string container, string data)
        {
            if (verifyDataContApp(application, container, data, true))
                return NotFound();

            string queryString = "SELECT * FROM Data WHERE name = @data";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@data", data);

                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Data d = new Data
                        {
                            id = (int)reader["id"],
                            name = (string)reader["name"],
                            content = (string)reader["content"],
                            creation_dt = (DateTime)reader["creation_dt"],
                            parent = (int)reader["parent"]
                        };
                        return Ok(d);
                    }
                }
            }
            return NotFound();
        }

        [Route("{application}/{container}/subscription/{subscription}")]
        [HttpGet]
        public IHttpActionResult GetSubscription(string application, string container, string subscription)
        {
            if (verifyDataContApp(application, container, subscription, false))
                return NotFound();

            string queryString = "SELECT * FROM Subscription WHERE name = @subscription";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@subscription", subscription);

                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Subscription s = new Subscription
                        {
                            id = (int)reader["id"],
                            name = (string)reader["name"],
                            event_mqqt = (string)reader["event"],
                            endpoint = (string)reader["endpoint"],
                            creation_dt = (DateTime)reader["creation_dt"],
                            parent = (int)reader["parent"]
                        };
                        return Ok(s);
                    }
                }
            }
            return NotFound();
        }

        [Route("{application}/{container}/data")]
        [HttpPost]
        public IHttpActionResult PostData(string application, string container, [FromBody] Data value)
        {
            ContainerController containerController = new ContainerController();
            int[] values = containerController.verifyOwnership(application, container);
            if (values[0] != values[1])
                return NotFound();

            string queryString = "INSERT INTO Data (name, content, parent, creation_dt) VALUES (@name, @content, @parent, @creation_dt)";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", value.name);
                command.Parameters.AddWithValue("@content", value.content);
                command.Parameters.AddWithValue("@parent", value.parent);
                DateTime now = DateTime.UtcNow;
                string isoDateTimeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                command.Parameters.AddWithValue("@creation_dt", isoDateTimeString);

                try
                {
                    command.Connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
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
                    return InternalServerError(ex);
                }
            }
        }

        [Route("{application}/{container}/subscription")]
        [HttpPost]
        public IHttpActionResult PostSubscription(string application, string container, [FromBody] Subscription value)
        {
            ContainerController containerController = new ContainerController();
            int[] values = containerController.verifyOwnership(application, container);
            if (values[0] != values[1])
                return NotFound();

            string queryString = "INSERT INTO Subscription (name, event, endpoint, parent, creation_dt) VALUES (@name, @event, @endpoint, @parent, @creation_dt)";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", value.name);
                command.Parameters.AddWithValue("@event", value.event_mqqt);
                command.Parameters.AddWithValue("@endpoint", value.endpoint);
                command.Parameters.AddWithValue("@parent", value.parent);
                DateTime now = DateTime.UtcNow;
                string isoDateTimeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                command.Parameters.AddWithValue("@creation_dt", isoDateTimeString);

                try
                {
                    command.Connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
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
                    return InternalServerError(ex);
                }
            }
        }

        [Route("{application}/{container}/teste/{data}")]
        [HttpDelete]
        public IHttpActionResult DeleteData(string application, string container, string data)
        {
            if (verifyDataContApp(application, container, data, true))
                return NotFound();

            try
            {
                string queryString = "DELETE Data WHERE name=@name";

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@name", data);

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

        [Route("{application}/{container}/subscription/{subscription}")]
        [HttpDelete]
        public IHttpActionResult DeleteSubscription(string application, string container, string subscription)
        {
            if (verifyDataContApp(application, container, subscription, false))
                return NotFound();

            try
            {
                string queryString = "DELETE Subscription WHERE name=@name";

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@name", subscription);

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

        private bool verifyDataContApp(string application, string container, string data, bool flag)
        {
            int idApp = 0, idCont = 0, idContParent = 0, idDataOrSubParent = 0;
            string queryAppid = "SELECT id FROM Application WHERE name = @nameApplication";
            string queryCont = "SELECT id, parent FROM Container WHERE name = @nameContainer";
            string queryDataOrSubparent = flag ? "SELECT parent FROM Data WHERE name = @name" : "SELECT parent FROM Subscription WHERE name = @name";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand commandApp = new SqlCommand(queryAppid, connection);
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

                commandApp.Connection.Close();

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

                SqlCommand commandDataP = new SqlCommand(queryDataOrSubparent, connection);
                commandDataP.Parameters.AddWithValue("@name", data);
                commandDataP.Connection.Open();

                try
                {
                    using (SqlDataReader reader = commandDataP.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idDataOrSubParent = (int)reader["parent"];
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }

            }

            if (idApp == idContParent)
            {
                if (idDataOrSubParent == idCont)
                {
                    return false;
                }
                return true;

            }

            return true;
        }

    }
}