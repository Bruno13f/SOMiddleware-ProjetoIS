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
                        Data p = new Data
                        {
                            id = (int)reader["id"],
                            name = (string)reader["name"],
                            creation_dt = (DateTime)reader["creation_dt"],
                            parent = (int)reader["parent"]
                        };
                        return Ok(p);
                    }
                }
            }
            return NotFound();
        }

    [Route("{application}/{container}/subscription/{subscription}")]
        [HttpGet]
        public string GetSubscription(string name)
        {
            return "value";
        }

        [Route("{application}/{container}/data")]
        [HttpPost]
        public void PostData([FromBody] string value)
        {
        }

        [Route("{application}/{container}/subscription")]
        [HttpPost]
        public void PostSubscription([FromBody] string value)
        {
        }

        [Route("{application}/{container}/data/{data}")]
        [HttpPut]
        public void PutData(string name, [FromBody] string value)
        {
        }

        [Route("{application}/{container}/subscription/{subscription}")]
        [HttpPut]
        public void PutSubscription(string name, [FromBody] string value)
        {
        }

        [Route("{application}/{container}/data/{data}")]
        [HttpDelete]
        public void DeleteData(string name)
        {
        }

        [Route("{application}/{container}/subscription/{subscription}")]
        [HttpDelete]
        public void DeleteSubscription(string name)
        {
        }
    }
}