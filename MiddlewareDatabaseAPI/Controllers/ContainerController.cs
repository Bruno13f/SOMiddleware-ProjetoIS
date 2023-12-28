using System;
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
    public class ContainerController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;

        [Route("{application}")]
        [HttpGet]
        public IEnumerable<string> GetAllContainers()
        {
            // verificar header somiod-discover: container
            return new string[] { "value1", "value2" };
        }

        [Route("{application}/{container}")]
        [HttpGet]
        public string GetContainerOfApplication(string name)
        {
            return "value";
        }

        [Route("{application}")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [Route("{application}/{container}")]
        [HttpPut]
        public void Put(string name, [FromBody] string value)
        {
        }

        [Route("{application}/{container}")]
        [HttpDelete]
        public void Delete(string name)
        {
        }
    }
}