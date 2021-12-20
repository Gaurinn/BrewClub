using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class otherIngredientsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //name of other ingredient
        public string name { get; set; }
        //description of other ingredient
        public string description { get; set; }
    }
}