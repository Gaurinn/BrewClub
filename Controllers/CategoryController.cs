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
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        private CategoryQ cQ;

        public CategoryController()
        {
            cQ = new CategoryQ();
        }

        //get one category
        [Route("{id}")]
        [HttpGet]
        public CategoryDTO getCategory(int id)
        {
            return cQ.getCategory(id);
        }

        //get all categories
        [Route("")]
        [HttpGet]
        public IEnumerable<CategoryDTO> getAll()
        {
            return cQ.getAll();
        }
    }
}
