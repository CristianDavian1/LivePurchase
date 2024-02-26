using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace DataAcces.ModelsDbAWS;

public partial class LivePurchaseContext : DbContext
{
    private readonly string _connectionString;
    public LivePurchaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public LivePurchaseContext(DbContextOptions<LivePurchaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL(_connectionString);

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
