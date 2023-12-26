using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddlewareDatabaseAPI.Models
{
    public class Library
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime creation_dt { get; set; }
    }
}