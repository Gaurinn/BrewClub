using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class HopsQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public HopsQ()
        {
            db = new BrewDBEntities();
        }

        //get one Hop
        public HopsDTO getHop(int id)
        {
            return (from x in db.Hops
                    where x.Id == id
                    select new HopsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        acid = x.acid,
                        country = x.country,
                        description = x.description
                    }).SingleOrDefault();
        }

        //get all hops
        public IEnumerable<HopsDTO> getAll()
        {
            return (from x in db.Hops
                    select new HopsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        acid = x.acid,
                        country = x.country,
                        description = x.description
                    });
        }
    }
}