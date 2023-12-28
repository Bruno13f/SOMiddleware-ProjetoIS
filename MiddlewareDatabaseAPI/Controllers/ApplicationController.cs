using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Security.AccessControl;
using MiddlewareDatabaseAPI.Models;
using System.Diagnostics;

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
            // Verify header somiod-discover: application 
            HttpRequestMessage request = Request;
            if (request.Headers.TryGetValues("somiod-discover", out IEnumerable<string> headerValues))
            {
                string somiodDiscoverHeaderValue = headerValues.FirstOrDefault();

                if (string.Equals(somiodDiscoverHeaderValue, "application", StringComparison.OrdinalIgnoreCase))
                {
                    // Header is present and has the correct value
                    List<string> listOfApplications = new List<string>();
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
                                    string name = (string)reader["name"];
                                    listOfApplications.Add(name);
                                }
                            }
                        }
                        return Ok(listOfApplications);
                    }
                    catch (Exception)
                    {
                        // Handle exceptions appropriately
                        return InternalServerError();
                    }
                }
                else
                {
                    // Header is present but has an incorrect value
                    return BadRequest("Invalid value for somiod-discover header");
                }
            }
            else
            {
                // Header is not present
                return BadRequest("somiod-discover header is missing");
            }
        }

        [Route("{application}")]
        [HttpGet]
        public IHttpActionResult GetApplicationOrContainers(string application)
        {
            // Verify header somiod-discover: container
            HttpRequestMessage request = Request;
            if (request.Headers.TryGetValues("somiod-discover", out IEnumerable<string> headerValues))
            {
                string somiodDiscoverHeaderValue = headerValues.FirstOrDefault();

                if (string.Equals(somiodDiscoverHeaderValue, "container", StringComparison.OrdinalIgnoreCase))
                {
                    // Header is present and has the correct value
                    int id_app = 0;
                    string firstQueryString = "SELECT * FROM Application WHERE name = @nameApplication";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connStr))
                        {
                            SqlCommand command = new SqlCommand(firstQueryString, connection);
                            command.Parameters.AddWithValue("@nameApplication", application);
                            command.Connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    id_app = (int)reader["id"];
                                }
                            }
                        }
                        if (id_app == 0)
                        {
                            // return NotFound();
                            return BadRequest("não encontrado");
                        }
          
                    }
                    catch (Exception)
                    {
                        // Handle exceptions appropriately
                        return InternalServerError();
                    }

                    List<string> listOfContainers= new List<string>();
                    string queryString = "SELECT * FROM Container WHERE parent = @parentContainer";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connStr))
                        {
                            SqlCommand command = new SqlCommand(queryString, connection);
                            command.Parameters.AddWithValue("@parentContainer", id_app);
                            command.Connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string name = (string)reader["name"];
                                    listOfContainers.Add(name);
                                }
                            }
                        }
                        return Ok(listOfContainers);
                    }
                    catch (Exception)
                    {
                        // Handle exceptions appropriately
                        return InternalServerError();
                    }
                }
                else
                {
                    // Header is present but has an incorrect value
                    return BadRequest("Invalid value for somiod-discover header");
                }
            }
            else
            {
                // Header is not present
                string queryString = "SELECT * FROM Application WHERE name = @nameApllication";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("nameApllication", application);
                        command.Connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                                if (reader.Read())
                                {
                                    //convert the registo da BD para Application
                                    Application app = new Application
                                    {
                                        id = (int)reader["id"],
                                        name = (string)reader["name"],
                                        creation_dt = (DateTime)reader["creation_dt"]
                                    };
                                    return Ok(app);
                                }
                            }
                        }

                    return NotFound();
                }
                catch (Exception)
                {
                    // Handle exceptions appropriately
                    return InternalServerError();
                }
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostApplication([FromBody] Application value)
        {
            // TODO - criar container automaticamente ?? 
            // creation_dt inserido automaticamente, apenas necessário nome da app

            String queryString = "INSERT INTO Application VALUES (@name, @creation_dt)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {

                    SqlCommand command = new SqlCommand(queryString, connection);
                    DateTime now = DateTime.UtcNow;
                    string isoDateTimeString = now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    command.Parameters.AddWithValue("@name", value.name);
                    command.Parameters.AddWithValue("@creation_dt", isoDateTimeString);

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

                    }catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }

            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{application}")]
        [HttpPut]
        public IHttpActionResult PutApplication(string application, [FromBody] Application value)
        {
            int id = 0;
            String queryString = "UPDATE Application SET name=@name WHERE id=@idApp";
            String queryApp = "SELECT * FROM Application WHERE name = @nameApplication";

            try
            {

                using (SqlConnection connection = new SqlConnection(connStr))
                {

                    SqlCommand commandApp = new SqlCommand(queryApp, connection);
                    commandApp.Parameters.AddWithValue("@nameApplication", application);
                    commandApp.Connection.Open();

                    using (SqlDataReader reader = commandApp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = (int)reader["id"];
                        }
                    }

                    commandApp.Connection.Close();

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@idApp", id);
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
                        return InternalServerError(ex);
                    }
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{application}")]
        [HttpDelete]
        public void DeleteApplication(string application)
        {
        }
    }
}