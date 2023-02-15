using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bekle.Models
{
    public class Attackaccount : Controller
    {
        // GET: Attacksdb
      

            public String user_id { get; set; }

            public String test_id { get; set; }

            public String test_device { get; set; }
            public String test_desc { get; set; }
            public String test_location { get; set; }
            public String test_results { get; set; }



        }
    }
    
