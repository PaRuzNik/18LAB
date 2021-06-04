using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class SomeData : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<HomeList> HomeLists { get; set; }

        public DbSet<CarPrice> CarPrices { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Journey> Journeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server = PASHACOMP; Database = Lab18; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

    }
}
