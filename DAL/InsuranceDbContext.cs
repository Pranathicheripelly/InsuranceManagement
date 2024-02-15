using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext() : base("Insurance")
        {

        }
        //DbSet is a class in the Entity Framework that represents an entity set, which is a collection of entities
        public DbSet<Admin> Admins { get; set; }//This allows you to work with the Admin entities in your application and
                                                //perform database operations using Entity Framework.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Questions> Questions { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure primary key for Questions entity
           

            // Other configurations...
          
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<AppliedPolicy> AppliedPolicies { get; set; }

        public DbSet<Answer> Answers { get; set; }
        

    }
}
