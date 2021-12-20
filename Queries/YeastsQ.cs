using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class YeastsQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public YeastsQ()
        {
            db = new BrewDBEntities();
        }

        //get one Yeast
        public YeastsDTO getYeast(int id)
        {
            return (from x in db.Yeasts
                    where x.Id == id
                    select new YeastsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        country = x.country,
                        description = x.description,
                        temperature = x.temperature
                    }).SingleOrDefault();
        }

        //get all yeasts
        public IEnumerable<YeastsDTO> getAll()
        {
            return (from x in db.Yeasts
                    select new YeastsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        country = x.country,
                        description = x.description,
                        temperature = x.temperature
                    });
        }
    }
}