using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Service.Entity
{
    public class VehicleContext: DbContext
    {
        public VehicleContext() : base("name=SchoolDBConnectionString")
        {
            Database.SetInitializer<VehicleContext>(new CreateDatabaseIfNotExists<VehicleContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        // tables/entities
        public DbSet<VehicleMake> VehicleMakes { get; set; }


        public DbSet<VehicleModel> VehicleModels { get; set; }



    }
}