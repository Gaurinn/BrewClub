using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class CommentsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //id of post for comment
        public int postId { get; set; }
        //body of comment
        public string comment { get; set; }
        //author id
        public int authorId { get; set; }
        //author name
        public string author { get; set; }
        //datetime of comment
        public Nullable<System.DateTime> dateTime { get; set; }
    }
}