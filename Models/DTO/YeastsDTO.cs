using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class YeastsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //name of yeast
        public string name { get; set; }
        //yeast country of origin
        public string country { get; set; }
        //yeast description
        public string description { get; set; }
        //yeast optimal fermentation temperature
        public string temperature { get; set; }
    }
}