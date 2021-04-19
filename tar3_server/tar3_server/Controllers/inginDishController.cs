using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tar3_server.Models;

namespace tar3_server.Controllers
{
    public class inginDishController : ApiController
    {
        // GET api/<controller>
        //public List<inginDish> Get()
        //{
        //    inginDish ingredients = new inginDish();
        //    List<inginDish> ingList = ingredients.Read();
        //    return ingList;
        //}

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(inginDish indDi)
        {
            indDi.Insert();
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