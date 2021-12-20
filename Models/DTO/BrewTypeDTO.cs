using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class BrewTypeDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //brewtype name
        public string type { get; set; }
    }
}