﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiZoo.Controllers
{
    public class _EspeciesController : ApiController
    {
        // GET: api/Especies
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Especies/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Especies
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Especies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Especies/5
        public void Delete(int id)
        {
        }
    }
}
