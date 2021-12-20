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
    [Authorize]
    [RoutePrefix("api/brewtypes")]
    public class BrewTypeController : ApiController
    {
        private BrewTypeQ btQ;

        public BrewTypeController()
        {
            btQ = new BrewTypeQ();
        }

        //get one brewtype 
        [Route("{id}")]
        [HttpGet]
        public BrewTypeDTO getBrewType(int id)
        {
            return btQ.getBrewType(id);
        }

        //get all brew types
        [Route("")]
        [HttpGet]
        public IEnumerable<BrewTypeDTO> getAll()
        {
            return btQ.getAll();
        }
    }
}
