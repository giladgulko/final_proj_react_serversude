using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tar3_server.Models;

namespace tar3_server.Controllers
{
    public class reportController : ApiController
    {
        // GET api/<controller>
        public List<report> Get(string date)
        {

            report p = new report();
            List<report> dishList = p.Read(date);
           return dishList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(report p)
        {
            p.insert();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}