using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class AuthorsQ
    {
        // The link to the database entities.
        private readonly BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public AuthorsQ()
        {
            db = new BrewDBEntities();
        }

        //get authorid by email
        public int GetAuthorIdByEmail(string email)
        {
            return (from x in db.Authors
                    where x.email == email
                    select new AuthorsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        email = x.email,
                        active = x.active.Value,
                        modified = x.modified.Value,
                        description = x.description
                    }).SingleOrDefault().Id;
        }

        //get one author
        public AuthorsDTO GetSingle(int id)
        {
            return (from x in db.Authors
                    where x.Id == id
                    select new AuthorsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        email = x.email,
                        active = x.active.Value,
                        modified = x.modified.Value,
                        description = x.description
                    }).SingleOrDefault();
        }

        //get all authors
        public IEnumerable<AuthorsDTO> GetAll()
        {
            return (from x in db.Authors
                    select new AuthorsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        email = x.email,
                        active = x.active.Value,
                        modified = x.modified.Value,
                        description = x.description
                    });
        }

        //create a new author
        public AuthorsDTO Create(AuthorsDTO x)
        {
            // Create a new Author object.
            var author = new Authors
            {
                name = x.name,
                email = x.email,
                active = true,
                modified = DateTime.Now,
                description = x.description
            };
            // Add to the database and save.
            db.Authors.Add(author);
            //SaveDB
            db.SaveChanges();
            // Set the id to the AuthorDTO
            x.Id = author.Id;
            return x;
        }

        //edit an author
        public AuthorsDTO Edit(AuthorsDTO x)
        {
            // Find the database object.
            var a = (from k in db.Authors
                     where k.Id == x.Id
                     select k).SingleOrDefault();
            // Change the database object.
            a.name = x.name;
            a.email = x.email;
            a.active = x.active;
            a.modified = DateTime.Now;
            x.modified = a.modified.Value;
            a.description = x.description;
            // Save the changes.
            db.SaveChanges();
            return x;
        }

        //delete author
        public bool Delete(int id)
        {
            try
            {
                // Find object in database.
                var author = (from x in db.Authors
                              where x.Id == id
                              select x).SingleOrDefault();
                // remove the object.
                db.Authors.Remove(author);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
