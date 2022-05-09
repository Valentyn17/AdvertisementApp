using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Context
{
    public class AdvertisementDBContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<PhotoLink> PhotoLinks { get; set; }
        public AdvertisementDBContext()
        {

        }
        public AdvertisementDBContext(DbContextOptions<AdvertisementDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AdvertismentDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
    }
