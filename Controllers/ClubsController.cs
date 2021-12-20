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
    [RoutePrefix("api/clubs")]
    public class ClubsController : ApiController
    {
        private readonly ClubsQ cQ;

        public ClubsController()
        {
            cQ = new ClubsQ();
        }

        //get one club
        [Route("{id}")]
        [HttpGet]
        public ClubsDTO GetSingle(int id)
        {
            return cQ.GetSingle(id);
        }

        //get all clubs
        [Route("")]
        [HttpGet]
        public IEnumerable<ClubsDTO> GetAll()
        {
            return cQ.GetAll();
        }

        //create a club
        [Route("")]
        [HttpPost]
        public ClubsDTO Create(ClubsDTO c)
        {
            return cQ.Create(c);
        }

        //edit a club
        [Route("")]
        [HttpPut]
        public ClubsDTO Edit(ClubsDTO c)
        {
            return cQ.Edit(c);
        }

        //delete a club
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return cQ.Delete(id);
        }
    }
}
