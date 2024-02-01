using Microsoft.EntityFrameworkCore;
using ALevelHomework20._0._0.Models;
using ALevelHomework20._0._0.Configurations;
using ALevelHomework20._0._0.Configuurations;
using ALevelHomework20._0._0.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ALevelHomework20._0._0.Models;

namespace ALevelHomework20._0._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PetEntity> Pets { get; set; } = null!;
        public DbSet<BreedEntity> Breeds { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<LocationEntity> Locations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BreedEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
        }
    }
}
