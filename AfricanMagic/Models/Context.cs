using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;

namespace AfricanMagic.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext

    {
        public Context() : this("afmagDB") { }
        public Context(string connStringName) : base(connStringName) { }
        static Context()
        {
            // static constructors are guaranteed to only fire once per application.
            // I do this here instead of App_Start so I can avoid including EF
            // in my MVC project (I use UnitOfWork/Repository pattern instead)
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Inventory> Inventories { get; set; }

        public virtual DbSet<Sales> Sale { get; set; }

        // Constructor to use on a DbConnection that is already opened
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}