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
    [RoutePrefix("api/clubcomments")]
    public class ClubCommentsController : ApiController
    {
        private ClubCommentsQ ccQ;

        public ClubCommentsController()
        {
            ccQ = new ClubCommentsQ();
        }

        //get one comment
        [Route("{id}")]
        [HttpGet]
        public ClubCommentsDTO getComment(int id)
        {
            return ccQ.getComment(id);
        }

        //get all comments
        [Route("")]
        [HttpGet]
        public IEnumerable<ClubCommentsDTO> getAll()
        {
            return ccQ.getAll();
        }

        //create a comment
        [Route("")]
        [HttpPost]
        public ClubCommentsDTO Create(ClubCommentsDTO c)
        {
            return ccQ.Create(c);
        }

        //edit a comment
        [Route("")]
        [HttpPut]
        public ClubCommentsDTO Edit(ClubCommentsDTO c)
        {
            return ccQ.Edit(c);
        }

        //delete a comment
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return ccQ.Delete(id);
        }
    }
}
