using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class otherIngredientsQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public otherIngredientsQ()
        {
            db = new BrewDBEntities();
        }

        //get one otherIngredient
        public otherIngredientsDTO getOtherIngredient(int id)
        {
            return (from x in db.otherIngredients
                    where x.Id == id
                    select new otherIngredientsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        description = x.description
                    }).SingleOrDefault();
        }

        //get all otherIngredients
        public IEnumerable<otherIngredientsDTO> getAll()
        {
            return (from x in db.otherIngredients
                    select new otherIngredientsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        description = x.description
                    });
        }
    }
}