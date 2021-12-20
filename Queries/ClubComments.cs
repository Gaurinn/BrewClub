﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class ClubCommentsQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public ClubCommentsQ()
        {
            db = new BrewDBEntities();
        }

        //get authors for comments
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

        //get one comment
        public ClubCommentsDTO getComment(int id)
        {
            var comment = (from x in db.ClubComments
                           where x.Id == id
                           select new ClubCommentsDTO
                           {
                               Id = x.Id,
                               postId = x.postId,
                               comment = x.comment,
                               authorId = x.authorId,
                               dateTime = x.dateTime
                           }).SingleOrDefault();
            //get name of the author
            comment.author = GetAuthorById(comment.authorId).name;
            return comment;
        }

        //get all comments
        public IEnumerable<ClubCommentsDTO> getAll()
        {
            var comments = (from x in db.ClubComments
                            select new ClubCommentsDTO
                            {
                                Id = x.Id,
                                postId = x.postId,
                                comment = x.comment,
                                authorId = x.authorId,
                                dateTime = x.dateTime
                            }).ToList();
            //get name of author if not set to null
            foreach (var p in comments)
            {
                if (GetAuthorById(p.authorId) != null)
                {
                    p.author = GetAuthorById(p.authorId).name;
                }
            }
            return comments;
        }
       
        //create a new comment
        public ClubCommentsDTO Create(ClubCommentsDTO c)
        {
            // Create a comment object from the CommentsDTO.
            var comment = new ClubComments
            {
                postId = c.postId,
                comment = c.comment,
                authorId = c.authorId,
                dateTime = DateTime.Now,
            };
            // Add the comment to db
            db.ClubComments.Add(comment);
            // Savedb
            db.SaveChanges();
            // Save ID to the CommentsDTO
            c.Id = comment.Id;
            //save author to the CommentsDTO
            c.author = GetAuthorById(comment.authorId).name;
            return c;
        }

        //edit comment
        public ClubCommentsDTO Edit(ClubCommentsDTO c)
        {
            //find comment in DB
            var cm = (from x in db.ClubComments
                      where x.Id == c.Id
                      select x).SingleOrDefault();
            //edit comment
            cm.postId = c.postId;
            cm.comment = c.comment;
            cm.authorId = c.authorId;
            cm.dateTime = DateTime.Now;
            c.dateTime = cm.dateTime; //update the time stamp in the DTO
            //Save the changes
            db.SaveChanges();
            return c;
        }

        //delete a comment
        public bool Delete(int id)
        {
            try
            {
                //find type in db
                var cm = (from x in db.ClubComments
                          where x.Id == id
                          select x).SingleOrDefault();
                //remove comment
                db.ClubComments.Remove(cm);
                //saveDB
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