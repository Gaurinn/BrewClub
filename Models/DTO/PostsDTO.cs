using System;
using System.Collections.Generic;

namespace BrewClub.Models.DTO
{
    public class PostsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //the post title
        public string title { get; set; }
        //body of post
        public string body { get; set; }
        //category id of post
        public int categoryId { get; set; }
        //author id of post
        public int authorId { get; set; }
        //author name of post
        public string author { get; set; }
        //datetime of post
        public Nullable<System.DateTime> dateTime { get; set; }
        //category name of post
        public string categoryName { get; set; }
        //list of comments for post
        public List<CommentsDTO> comments { get; set; }
    }
}