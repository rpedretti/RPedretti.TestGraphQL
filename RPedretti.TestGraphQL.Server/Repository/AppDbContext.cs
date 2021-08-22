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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
