using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class CategoryQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public CategoryQ()
        {
            db = new BrewDBEntities();
        }

        //get one category
        public CategoryDTO getCategory(int id)
        {
            return (from x in db.Category
                    where x.Id == id
                    select new CategoryDTO
                    {
                        Id = x.Id,
                        name = x.name
                    }).SingleOrDefault();
        }

        //get all categories
        public IEnumerable<CategoryDTO> getAll()
        {
            return (from x in db.Category
                    select new CategoryDTO
                    {
                        Id = x.Id,
                        name = x.name
                    });
        }
    }
}