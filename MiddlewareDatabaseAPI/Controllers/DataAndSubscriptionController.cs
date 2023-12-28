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
    public class DataAndSubscriptionController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;

        [Route("{application}/{container}")]
        [HttpGet]
        public IEnumerable<string> GetAllDataOrSubscription()
        {
            // verificar header somiod-discover: data 
            // verificar header somiod-discover: subscription 

            return new string[] { "value1", "value2" };
        }

        [Route("{application}/{container}/data/{data}")]
        [HttpGet]
        public string GetData(string name)
        {
            return "value";
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