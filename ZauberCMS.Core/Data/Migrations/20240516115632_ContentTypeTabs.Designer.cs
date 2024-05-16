﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZauberCMS.Core.Data;

#nullable disable

namespace ZauberCMS.Core.Data.Migrations
{
    [DbContext(typeof(ZauberDbContext))]
    [Migration("20240516115632_ContentTypeTabs")]
    partial class ContentTypeTabs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ZauberCMS.Core.Content.Models.Content", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentPropertyData")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<Guid>("ContentTypeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("InternalRedirectId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRootContent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ViewComponent")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContentTypeId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_ZauberContent_Name");

                    b.HasIndex("ParentId");

                    b.HasIndex("Url")
                        .HasDatabaseName("IX_ZauberContent_Url");

                    b.ToTable("ZauberContent", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Content.Models.ContentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("AvailableContentViews")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ContentProperties")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateUpdated")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Tabs")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.HasIndex("Alias")
                        .HasDatabaseName("IX_ZauberContentTypes_Alias");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_ZauberContentTypes_Name");

                    b.ToTable("ZauberContentTypes", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtendedData")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("ZauberRoles", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ZauberRoleClaims", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExtendedData")
                        .IsRequired()
                        .HasMaxLength(3500)
                        .HasColumnType("nvarchar(3500)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("ZauberUsers", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ZauberUserClaims", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("ZauberUserLogins", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ZauberUserRoles", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("ZauberUserTokens", (string)null);
                });

            modelBuilder.Entity("ZauberCMS.Core.Content.Models.Content", b =>
                {
                    b.HasOne("ZauberCMS.Core.Content.Models.ContentType", "ContentType")
                        .WithMany("LinkedContent")
                        .HasForeignKey("ContentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZauberCMS.Core.Content.Models.Content", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ContentType");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.RoleClaim", b =>
                {
                    b.HasOne("ZauberCMS.Core.Membership.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserClaim", b =>
                {
                    b.HasOne("ZauberCMS.Core.Membership.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserLogin", b =>
                {
                    b.HasOne("ZauberCMS.Core.Membership.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserRole", b =>
                {
                    b.HasOne("ZauberCMS.Core.Membership.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZauberCMS.Core.Membership.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.UserToken", b =>
                {
                    b.HasOne("ZauberCMS.Core.Membership.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZauberCMS.Core.Content.Models.Content", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("ZauberCMS.Core.Content.Models.ContentType", b =>
                {
                    b.Navigation("LinkedContent");
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ZauberCMS.Core.Membership.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
