﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BrewDBEntities : DbContext
    {
        public BrewDBEntities()
            : base("name=BrewDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BrewType> BrewType { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Grains> Grains { get; set; }
        public virtual DbSet<otherIngredients> otherIngredients { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Yeasts> Yeasts { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Hops> Hops { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<ClubMembers> ClubMembers { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<ClubComments> ClubComments { get; set; }
        public virtual DbSet<ClubPosts> ClubPosts { get; set; }
    }
}