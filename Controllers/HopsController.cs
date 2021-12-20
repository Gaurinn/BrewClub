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
    [RoutePrefix("api/hops")]
    public class HopsController : ApiController
    {

        private HopsQ hQ;

        public HopsController()
        {
            hQ = new HopsQ();
        }

        //get one hop
        [Route("{id}")]
        [HttpGet]
        public HopsDTO getHop(int id)
        {
            return hQ.getHop(id);
        }

        //get all hops
        [Route("")]
        [HttpGet]
        public IEnumerable<HopsDTO> getAll()
        {
            return hQ.getAll();
        }
    }
}
