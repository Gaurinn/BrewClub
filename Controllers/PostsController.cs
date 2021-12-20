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
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {

        private readonly PostsQ pQ;

        public PostsController()
        {
            pQ = new PostsQ();
        }

        //get one post 
        [Route("{id}")]
        [HttpGet]
        public PostsDTO GetSingle(int id)
        {
            return pQ.GetSingle(id);
        }

        //get all posts
        [Route("")]
        [HttpGet]
        public IEnumerable<PostsDTO> GetAll()
        {
            return pQ.GetAll();
        }

        //create a post
        [Route("")]
        [HttpPost]
        public PostsDTO Create(PostsDTO p)
        {
            return pQ.Create(p);
        }

        //edit a post
        [Route("")]
        [HttpPut]
        public PostsDTO Edit(PostsDTO p)
        {
            return pQ.Edit(p);
        }

        //delete a post
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return pQ.Delete(id);
        }
    }
}
