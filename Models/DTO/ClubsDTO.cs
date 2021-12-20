using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewClub.Models.DTO
{
    public class ClubsDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //name of club
        public string name { get; set; }
        //description of club
        public string description { get; set; }
        //name of club leader
        public string leaderName { get; set; }
        //member id
        public int memberId { get; set; }
        //list of posts for club
        public List<ClubPostsDTO> posts { get; set; }
    }
}
