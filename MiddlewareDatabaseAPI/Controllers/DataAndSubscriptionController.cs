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
    public class DataAndSubscriptionController : SomiodController
    {

        [Route("{application}/{container}/data/{data}")]
        [HttpGet]
        public IHttpActionResult GetData(string application, string container, string data)
        {
            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to App");

            if (VerifyDataOrSubContainer(container, data, false))
                return BadRequest("Data doesn't belong to Container");

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

            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to App");

            if (VerifyDataOrSubContainer(container, subscription, false))
                return BadRequest("Subscription doesn't belong to Container");

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

        public int PostData(Data value)
        {
            if (value == null)
                return 0;

            if (value.name == null)
                return 0;

            if (value.content == null)
                return 0;

            if (value.parent == null)
                return 0;

            //bool flag = false;
            string nameValue;
            if (!UniqueName(value.name, "Data"))
            {
                //flag = true;
                nameValue = NewName(value.name, "Data");
            }
            else
                nameValue = value.name;

            string queryString = "INSERT INTO Data (name, content, parent, creation_dt) VALUES (@name, @content, @parent, @creation_dt)";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", nameValue);
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
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public int PostSubscription(Subscription value)
        {
            if (value == null)
                return 0;

            if (value.name == null)
                return 0;

            if (value.event_mqqt == null)
                return 0;

            if (value.endpoint == null)
                return 0;

            if (value.parent == null)
                return 0;

            //bool flag = false;
            string nameValue;
            if (!UniqueName(value.name, "Subscription"))
            {
                //flag = true;
                nameValue = NewName(value.name, "Subscription");
            }
            else
                nameValue = value.name;

            string queryString = "INSERT INTO Subscription (name, event, endpoint, parent, creation_dt) VALUES (@name, @event, @endpoint, @parent, @creation_dt)";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", nameValue);
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
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        [Route("{application}/{container}/teste/{data}")]
        [HttpDelete]
        public IHttpActionResult DeleteData(string application, string container, string data)
        {

            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to App");

            if (VerifyDataOrSubContainer(container, data, false))
                return BadRequest("Data doesn't belong to Container");

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
                            return Ok("Data " + data + " deleted");
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    catch (Exception)
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

            int[] values = VerifyOwnership(application, container);
            if (values[0] != values[1])
                return BadRequest("Container doesn't belong to App");

            if (VerifyDataOrSubContainer(container, subscription, false))
                return BadRequest("Subscription doesn't belong to Container");

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
                            return Ok("Subscription " + subscription + " deleted");
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    catch (Exception)
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

        private bool VerifyDataOrSubContainer(string container, string data, bool flag)
        {
            int idCont = 0, idDataOrSubParent = 0;
            string queryCont = "SELECT id FROM Container WHERE name = @nameContainer";
            string queryDataOrSubparent = flag ? "SELECT parent FROM Data WHERE name = @name" : "SELECT parent FROM Subscription WHERE name = @name";

            using (SqlConnection connection = new SqlConnection(connStr))
            {

                SqlCommand commandCont = new SqlCommand(queryCont, connection);
                commandCont.Parameters.AddWithValue("@nameContainer", container);
                commandCont.Connection.Open();

                try
                {
                    using (SqlDataReader reader = commandCont.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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

            if (idDataOrSubParent == idCont)
            {
                return false;
            }

            return true;
        }

    }
}