using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class BrewTypeQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public BrewTypeQ()
        {
            db = new BrewDBEntities();
        }

        //get one BrewType
        public BrewTypeDTO getBrewType(int id)
        {
            return (from x in db.BrewType
                    where x.Id == id
                    select new BrewTypeDTO
                    {
                        Id = x.Id,
                        type = x.type
                    }).SingleOrDefault();
        }

        //get all BrewTypes
        public IEnumerable<BrewTypeDTO> getAll()
        {
            return (from x in db.BrewType
                    select new BrewTypeDTO
                    {
                        Id = x.Id,
                        type = x.type
                    });
        }
    }
}