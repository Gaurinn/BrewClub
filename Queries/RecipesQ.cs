using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class RecipesQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public RecipesQ()
        {
            db = new BrewDBEntities();
        }

        //get authors for recipe
        private AuthorsDTO GetAuthorById(int id)
        {
            return (from x in db.Authors
                    where x.Id == id
                    select new AuthorsDTO
                    {
                        active = x.active.Value,
                        Id = x.Id,
                        description = x.description,
                        email = x.email,
                        modified = x.modified.Value,
                        name = x.name
                    }).SingleOrDefault();
        }

        //get one recipe
        public RecipesDTO GetRecipe(int id)
        {
            var rp = (from x in db.Recipes
                        where x.Id == id
                        select new RecipesDTO
                        {
                            Id = x.Id,
                            name = x.name,
                            authorId = x.authorId,
                            rating = x.rating,
                            hopsId = x.hopsId,
                            grainsId = x.grainsId,
                            yeastsId = x.yeastsId,
                            otherIngredientId = x.otherIngredientId,
                            description = x.description,
                            water = x.water,
                            dateTime = x.dateTime,
                            hopsName = x.hopsName,
                            grainsName = x.grainsName,
                            yeastName = x.yeastName,
                            otherIngName = x.otherIngName
                        }).SingleOrDefault();           
            //get author name for recipe
            rp.author = GetAuthorById(rp.authorId).name;
            return rp;
        }

        //get all recipes
        public IEnumerable<RecipesDTO> GetAllRecipes()
        {
            var rp = (from x in db.Recipes
                         select new RecipesDTO
                         {
                             Id = x.Id,
                             name = x.name,
                             authorId = x.authorId,
                             rating = x.rating,
                             hopsId = x.hopsId,
                             grainsId = x.grainsId,
                             yeastsId = x.yeastsId,
                             otherIngredientId = x.otherIngredientId,
                             description = x.description,
                             water = x.water,
                             dateTime = x.dateTime,
                             hopsName = x.hopsName,
                             grainsName = x.grainsName,
                             yeastName = x.yeastName,
                             otherIngName = x.otherIngName
                         }).ToList();
            //get author name if not null
            foreach (var r in rp)
            {
                if (GetAuthorById(r.authorId) != null)
                {
                    r.author = GetAuthorById(r.authorId).name;
                }
            }
            return rp;
        }

        // create a recipe    
        public RecipesDTO Create(RecipesDTO r)
        {
            //create db element from the DTO
            var rp = new Recipes
            {
                name = r.name,
                authorId = r.authorId,
                rating = r.rating,
                hopsId = r.hopsId,
                grainsId = r.grainsId,
                yeastsId = r.yeastsId,
                otherIngredientId = r.otherIngredientId,
                description = r.description,
                water = r.water,
                dateTime = DateTime.Now,
                hopsName = r.hopsName,
                grainsName = r.grainsName,
                yeastName = r.yeastName,
                otherIngName = r.otherIngName
            };
            //add recipe to database
            db.Recipes.Add(rp);
            //saveDB
            db.SaveChanges();
            //save the ID to the RecipesDTO
            r.Id = rp.Id;
            //author name
            r.author = GetAuthorById(rp.authorId).name;
            return r;
        }

        //edit recipe
        public RecipesDTO Edit(RecipesDTO r)
        {
            //find recipe in DB
            var rp = (from x in db.Recipes
                      where x.Id == r.Id
                      select x).SingleOrDefault();
            //edit recipe
            rp.name = r.name;
            rp.authorId = r.authorId;
            rp.rating = r.rating;
            rp.hopsId = r.hopsId;
            rp.grainsId = r.grainsId;
            rp.yeastsId = r.yeastsId;
            rp.otherIngredientId = r.otherIngredientId;
            rp.description = r.description;
            rp.water = r.water;
            rp.dateTime = DateTime.Now;
            r.dateTime = rp.dateTime; //update the time stamp tin the DTO
            rp.hopsName = r.hopsName;
            rp.grainsName = r.grainsName;
            rp.yeastName = r.yeastName;
            rp.otherIngName = r.otherIngName;            
            //Save the changes
            db.SaveChanges();
            return r;
        }

        //delete a recipe    
        public bool Delete(int id)
        {
            try
            {
                //find recipe in db
                var rp = (from x in db.Recipes
                          where x.Id == id
                          select x).SingleOrDefault();
                //remove recipe
                db.Recipes.Remove(rp);
                //saveDB
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