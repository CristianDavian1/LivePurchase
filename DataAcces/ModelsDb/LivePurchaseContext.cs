using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.ModelsDb;

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
        => optionsBuilder.UseMySQL("server=localhost; database=live_purchase; user=root; pwd=12345;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.AddressUser)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("userName");
            entity.Property(e => e.UserRol)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("userRol");
            entity.Property(e => e.UserType)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("userType");
            entity.Property(e => e.password)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
