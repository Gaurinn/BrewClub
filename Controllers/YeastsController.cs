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
    [RoutePrefix("api/yeasts")]
    public class YeastsController : ApiController
    {
        private YeastsQ yQ;

        public YeastsController()
        {
            yQ = new YeastsQ();
        }

        //get one yeast
        [Route("{id}")]
        [HttpGet]
        public YeastsDTO getYeast(int id)
        {
            return yQ.getYeast(id);
        }

        //get all yeasts
        [Route("")]
        [HttpGet]
        public IEnumerable<YeastsDTO> getAll()
        {
            return yQ.getAll();
        }
    }
}
