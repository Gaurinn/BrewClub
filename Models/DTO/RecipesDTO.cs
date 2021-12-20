using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class RecipesDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //name of recipe
        public string name { get; set; }
        //id of recipe creator
        public int authorId { get; set; }
        //name of recipe creator
        public string author { get; set; }
        //rating of recipe
        public Nullable<int> rating { get; set; }
        //id of hop
        public Nullable<int> hopsId { get; set; }
        //id of grain
        public Nullable<int> grainsId { get; set; }
        //id of yeast
        public Nullable<int> yeastsId { get; set; }
        //name of hops
        public string hopsName { get; set; }
        //name of grains
        public string grainsName { get; set; }
        //name of yeast
        public string yeastName { get; set; }
        //name of otherIngredient
        public string otherIngName { get; set; }
        //id of other ingredient
        public Nullable<int> otherIngredientId { get; set; }
        //description of recipe, details for brewing
        public string description { get; set; }
        //water amount for recipe
        public Nullable<int> water { get; set; }
        //datetime of recipe creation
        public Nullable<System.DateTime> dateTime { get; set; }
    }
}