using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFTemplate.Models;

namespace EFTemplate.Data
{
    public class EFTemplateContext : DbContext
    {
        public DbSet<Station> Station { get; set; }
        public EFTemplateContext(DbContextOptions<EFTemplateContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>().ToTable("station");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.StationId);
                entity.Property(e => e.StationId).IsRequired().HasColumnName("station_id");
                entity.Property(e => e.Name).IsRequired().HasColumnName("station_name");
                entity.Property(e => e.Address).IsRequired().HasColumnName("station_address");
                entity.Property(e => e.Pricing).HasColumnName("station_pricing");
                entity.Property(e => e.Image).HasColumnName("station_image_url");
                entity.Property(e => e.CreatedOn).HasColumnName("created_on");
                entity.Property(e => e.UpdatedOn).HasColumnName("updated_on");

            });

        }
    }
}
