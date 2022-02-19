﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using helperland_1.Models;

#nullable disable

namespace helperland_1.Data
{
    public partial class helperlandContext : DbContext
    {
        public helperlandContext()
        {
        }

        public helperlandContext(DbContextOptions<helperlandContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<FavoriteAndBlocked> FavoriteAndBlockeds { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<ServiceRequestAddress> ServiceRequestAddresses { get; set; }
        public virtual DbSet<ServiceRequestExtra> ServiceRequestExtras { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<Zipcode> Zipcodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-R0O2A5G; database=helperland; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasKey(e => e.ContactUsId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Subject).HasMaxLength(500);

                entity.Property(e => e.UploadFileName).HasMaxLength(100);
            });

            modelBuilder.Entity<FavoriteAndBlocked>(entity =>
            {
                entity.ToTable("FavoriteAndBlocked");

                entity.HasOne(d => d.TargetUser)
                    .WithMany(p => p.FavoriteAndBlockedTargetUsers)
                    .HasForeignKey(d => d.TargetUserId)
                    .HasConstraintName("FK_FavoriteAndBlocked_User");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteAndBlockedUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavoriteAndBlocked_FavoriteAndBlocked");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Comments).HasMaxLength(2000);

                entity.Property(e => e.Friendly)
                    .HasColumnType("decimal(2, 1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OnTimeArrival)
                    .HasColumnType("decimal(2, 1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QualityOfService)
                    .HasColumnType("decimal(2, 1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RatingDate).HasColumnType("datetime");

                entity.Property(e => e.Ratings).HasColumnType("decimal(2, 1)");

                entity.HasOne(d => d.RatingFromNavigation)
                    .WithMany(p => p.RatingRatingFromNavigations)
                    .HasForeignKey(d => d.RatingFrom)
                    .HasConstraintName("FK_Rating_User");

                entity.HasOne(d => d.RatingToNavigation)
                    .WithMany(p => p.RatingRatingToNavigations)
                    .HasForeignKey(d => d.RatingTo)
                    .HasConstraintName("FK_Rating_User1");

                entity.HasOne(d => d.ServiceRequest)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ServiceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_ServiceRequest");
            });

            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.ToTable("ServiceRequest");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Distance)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasPets).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentDue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentTransactionRefNo).HasMaxLength(50);

                entity.Property(e => e.RefundedAmount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ServiceHourlyRate).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");

                entity.Property(e => e.SpacceptedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SPAcceptedDate");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.ServiceProvider)
                    .WithMany(p => p.ServiceRequestServiceProviders)
                    .HasForeignKey(d => d.ServiceProviderId)
                    .HasConstraintName("FK_ServiceRequest_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceRequestUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceRequest_User");
            });

            modelBuilder.Entity<ServiceRequestAddress>(entity =>
            {
                entity.ToTable("ServiceRequestAddress");

                entity.Property(e => e.AddressLine1).HasMaxLength(200);

                entity.Property(e => e.AddressLine2).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.ServiceRequest)
                    .WithMany(p => p.ServiceRequestAddresses)
                    .HasForeignKey(d => d.ServiceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceRequestAddress_ServiceRequest");
            });

            modelBuilder.Entity<ServiceRequestExtra>(entity =>
            {
                entity.ToTable("ServiceRequestExtra");

                entity.HasOne(d => d.ServiceRequest)
                    .WithMany(p => p.ServiceRequestExtras)
                    .HasForeignKey(d => d.ServiceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceRequestExtra_ServiceRequest");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.BankTokenId).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRegisteredUser).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PaymentGatewayUserRef).HasMaxLength(200);

                entity.Property(e => e.TaxNo).HasMaxLength(50);

                entity.Property(e => e.UserProfilePicture).HasMaxLength(200);

                entity.Property(e => e.WorksWithPets).HasDefaultValueSql("((0))");

                entity.Property(e => e.ZipCode).HasMaxLength(20);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK_UserAddresses");

                entity.ToTable("UserAddress");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AddressLine2).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.IsDefault).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddresses_User");
            });

            modelBuilder.Entity<Zipcode>(entity =>
            {
                entity.ToTable("Zipcode");

                entity.Property(e => e.ZipcodeValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Zipcodes)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zipcode_City");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
