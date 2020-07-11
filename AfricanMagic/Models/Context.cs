using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace AfricanMagic.Models
{
    public class Context : DbContext
    {
        // public Context() : base("name = ContextDB") { }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Inventory> Inventories { get; set; }

        public virtual DbSet<Sales> Sale { get; set; }
    }

}