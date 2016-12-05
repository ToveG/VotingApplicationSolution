using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VotingApplication.Entities;

namespace VotingApplication.Controllers
{
    public class DbController : ApiController
    {
        private DataContext _ctx;

        public DbController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/createDatabase")]
        public IHttpActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
