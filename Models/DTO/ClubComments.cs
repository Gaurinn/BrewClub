using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewClub.Models.DTO
{
    public class ClubCommentsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //the postId of the post being commented on
        public int postId { get; set; }
        //body of comment
        public string comment { get; set; }
        //the id of the commenter
        public int authorId { get; set; }
        //name of commenter
        public string author { get; set; }
        //datetime of comment
        public Nullable<System.DateTime> dateTime { get; set; }
    }
}