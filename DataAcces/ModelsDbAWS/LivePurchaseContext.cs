using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.ModelsDbAWS;

public partial class LivePurchaseContext : DbContext
{
    public LivePurchaseContext()
    {
    }

    public LivePurchaseContext(DbContextOptions<LivePurchaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=livepurchase.cgru5rtzovge.us-east-1.rds.amazonaws.com; database=livePurchase; user=cristiandavian1; pwd=789456123Calvo.;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("user");

            entity.Property(e => e.AddressUser)
                .HasMaxLength(255)
                .HasColumnName("addressUser");
            entity.Property(e => e.Document)
                .HasMaxLength(255)
                .HasColumnName("document");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastNames)
                .HasMaxLength(255)
                .HasColumnName("lastNames");
            entity.Property(e => e.Names)
                .HasMaxLength(255)
                .HasColumnName("names");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasColumnName("password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("userName");
            entity.Property(e => e.UserRol)
                .HasMaxLength(255)
                .HasColumnName("userRol");
            entity.Property(e => e.UserType)
                .HasMaxLength(255)
                .HasColumnName("userType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
