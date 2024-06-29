using Deserialize_classes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class WeatherDataRepository : DbContext
    {
        private const string ConnectionString = "Data Source=weatherdata.db;";

        public DbSet<Root> weatherDatas { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<List> List { get; set; }
        public DbSet<Main> Main { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Clouds> Cloud { get; set; }
        public DbSet<Wind> Wind { get; set; }
        public DbSet<Sys> Sys { get; set; }
        public DbSet<Coord> Coord { get; set; }

        // Konstruktor klasy
        public WeatherDataRepository()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(ConnectionString);
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Root>()
                .HasOne(r => r.city)
                .WithOne(c => c.Root)
                .HasForeignKey<City>(c => c.RootId);



            modelBuilder.Entity<Root>()
                .HasMany(r => r.list)
                .WithOne(l => l.Root)
                .HasForeignKey(l => l.RootId)
                .IsRequired();
        }
        public void LoadFullWeatherData(List<Root> savedWeatherData)
        {
            foreach (var data in savedWeatherData)
            {
                Entry(data).Reference(x => x.city).Load();
                Entry(data.city).Reference(x => x.coord).Load();
                Entry(data).Collection(x => x.list).Load();

                foreach (var listItem in data.list)
                {
                    Entry(listItem).Reference(x => x.main).Load();
                    Entry(listItem).Collection(x => x.weather).Load();
                    Entry(listItem).Reference(x => x.clouds).Load();
                    Entry(listItem).Reference(x => x.wind).Load();
                    Entry(listItem).Reference(x => x.sys).Load();
                }
            }


        }
    }
}
