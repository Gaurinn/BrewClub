using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrewClub.Queries;
using BrewClub.Models.DTO;

namespace BrewClub.Controllers
{
    //[Authorize]
    [RoutePrefix("api/grains")]
    public class GrainsController : ApiController
    {
        private GrainsQ gQ;

        public GrainsController()
        {
            gQ = new GrainsQ();
        }

        //get one grain
        [Route("{id}")]
        [HttpGet]
        public GrainsDTO getGrain(int id)
        {
            return gQ.getGrain(id);
        }

        //get all grains
        [Route("")]
        [HttpGet]
        public IEnumerable<GrainsDTO> getAll()
        {
            return gQ.getAll();
        }
    }
}
