//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrewClub.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipes
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int authorId { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> hopsId { get; set; }
        public Nullable<int> grainsId { get; set; }
        public Nullable<int> yeastsId { get; set; }
        public Nullable<int> otherIngredientId { get; set; }
        public string description { get; set; }
        public string hopsName { get; set; }
        public string grainsName { get; set; }
        public string yeastName { get; set; }
        public string otherIngName { get; set; }
        public Nullable<int> water { get; set; }
        public Nullable<System.DateTime> dateTime { get; set; }
    }
}
