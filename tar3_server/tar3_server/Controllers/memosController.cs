using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tar3_server.Models;

namespace tar3_server.Controllers
{
    public class memosController : ApiController
    {
        // GET api/<controller>
        public List<memos> Get()
        {
            memos m = new memos();
            List<memos> memosList = m.Read();
            return memosList;
        }

        
      

     
        public void Post([FromBody] memos m)
        {
            m.Insert();
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