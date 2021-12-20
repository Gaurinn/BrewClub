using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class HopsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //hop name
        public string name { get; set; }
        //hop acidity level
        public string acid { get; set; }
        //hop country of origin
        public string country { get; set; }
        //hop description
        public string description { get; set; }
    }
}