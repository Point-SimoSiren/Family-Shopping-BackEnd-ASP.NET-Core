using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShoppingBackendAPI.Models
{
    public partial class shoppingdbContext : DbContext
    {
        public shoppingdbContext()
        {
        }

        public shoppingdbContext(DbContextOptions<shoppingdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=duuniserver.database.windows.net,1433;Database=shoppingdb;User ID = sirensimo; Password=Fullstack7777!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeAdded).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
