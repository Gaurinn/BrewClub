using System;
using System.Collections.Generic;
using System.Linq;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class PostsQ
    {
        // The link to the database entities.
        private readonly BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public PostsQ()
        {
            db = new BrewDBEntities();
        }

        //get authors for posts
        private AuthorsDTO GetAuthorById(int id)
        {
            return (from x in db.Authors
                    where x.Id == id
                    select new AuthorsDTO
                    {
                        active = x.active.Value,
                        Id = x.Id,
                        description = x.description,
                        email = x.email,
                        modified = x.modified.Value,
                        name = x.name
                    }).SingleOrDefault();
        }

        //get categories for posts
        private Category GetCategoryNameById(int id)
        {
            return (from x in db.Category
                    where x.Id == id
                    select x).SingleOrDefault();
        }

        //get one post
        public PostsDTO GetSingle(int id)
        {
            var post = (from x in db.Posts
                    where x.Id == id
                    select new PostsDTO
                    {
                        Id = x.Id,
                        body = x.body,
                        title = x.title,
                        categoryId = x.categoryId,
                        authorId = x.authorId,
                        dateTime = x.dateTime
                    }).SingleOrDefault();
            //get author name for post
            post.author = GetAuthorById(post.authorId).name;
            return post;
        }

        //get all posts
        public IEnumerable<PostsDTO> GetAll()
        {
            var posts = (from x in db.Posts
                    select new PostsDTO
                    {
                        Id = x.Id,
                        body = x.body,
                        title = x.title,
                        categoryId = x.categoryId,
                        dateTime = x.dateTime,
                        authorId = x.authorId,
                        categoryName = x.categoryName
                    }).ToList();            
            //get authors if not set to null
            foreach (var p in posts)
            {
                if(GetAuthorById(p.authorId) != null)
                {
                    p.author = GetAuthorById(p.authorId).name;
                }                
                //get comments
                p.comments = (from x in db.Comments
                              where x.postId == p.Id
                              select new CommentsDTO
                              {
                                  Id = x.Id,
                                  authorId = x.authorId,
                                  comment = x.comment,
                                  postId = x.postId,
                                  dateTime = x.dateTime,
                              }).ToList();
                //get comments if authors is not set to null
                foreach (var item in p.comments)
                {
                    var name = GetAuthorById(item.authorId);
                    if(name != null)
                    {
                        item.author = name.name;
                    }                  
                }
            }
            return posts;
        }

        //create a new post
        public PostsDTO Create(PostsDTO p)
        {
            // Find category name
            var category = GetCategoryNameById(p.categoryId);
            if (category != null)
            {
                p.categoryName = category.name;
            }           
            // Create a Post object from the PostsDTO.
            var post = new Posts
            {
                body = p.body,
                title = p.title,
                categoryId = p.categoryId,
                authorId = p.authorId,
                dateTime = DateTime.Now,
                categoryName = p.categoryName
            };
            // Add the Post to db
            db.Posts.Add(post);
            // Savedb
            db.SaveChanges();
            // Save the ID to the postDTO
            p.Id = post.Id;
            //get name of author
            p.author = GetAuthorById(post.authorId).name;
            return p;
        }

        //edit a post
        public PostsDTO Edit(PostsDTO p)
        {
            // Find the post in the database.
            var post = (from x in db.Posts
                        where x.Id == p.Id
                        select x).SingleOrDefault();
            // Change the properties of the post.
            post.body = p.body;
            post.title = p.title;
            post.categoryId = p.categoryId;
            post.dateTime = DateTime.Now;
            p.dateTime = post.dateTime; // Update the time stamp in the DTO.
            post.authorId = p.authorId;
            post.categoryName = p.categoryName;
            // Savedb
            db.SaveChanges();
            return p;
        }

        //deleta a post
        public bool Delete(int id)
        {
            try
            {
                // Find the post.
                var post = (from x in db.Posts
                            where x.Id == id
                            select x).SingleOrDefault();
                // Remove the post
                db.Posts.Remove(post);
                // Save the changes
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
