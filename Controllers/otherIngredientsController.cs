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
    [RoutePrefix("api/otherIngredients")]
    public class otherIngredientsController : ApiController
    {

        private otherIngredientsQ oIQ;

        public otherIngredientsController()
        {
            oIQ = new otherIngredientsQ();
        }

        //get one otherIngredient
        [Route("{id}")]
        [HttpGet]
        public otherIngredientsDTO getOtherIngredient(int id)
        {
            return oIQ.getOtherIngredient(id);
        }

        //get all otherIngredients
        [Route("")]
        [HttpGet]
        public IEnumerable<otherIngredientsDTO> getAll()
        {
            return oIQ.getAll();
        }
    }
}