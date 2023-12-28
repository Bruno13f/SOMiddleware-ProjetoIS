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
        public string Get(string name)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [Route("{application}")]
        [HttpPut]
        public void Put(string name, [FromBody] string value)
        {
        }

        [Route("{application}")]
        [HttpDelete]
        public void Delete(string name)
        {
        }
    }
}