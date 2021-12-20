using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class AuthorsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //author name
        public string name { get; set; }
        //author email
        public string email { get; set; }
        //author description
        public string description { get; set; }
        //is author active or not
        public Nullable<bool> active { get; set; }
        //date author created or modified
        public Nullable<System.DateTime> modified { get; set; }
    }
}