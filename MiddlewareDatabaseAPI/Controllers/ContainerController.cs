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

        [Route("{application}/{container}")]
        [HttpGet]
        public string GetContainerOrAllDataOrAllSubscriptions(string application, string container)
        {
            // verificar header somiod-discover: data 
            // verificar header somiod-discover: subscription 

            return "value";
        }

        /*
        [Route("{application}")]
        [HttpPost]
        public void PostContainer([FromBody] string application)
        {
        }
        */

        [Route("{application}/{container}")]
        [HttpPut]
        public void PutContainer(string application, string container, [FromBody] string value)
        {
        }

        [Route("{application}/{container}")]
        [HttpDelete]
        public void DeleteContainer(string application, string container)
        {
        }
    }
}