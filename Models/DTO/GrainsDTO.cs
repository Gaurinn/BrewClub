using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class GrainsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //grain name
        public string name { get; set; }
        //grain country of origin
        public string country { get; set; }
        //grain description
        public string description { get; set; }
    }
}