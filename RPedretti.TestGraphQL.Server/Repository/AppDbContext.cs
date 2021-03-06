using Microsoft.EntityFrameworkCore;
using RPedretti.TestGraphQL.Server.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<ProductTypeDTO> ProductTypes { get; set; }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<CmsItem> Cms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureProduct(modelBuilder);
            ConfigureProductType(modelBuilder);
            ConfigureCms(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureCms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmsItem>()
                .ToTable("cms");

            modelBuilder.Entity<CmsItem>()
                .Property(c => c.CmsId)
                .HasColumnName("cms_id");

            modelBuilder.Entity<CmsItem>()
                .Property(c => c.LanguageId)
                .HasColumnName("language_id");

            modelBuilder.Entity<CmsItem>()
                .Property(c => c.Text)
                .HasColumnName("text");

            modelBuilder.Entity<CmsItem>()
                .HasKey(c =>  new { c.CmsId, c.LanguageId });
        }

        private static void ConfigureProductType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTypeDTO>()
                .ToTable("product_type");

            modelBuilder.Entity<ProductTypeDTO>()
                .Property(e => e.ProductTypeName)
                .HasColumnName("product_type_name");

            modelBuilder.Entity<ProductTypeDTO>()
                .Property(e => e.ProductTypeId)
                .HasColumnName("product_type_id");

            modelBuilder.Entity<ProductTypeDTO>()
                .HasKey(e => e.ProductTypeId);
        }

        private static void ConfigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDTO>()
                            .ToTable("product");

            modelBuilder.Entity<ProductDTO>()
                .Property(e => e.ProductId)
                .HasColumnName("product_id");

            modelBuilder.Entity<ProductDTO>()
                .Property(e => e.ProductName)
                .HasColumnName("product_name");

            modelBuilder.Entity<ProductDTO>()
                .Property(e => e.ProductTypeId)
                .HasColumnName("product_type_id");

            modelBuilder.Entity<ProductDTO>()
                .HasKey(e => e.ProductId);
        }
    }
}
