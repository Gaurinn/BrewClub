using System;
using System.Collections.Generic;
using System.Linq;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class ClubPostsQ
    {
        // The link to the database entities.
        private readonly BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public ClubPostsQ()
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

        //get club for posts
        private ClubsDTO GetClubById(int id)
        {
            return (from x in db.Clubs
                    where x.Id == id
                    select new ClubsDTO
                    {
                        Id = x.Id,
                        name = x.name,
                        description = x.description,
                        memberId = x.leaderId
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
        public ClubPostsDTO GetSingle(int id)
        {
            var post = (from x in db.ClubPosts
                        where x.Id == id
                        select new ClubPostsDTO
                        {
                            Id = x.Id,
                            body = x.body,
                            title = x.title,
                            categoryId = x.categoryId,
                            authorId = x.authorId,
                            dateTime = x.dateTime,
                            clubId = x.clubId
                        }).SingleOrDefault();
            //get author name for post
            post.author = GetAuthorById(post.authorId).name;
            return post;
        }

        //get all posts
        public IEnumerable<ClubPostsDTO> GetAll(int id)
        {
            var posts = (from x in db.ClubPosts
                         where x.clubId == id
                         select new ClubPostsDTO
                         {
                             Id = x.Id,
                             body = x.body,
                             title = x.title,
                             categoryId = x.categoryId,
                             dateTime = x.dateTime,
                             authorId = x.authorId,
                             categoryName = x.categoryName,
                             clubId = x.clubId
                         }).ToList();
            //get authors if not set to null
            foreach (var p in posts)
            {
                if (GetAuthorById(p.authorId) != null)
                {
                    p.author = GetAuthorById(p.authorId).name;
                }
            }
            return posts;
        }

        //create a new club post
        public ClubPostsDTO Create(ClubPostsDTO p)
        {
            // Find category name
            var category = GetCategoryNameById(p.categoryId);
            if (category != null)
            {
                p.categoryName = category.name;
            }
            // Create a Post object from the ClubPostsDTO.
            var post = new ClubPosts
            {
                body = p.body,
                title = p.title,
                categoryId = p.categoryId,
                authorId = p.authorId,
                dateTime = DateTime.Now,
                categoryName = p.categoryName,
                clubId = p.clubId
            };
            // Add the Post to db
            db.ClubPosts.Add(post);
            // Savedb
            db.SaveChanges();
            // Save the ID to the postDTO
            p.Id = post.Id;
            //get name of author
            p.author = GetAuthorById(post.authorId).name;

            return p;
        }

        //edit a post
        public ClubPostsDTO Edit(ClubPostsDTO p)
        {
            // Find the post in the database.
            var post = (from x in db.ClubPosts
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
            post.clubId = p.clubId;
            // Savedb
            db.SaveChanges();
            return p;
        }

        //delete a post
        public bool Delete(int id)
        {
            try
            {
                // Find the post.
                var post = (from x in db.ClubPosts
                            where x.Id == id
                            select x).SingleOrDefault();
                // Remove the post
                db.ClubPosts.Remove(post);
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
