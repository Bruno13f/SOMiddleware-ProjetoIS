using System;
using MiddlewareDatabaseAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace MiddlewareDatabaseAPI.Controllers
{
    [RoutePrefix("api/somiod")]
    public class DataAndSubscriptionController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;

        [Route("{application}/{container}/data/{data}")]
        [HttpGet]
        public IHttpActionResult GetData(string data)
        {
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
        public void GetSubscription(string subscription)
        {
        }

        [Route("{application}/{container}/data")]
        [HttpPost]
        public IHttpActionResult PostData([FromBody] Data value)
        {
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
                catch (Exception)
                {
                    return InternalServerError();
                }
            }
        }

        [Route("{application}/{container}/subscription")]
        [HttpPost]
        public void PostSubscription([FromBody] string value)
        {
        }

        [Route("{application}/{container}/subscription/{subscription}")]
        [HttpPut]
        public void PutSubscription(string name, [FromBody] string value)
        {
        }

        [Route("{application}/{container}/data/{data}")]
        [HttpDelete]
        public IHttpActionResult DeleteData(string data)
        {
            string deleteQueryString = "DELETE FROM Data WHERE name = @data";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(deleteQueryString, connection);
                command.Parameters.AddWithValue("@data", data);

                try
                {
                    connection.Open();
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
                catch (Exception)
                {
                    return InternalServerError();
                }
            }
        }

        [Route("{application}/{container}/subscription/{subscription}")]
        [HttpDelete]
        public void DeleteSubscription(string name)
        {
        }
    }
}