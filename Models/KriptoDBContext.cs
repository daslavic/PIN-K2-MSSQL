using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PinKripto05.Models
{
    public partial class KriptoDBContext : DbContext
    {
        public KriptoDBContext()
        {
        }

        public KriptoDBContext(DbContextOptions<KriptoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KriptoTrades> KriptoTrades { get; set; }
        public virtual DbSet<Prod> Prod { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KriptoTrades>(entity =>
            {
                entity.HasKey(e => e.KriptoName)
                    .HasName("PK__KriptoTr__39C7C83293C3D50B");

                entity.Property(e => e.KriptoName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Change1h).HasColumnName("Change_1H");

                entity.Property(e => e.Change24h).HasColumnName("Change_24H");

                entity.Property(e => e.Change7d).HasColumnName("Change_7D");

                entity.Property(e => e.DatumUnosa).HasColumnType("datetime");

                entity.Property(e => e.KriptoId)
                    .HasColumnName("KriptoID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Symbol)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usd)
                    .HasColumnName("USD")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Prod>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Prod__737584F733544883");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CDABDF786A");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
