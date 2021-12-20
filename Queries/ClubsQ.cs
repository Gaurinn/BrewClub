using System;
using System.Collections.Generic;
using System.Linq;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class ClubsQ
    {
        // The link to the database entities.
        private readonly BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public ClubsQ()
        {
            db = new BrewDBEntities();
        }

        //get authors for clubLeader
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

        //get one club
        public ClubsDTO GetSingle(int id)
        {
            var club = (from x in db.Clubs
                        where x.Id == id
                        select new ClubsDTO
                        {
                            Id = x.Id,
                            name = x.name,
                            description = x.description,
                            memberId = x.leaderId
                        }).SingleOrDefault();

            //get leader name for club
            club.leaderName = GetAuthorById(club.memberId).name;
            return club;
        }

        //get all clubs
        public IEnumerable<ClubsDTO> GetAll()
        {
            var clubs = (from x in db.Clubs
                         select new ClubsDTO
                         {
                             Id = x.Id,
                             name = x.name,
                             description = x.description,
                             memberId = x.leaderId
                         }).ToList();

            foreach (var p in clubs)
            {
                //get club posts
                p.posts = (from x in db.ClubPosts
                              where x.clubId == p.Id
                              select new ClubPostsDTO
                              {
                                  Id = x.Id,
                                  body = x.body,
                                  categoryId = x.categoryId,
                                  authorId = x.authorId,
                                  dateTime = x.dateTime,
                                  categoryName = x.categoryName,
                                  clubId = x.clubId
                              }).ToList();               
            }
            return clubs;
        }

        //create a new club
        public ClubsDTO Create(ClubsDTO c)
        {
            // Create a CLub object from the ClubsDTO.
            var club = new Clubs
            {
                name = c.name,
                description = c.description,
                leaderId = c.memberId
            };
            // Add the Club to db
            db.Clubs.Add(club);
            // Savedb
            db.SaveChanges();
            // Save the ID to the ClubsDTO
            c.Id = club.Id;
            //get name of leader
            c.leaderName = GetAuthorById(club.leaderId).name;
            //add leader to be a member of newly created club
            var member = new ClubMembers { clubId = c.Id, memberId = c.memberId };
            db.ClubMembers.Add(member);
            //saveDB
            db.SaveChanges();
            return c;
        }

        //edit a club
        public ClubsDTO Edit(ClubsDTO c)
        {
            // Find the club in the database.
            var club = (from x in db.Clubs
                        where x.Id == c.Id
                        select x).SingleOrDefault();
            // Change the properties of the club.
            club.name = c.name;
            club.description = c.description;         
            // Savedb
            db.SaveChanges();
            return c;
        }

        //deleta a club
        public bool Delete (int id)
        {
            try
            {
                // Find the club
                var club = (from x in db.Clubs
                            where x.Id == id
                            select x).SingleOrDefault();
                // Remove the club
                db.Clubs.Remove(club);
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
