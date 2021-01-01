using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class FilmsContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FilmRating>(entity =>
            {
                entity.HasIndex(e => e.ExternalId);
                entity.Property(e => e.CreatedOn).UsePropertyAccessMode(PropertyAccessMode.Property);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Data should be persisted to durable database
            optionsBuilder.UseInMemoryDatabase("Films");
        }

        public virtual DbSet<FilmRating> FilmRatings { get; set; }

        public new IQueryable<T> Set<T>() where T : class => base.Set<T>();
    }
}
