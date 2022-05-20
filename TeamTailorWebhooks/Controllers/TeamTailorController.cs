using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TeamTailorWebhooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamTailorWebhooks
{
    //[Route("api/[controller]")]
   [Route("webhook")]
    [ApiController]
    public class TeamTailorController : ControllerBase
    {
        // GET: api/<TeamTailorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      
        // POST api/<TeamTailorController>
        [HttpPost]
        //[FromBody] JsonElement value
        public string Post()
        {
            using (var wb = new WebClient())
            {
                wb.UploadString("https://webhook.site/a2a4e6f6-cb31-4e33-b189-f977976c3a40", "Hello world");
                //wb.UploadString("https://webhook.site/a2a4e6f6-cb31-4e33-b189-f977976c3a40", value.ToString());
            }


            System.Diagnostics.Trace.WriteLine("Post method started....");
          //  System.Diagnostics.Trace.WriteLine(value.ToString());

           // Root root = JsonConvert.DeserializeObject<Root>(value.ToString());

            return "";
        }

       
    }
}
