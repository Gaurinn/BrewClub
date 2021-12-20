using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class CategoryDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //category name
        public string name { get; set; }
    }
}