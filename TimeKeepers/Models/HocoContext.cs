using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepers.Models
{
    public class HocoContext : DbContext
    {
        //public HocoContext() : base("HocoDB")
        //{
        //    Database.SetInitializer<HocoContext>(new DropCreateDatabaseIfModelChanges<HocoContext>());
        //}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Timecard> Timecards { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=homecoming.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
