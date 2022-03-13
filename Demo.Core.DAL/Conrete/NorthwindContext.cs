using Demo.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo.Core.DAL.Conrete
{
    public class NorthwindContext:IdentityDbContext
    {

        public NorthwindContext(DbContextOptions<NorthwindContext> dbContextOptions):base(dbContextOptions)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Northwind; integrated security=true; Trusted_Connection=true;");

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
