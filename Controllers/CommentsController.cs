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
    [RoutePrefix("api/comments")]
    public class CommentsController : ApiController
    {
        private CommentsQ cmQ;

        public CommentsController()
        {
            cmQ = new CommentsQ();
        }

        //get one comment
        [Route("{id}")]
        [HttpGet]
        public CommentsDTO getComment(int id)
        {
            return cmQ.getComment(id);
        }

        //get all comments
        [Route("")]
        [HttpGet]
        public IEnumerable<CommentsDTO> getAll()
        {
            return cmQ.getAll();
        }

        //create a comment
        [Route("")]
        [HttpPost]
        public CommentsDTO Create(CommentsDTO c)
        {
            return cmQ.Create(c);
        }

        //edit a comment
        [Route("")]
        [HttpPut]
        public CommentsDTO Edit(CommentsDTO c)
        {
            return cmQ.Edit(c);
        }

        //delete a comment
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return cmQ.Delete(id);
        }
    }
}
