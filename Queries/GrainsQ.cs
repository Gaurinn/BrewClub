using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class GrainsQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public GrainsQ()
        {
            db = new BrewDBEntities();
        }

        //get one Grain
        public GrainsDTO getGrain(int id)
        {
            return (from x in db.Grains
                    where x.Id == id
                    select new GrainsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        country = x.country,
                        description = x.description
                    }).SingleOrDefault();
        }

        //get all grains
        public IEnumerable<GrainsDTO> getAll()
        {
            return (from x in db.Grains
                    select new GrainsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        country = x.country,
                        description = x.description
                    });
        }
    }
}