using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AmritERP.Model
{
    public partial class sampleDBContext : DbContext
    {
        public sampleDBContext()
        {
        }

        public sampleDBContext(DbContextOptions<sampleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBranch> TblBranch { get; set; }
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblLoginType> TblLoginType { get; set; }
        public virtual DbSet<TblLoginTypePages> TblLoginTypePages { get; set; }
        public virtual DbSet<TblMenu> TblMenu { get; set; }
        public virtual DbSet<TblPages> TblPages { get; set; }
        public virtual DbSet<TblState> TblState { get; set; }
        public virtual DbSet<TblStatus> TblStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build(); 
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.ToTable("tblBranch");

                entity.Property(e => e.BranchId).HasColumnName("branchID");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("tblCity");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("cityName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("stateID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblCity)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_tblCity_tblState");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("tblCompany");

                entity.HasIndex(e => e.CompanyGstno)
                    .HasName("IX_tblCompany")
                    .IsUnique();

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.CompanyAddress)
                    .IsRequired()
                    .HasColumnName("companyAddress")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyGstno)
                    .IsRequired()
                    .HasColumnName("companyGSTNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyLogoUrl)
                    .IsRequired()
                    .HasColumnName("companyLogoUrl")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyMobileNo)
                    .IsRequired()
                    .HasColumnName("companyMobileNo")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyStartDate)
                    .HasColumnName("companyStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblCompany)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tblCompany_tblCity");
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("tblDepartment");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("departmentName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployee");

                entity.HasIndex(e => e.EmployeeMobileNo)
                    .HasName("IX_tblEmployee")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.EmployeeAddress)
                    .HasColumnName("employeeAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeBranchId).HasColumnName("employeeBranchID");

                entity.Property(e => e.EmployeeDepartmentId).HasColumnName("employeeDepartmentID");

                entity.Property(e => e.EmployeeGender).HasColumnName("employeeGender");

                entity.Property(e => e.EmployeeMobileNo)
                    .IsRequired()
                    .HasColumnName("employeeMobileNo")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasColumnName("employeeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePhotoUrl)
                    .HasColumnName("employeePhotoUrl")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatusId).HasColumnName("employeeStatusID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LoginId).HasColumnName("loginID");

                entity.HasOne(d => d.EmployeeBranch)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.EmployeeBranchId)
                    .HasConstraintName("FK_tblEmployee_tblBranch");

                entity.HasOne(d => d.EmployeeDepartment)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.EmployeeDepartmentId)
                    .HasConstraintName("FK_tblEmployee_tblDepartment");

                entity.HasOne(d => d.EmployeeStatus)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.EmployeeStatusId)
                    .HasConstraintName("FK_tblEmployee_tblStatus");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK_tblEmployee_tblLogin");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("tblLogin");

                entity.HasIndex(e => e.LoginName)
                    .HasName("IX_tblLogin")
                    .IsUnique();

                entity.Property(e => e.LoginId).HasColumnName("loginID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LastLoginDateTime)
                    .HasColumnName("lastLoginDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasColumnName("loginName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPassword)
                    .IsRequired()
                    .HasColumnName("loginPassword")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoginTypeId).HasColumnName("loginTypeID");

                entity.HasOne(d => d.LoginType)
                    .WithMany(p => p.TblLogin)
                    .HasForeignKey(d => d.LoginTypeId)
                    .HasConstraintName("FK_tblLogin_tblLoginType");
            });

            modelBuilder.Entity<TblLoginType>(entity =>
            {
                entity.HasKey(e => e.LoginTypeId);

                entity.ToTable("tblLoginType");

                entity.Property(e => e.LoginTypeId).HasColumnName("loginTypeID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LoginTypeName)
                    .IsRequired()
                    .HasColumnName("loginTypeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLoginTypePages>(entity =>
            {
                entity.HasKey(e => e.LoginTypePagesId);

                entity.ToTable("tblLoginTypePages");

                entity.Property(e => e.LoginTypePagesId).HasColumnName("loginTypePagesID");

                entity.Property(e => e.LoginTypeId).HasColumnName("loginTypeID");

                entity.Property(e => e.PageId).HasColumnName("pageID");

                entity.HasOne(d => d.LoginType)
                    .WithMany(p => p.TblLoginTypePages)
                    .HasForeignKey(d => d.LoginTypeId)
                    .HasConstraintName("FK_tblLoginTypePages_tblLoginType");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.TblLoginTypePages)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("FK_tblLoginTypePages_tblPages");
            });

            modelBuilder.Entity<TblMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("tblMenu");

                entity.HasIndex(e => e.MenuName)
                    .HasName("IX_tblMenu")
                    .IsUnique();

                entity.Property(e => e.MenuId).HasColumnName("menuID");

                entity.Property(e => e.ColorClass)
                    .IsRequired()
                    .HasColumnName("colorClass")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnName("menuName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SortOrder).HasColumnName("sortOrder");
            });

            modelBuilder.Entity<TblPages>(entity =>
            {
                entity.HasKey(e => e.PageId);

                entity.ToTable("tblPages");

                entity.HasIndex(e => e.PageName)
                    .HasName("IX_tblPages")
                    .IsUnique();

                entity.HasIndex(e => e.PageStateName)
                    .HasName("IX_tblPages_1")
                    .IsUnique();

                entity.Property(e => e.PageId).HasColumnName("pageID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.MenuId).HasColumnName("menuID");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasColumnName("pageName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageOrder).HasColumnName("pageOrder");

                entity.Property(e => e.PageStateName)
                    .IsRequired()
                    .HasColumnName("pageStateName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.TblPages)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_tblPages_tblMenu");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("tblState");

                entity.Property(e => e.StateId).HasColumnName("stateID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnName("stateName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("tblStatus");

                entity.HasIndex(e => e.StatusName)
                    .HasName("IX_tblStatus")
                    .IsUnique();

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.Property(e => e.ColorClass)
                    .IsRequired()
                    .HasColumnName("colorClass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("statusName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
