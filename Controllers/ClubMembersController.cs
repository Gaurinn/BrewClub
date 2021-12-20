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
    [RoutePrefix("api/clubmembers")]
    public class ClubMembersController : ApiController
    {
        private ClubMembersQ cmQ;

        public ClubMembersController()
        {
            cmQ = new ClubMembersQ();
        }

        //get one clubmember
        [Route("{id}")]
        [HttpGet]
        public IEnumerable<ClubMembersDTO> GetAllMembers(int id)
        {
            return cmQ.getSingle(id);
        }

        //create a clubmember
        [Route("")]
        [HttpPost]
        public ClubMembersDTO Create(ClubMembersDTO c)
        {
            return cmQ.Create(c);
        }

        //delete a club member
        [Route("removemember")]
        [HttpPost]
        public bool Delete(ClubMembersDTO id)
        {
            return cmQ.Delete(id);
        }
    }
}
