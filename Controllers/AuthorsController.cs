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
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private readonly AuthorsQ aQ;

        public AuthorsController()
        {
            aQ = new AuthorsQ();
        }

        //get one author
        [Route("{id}")]
        [HttpGet]
        public AuthorsDTO GetSingle(int id)
        {
            return aQ.GetSingle(id);
        }

        //get all authors
        [Route("")]
        [HttpGet]
        public IEnumerable<AuthorsDTO> GetAll()
        {
            return aQ.GetAll();
        }

        //create an author
        [Route("")]
        [HttpPost]
        public AuthorsDTO Create(AuthorsDTO p)
        {
            return aQ.Create(p);
        }

        //edit an author
        [Route("")]
        [HttpPut]
        public AuthorsDTO Edit(AuthorsDTO p)
        {
            return aQ.Edit(p);
        }

        //delete an author
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return aQ.Delete(id);
        }
    }
}
