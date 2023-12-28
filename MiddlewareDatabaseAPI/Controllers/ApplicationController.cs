using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Security.AccessControl;
using MiddlewareDatabaseAPI.Models;

namespace MiddlewareDatabaseAPI.Controllers
{
    [RoutePrefix("api/somiod")]
    public class ApplicationController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;


        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllApplications()
        {
            // verificar header somiod-discover: application 

            List<String> ListOfApplications = new List<string>();
            string queryString = "SELECT * FROM Application";

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String name = (string)reader["name"];
                            ListOfApplications.Add(name);
                        }
                    }
                }
                return Ok(ListOfApplications);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Route("{application}")]
        [HttpGet]
        public IEnumerable<string> GetApplicationOrContainers(string application)
        {
            // verificar header somiod-discover: container

            IEnumerable<string> headers = Request.Headers.Select(header => $"{header.Key}: {string.Join(", ", header.Value)}");

            return headers;
        }

        [Route("")]
        [HttpPost]
        public void PostApplication([FromBody] string value)
        {
        }

        [Route("{application}")]
        [HttpPut]
        public void PutApplication(string name, [FromBody] string application)
        {
        }

        [Route("{application}")]
        [HttpDelete]
        public void DeleteApplication(string application)
        {
        }
    }
}