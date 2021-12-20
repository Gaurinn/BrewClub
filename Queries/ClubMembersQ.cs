using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewClub.Models;
using BrewClub.Models.DTO;

namespace BrewClub.Queries
{
    public class ClubMembersQ
    {
        // The link to the database entities.
        private BrewDBEntities db;

        // Class initializer. Runs every time a new instance of this class is generated.
        public ClubMembersQ()
        {
            db = new BrewDBEntities();
        }

        //get author for clubmembers
        private AuthorsDTO GetAuthorById(int id)
        {
            return (from x in db.Authors
                    where x.Id == id
                    select new AuthorsDTO
                    {
                        active = x.active,
                        name = x.name,
                        description = x.description,
                        modified = x.modified,
                        email = x.email,
                        Id = x.Id
                    }).SingleOrDefault();
        }

        //get one clubmember
        public IEnumerable<ClubMembersDTO> getSingle(int id)
        {
            var club = (from x in db.ClubMembers
                      where x.clubId == id
                      select new ClubMembersDTO
                      {
                          Id = x.Id,
                          clubId = x.Id,
                          memberId = x.memberId.Value
                      }).ToList();

            foreach (var member in club)
            {
                member.memberName = GetAuthorById(member.memberId).name;
            }

            return club;
        }

        // create a clubMember    
        public ClubMembersDTO Create(ClubMembersDTO m)
        {
            var alreadyCreated = (from x in db.ClubMembers
                              where x.clubId == m.clubId && x.memberId == m.memberId
                              select x).SingleOrDefault();
            if(alreadyCreated != null)
            {
                throw new Exception("User is already member of club");
            }
            //create db element from the DTO
            var me = new ClubMembers
            {
                Id = m.Id,
                clubId = m.clubId,
                memberId = m.memberId
            };
            //add club Member to database
            db.ClubMembers.Add(me);
            //saveDB
            db.SaveChanges();
            //save the ID to the ClubMembersDTO
            m.Id = me.Id;
            return m;
        }
    
        //delete a clubMember    
        public bool Delete(ClubMembersDTO member)
        {
            try
            {
                //find clubmember in db
                var me = (from x in db.ClubMembers
                          where x.memberId == member.memberId && x.clubId == member.clubId
                          select x).SingleOrDefault();
                //remove clubmember
                db.ClubMembers.Remove(me);
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