using iCategory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace iCategory.DAL
{
    // Enable-Migrations -ContextTypeName DAL.Identity.IdentityDBContext -MigrationsDirectory Migrations
    // Add-Migration -ConfigurationTypeName DAL.Identity.Migrations.Configuration Initial
    // Update-Database -ConfigurationTypeName DAL.Identity.Migrations.Configuration
    // Update-Database -ConfigurationTypeName DAL.Identity.Migrations.Configuration -TargetMigration:0
    public class MyContext : DbContext
    {
        public MyContext() : base ("DefaultConnection")
        {

        }

        public DbSet<Category> CategoryList { get; set; }
        public DbSet<Product> ProductList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}