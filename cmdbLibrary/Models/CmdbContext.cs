using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cmdbLibrary.Models
{
    public partial class CmdbContext : DbContext
    {
        public CmdbContext()
        {
        }

        public CmdbContext(DbContextOptions<CmdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=cmdb;user=root;password=ruru", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermisionId)
                    .HasName("PRIMARY");

                entity.ToTable("permission");

                entity.HasComment("權限列表");

                entity.Property(e => e.PermisionId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PermissionDes)
                    .HasMaxLength(50)
                    .HasComment("權限描述");

                entity.Property(e => e.PermissionName).HasMaxLength(45);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasComment("角色定義");

                entity.HasIndex(e => e.RoleId, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.CreateBy).HasComment("新增使用者");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("新增時間");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改時間");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RolePermissionId, e.RoleId, e.PermisionId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("role_permission");

                entity.HasComment("角色權限");

                entity.HasIndex(e => e.PermisionId, "FK_Permission");

                entity.HasIndex(e => e.RoleId, "FK_Role_idx");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Permision)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasComment("使用者");

                entity.HasIndex(e => e.RoleId, "FK_UserRole_idx");

                entity.HasIndex(e => new { e.UserId, e.RoleId }, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasComment("使用者ID");

                entity.Property(e => e.CreateBy).HasComment("新增使用者");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("新增時間");

                entity.Property(e => e.DeleteBy).HasComment("刪除使用者");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasComment("聯絡信箱")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'")
                    .HasComment("已啟用");

                entity.Property(e => e.IsDelete).HasComment("已刪除");

                entity.Property(e => e.IsVarify).HasComment("已驗證");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .HasComment("連絡電話")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ModifyTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改時間");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("'0000'")
                    .HasComment("密碼")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RoleId).HasComment("使用者角色");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("使用者名稱")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.ToTable("user_permission");

                entity.HasComment("使用者權限");

                entity.HasIndex(e => e.UserId, "FK_UserIdPermission");

                entity.HasIndex(e => e.PermisionId, "FK_UserPermissionId");

                entity.Property(e => e.UserPermissionId).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .HasMaxLength(45)
                    .HasColumnName("isActive");

                entity.HasOne(d => d.Permision)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.PermisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPermissionId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserIdPermission");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
