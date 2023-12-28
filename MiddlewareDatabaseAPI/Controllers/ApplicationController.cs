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

            List<Application> ListOfApplications = new List<Application>();
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
                            //covert the registo da BD para product
                            Application p = new Application
                            {
                                //id = (int)reader["id"],
                                name = (string)reader["name"],
                                //creation_dt = (DateTime)reader["creation_dt"]
                            };
                            ListOfApplications.Add(p);
                        }
                    }
                }
                return null;
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