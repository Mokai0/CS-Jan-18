﻿using InventoryAppMock1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppMock1
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new
            //DropCreateDatabaseAlways<Context>());
            //Will now be using the custom made initializer
            DatabaseInitializer());
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
            //This makes it so that the table names aren't the plural verison of the classes

            modelBuilder.Entity<Product>()
                .Property(p => p.Quantity)
                .HasPrecision(5, 2);
            //This restricts the precision and scale of the 'Quantity' so that it reads ###.##
        }
    }
}
