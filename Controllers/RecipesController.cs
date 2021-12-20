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
    [RoutePrefix("api/recipes")]
    public class RecipesController : ApiController
    {

        private RecipesQ rQ;

        public RecipesController()
        {
            rQ = new RecipesQ();
        }

        //get one recipe
        [Route("{id}")]
        [HttpGet]
        public RecipesDTO getRecipe(int id)
        {
            return rQ.GetRecipe(id);
        }

        //get all recipes
        [Route("")]
        [HttpGet]
        public IEnumerable<RecipesDTO> getAllRecipes()
        {
            return rQ.GetAllRecipes();
        }

        //create a recipe
        [Route("")]
        [HttpPost]
        public RecipesDTO Create(RecipesDTO r)
        {
            return rQ.Create(r);
        }

        //edit a recipe
        [Route("")]
        [HttpPut]
        public RecipesDTO Edit(RecipesDTO r)
        {
            return rQ.Edit(r);
        }

        //delete a recipe
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return rQ.Delete(id);
        }
    }
}
