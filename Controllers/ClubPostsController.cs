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
    [RoutePrefix("api/clubposts")]
    public class ClubPostsController : ApiController
    {

        private readonly ClubPostsQ cpQ;

        public ClubPostsController()
        {
            cpQ = new ClubPostsQ();
        }

        //get one club post 
        [Route("single/{id}")]
        [HttpGet]
        public ClubPostsDTO GetSingle(int id)
        {
            return cpQ.GetSingle(id);
        }

        //get all club posts
        [Route("{id}")]
        [HttpGet]
        public IEnumerable<ClubPostsDTO> GetAll(int id)
        {
            return cpQ.GetAll(id);
        }

        //create a club post
        [Route("")]
        [HttpPost]
        public ClubPostsDTO Create(ClubPostsDTO p)
        {
            return cpQ.Create(p);
        }

        //edit a club post
        [Route("")]
        [HttpPut]
        public ClubPostsDTO Edit(ClubPostsDTO p)
        {
            return cpQ.Edit(p);
        }

        //delete a post
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return cpQ.Delete(id);
        }
    }
}
