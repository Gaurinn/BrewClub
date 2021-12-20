using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewClub.Models.DTO
{
    public class ClubMembersDTO
    {
        //Primary key, auto generated
        public int Id { get; set; }
        //the club id of a club
        public int clubId { get; set; }
        //the id of a member
        public int memberId { get; set; }
        //member name
        public string memberName { get; set; }
    }
}
