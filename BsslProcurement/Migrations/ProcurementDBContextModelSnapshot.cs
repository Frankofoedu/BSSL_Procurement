﻿// <auto-generated />
using System;
using DcProcurement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BsslProcurement.Migrations
{
    [DbContext(typeof(ProcurementDBContext))]
    partial class ProcurementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DcProcurement.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FilePath");

                    b.Property<int?>("RequisitionId");

                    b.HasKey("Id");

                    b.HasIndex("RequisitionId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("DcProcurement.CompanyInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<bool>("Approved");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyRegNo");

                    b.Property<string>("ContactDesignation");

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactPhoneNumber");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("DateEstablishment");

                    b.Property<bool>("Disqualified");

                    b.Property<string>("Email");

                    b.Property<string>("NatureOfBusiness");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalAddress");

                    b.Property<string>("Sector");

                    b.Property<string>("State");

                    b.Property<string>("TIN");

                    b.Property<string>("VendorId");

                    b.HasKey("Id");

                    b.ToTable("CompanyInfo");
                });

            modelBuilder.Entity("DcProcurement.CompanyInfoProcurementSubCategory", b =>
                {
                    b.Property<int>("CompanyInfoId");

                    b.Property<int>("ProcurementSubcategoryId");

                    b.HasKey("CompanyInfoId", "ProcurementSubcategoryId");

                    b.HasIndex("ProcurementSubcategoryId");

                    b.ToTable("CompanyInfoProcurementSubCategory");
                });

            modelBuilder.Entity("DcProcurement.Criteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CriteriaDescription")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("MinValue");

                    b.Property<bool>("NeedsDocument");

                    b.Property<bool>("isCompulsory");

                    b.HasKey("Id");

                    b.ToTable("Criterias");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Criteria");
                });

            modelBuilder.Entity("DcProcurement.EquipmentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyInfoId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("CompanyInfoId");

                    b.ToTable("EquipmentDetails");
                });

            modelBuilder.Entity("DcProcurement.ExperienceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("CompanyInfoId");

                    b.Property<DateTime>("CompletionDate");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ProjectDescription");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyInfoId");

                    b.ToTable("ExperienceRecord");
                });

            modelBuilder.Entity("DcProcurement.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<string>("ItemCode")
                        .IsRequired();

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<int?>("ProcurementSubcategoryId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ProcurementSubcategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DcProcurement.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("Done");

                    b.Property<DateTime?>("DoneDate");

                    b.Property<string>("Remark");

                    b.Property<string>("StaffId");

                    b.Property<int>("WorkFlowStep");

                    b.HasKey("Id");

                    b.ToTable("Jobs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Job");
                });

            modelBuilder.Entity("DcProcurement.PRNo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastUsedSerialNo");

                    b.Property<string>("RequisitionCode");

                    b.HasKey("Id");

                    b.ToTable("PRNos");
                });

            modelBuilder.Entity("DcProcurement.PersonnelDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CV");

                    b.Property<string>("Certificate");

                    b.Property<int?>("CompanyInfoId");

                    b.Property<string>("Name");

                    b.Property<string>("Passport");

                    b.Property<string>("Qualification");

                    b.Property<int>("VerificationState");

                    b.HasKey("Id");

                    b.HasIndex("CompanyInfoId");

                    b.ToTable("PersonnelDetails");
                });

            modelBuilder.Entity("DcProcurement.PrequalificationPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NoOfCategory");

                    b.Property<DateTime>("PrequalificationEndDate");

                    b.Property<DateTime>("PrequalificationStartDate");

                    b.HasKey("Id");

                    b.ToTable("PrequalificationPolicies");
                });

            modelBuilder.Entity("DcProcurement.ProcurementCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ProcurementCategoryCode");

                    b.HasKey("Id");

                    b.ToTable("ProcurementCategories");
                });

            modelBuilder.Entity("DcProcurement.ProcurementGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ClosingDate");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<string>("GroupName");

                    b.Property<int>("NoOfCategory");

                    b.Property<DateTime?>("OpeningDate");

                    b.HasKey("Id");

                    b.ToTable("ProcurementGroups");
                });

            modelBuilder.Entity("DcProcurement.ProcurementItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAdded");

                    b.Property<string>("Info");

                    b.Property<int?>("ItemId");

                    b.Property<int?>("ProcurementGroupId");

                    b.Property<int?>("ProcurementSubcategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ProcurementGroupId");

                    b.HasIndex("ProcurementSubcategoryId");

                    b.ToTable("ProcurementItems");
                });

            modelBuilder.Entity("DcProcurement.ProcurementPortalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Legal");

                    b.Property<string>("PortalLogo");

                    b.Property<string>("PortalName");

                    b.HasKey("Id");

                    b.ToTable("ProcurementPortalInfo");
                });

            modelBuilder.Entity("DcProcurement.ProcurementSubcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ProcurementCategoryId");

                    b.Property<string>("ProcurementSubCategoryCode");

                    b.HasKey("Id");

                    b.HasIndex("ProcurementCategoryId");

                    b.ToTable("ProcurementSubcategories");
                });

            modelBuilder.Entity("DcProcurement.Requisition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .IsRequired();

                    b.Property<DateTime?>("DeliveryDate")
                        .IsRequired();

                    b.Property<string>("PRNumber")
                        .IsRequired();

                    b.Property<string>("PreparedBy")
                        .IsRequired();

                    b.Property<string>("PreparedByRank");

                    b.Property<string>("PreparedFor")
                        .IsRequired();

                    b.Property<string>("PreparedForRank");

                    b.Property<string>("ProcurementType")
                        .IsRequired();

                    b.Property<string>("Purpose");

                    b.Property<string>("RequesterType")
                        .IsRequired();

                    b.Property<string>("RequesterValue")
                        .IsRequired();

                    b.Property<string>("RequiredAtDepartment")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Requisitions");
                });

            modelBuilder.Entity("DcProcurement.RequisitionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Quantity");

                    b.Property<int?>("RequisitionId");

                    b.Property<string>("StoreItemCode");

                    b.Property<string>("UnitOfMeasurement");

                    b.Property<double>("UnitPrice");

                    b.Property<string>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("RequisitionId");

                    b.HasIndex("VendorId");

                    b.ToTable("RequisitionItems");
                });

            modelBuilder.Entity("DcProcurement.SubmittedCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyInfoId");

                    b.Property<int>("CriteriaId");

                    b.Property<string>("Value");

                    b.Property<int>("VerificationState");

                    b.HasKey("Id");

                    b.HasIndex("CompanyInfoId");

                    b.HasIndex("CriteriaId");

                    b.ToTable("SubmittedCriteria");
                });

            modelBuilder.Entity("DcProcurement.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("DcProcurement.Workflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternativeStaffId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("StaffId");

                    b.Property<int>("Step");

                    b.Property<double>("Threshold");

                    b.Property<bool>("ToPersonOrAssign");

                    b.Property<int?>("WorkflowActionId");

                    b.Property<int?>("WorkflowCategoryId");

                    b.Property<int?>("WorkflowTypeId");

                    b.HasKey("Id");

                    b.HasIndex("AlternativeStaffId");

                    b.HasIndex("StaffId");

                    b.HasIndex("WorkflowActionId");

                    b.HasIndex("WorkflowTypeId");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("DcProcurement.WorkflowAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("WorkflowActions");
                });

            modelBuilder.Entity("DcProcurement.WorkflowType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("WorkflowTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DcProcurement.CategoryCriteria", b =>
                {
                    b.HasBaseType("DcProcurement.Criteria");

                    b.Property<int?>("ProcurementCategoryId");

                    b.HasIndex("ProcurementCategoryId");

                    b.HasDiscriminator().HasValue("CategoryCriteria");
                });

            modelBuilder.Entity("DcProcurement.ItemCriteria", b =>
                {
                    b.HasBaseType("DcProcurement.Criteria");

                    b.Property<int?>("ItemId");

                    b.HasIndex("ItemId");

                    b.HasDiscriminator().HasValue("ItemCriteria");
                });

            modelBuilder.Entity("DcProcurement.SubCategoryCriteria", b =>
                {
                    b.HasBaseType("DcProcurement.Criteria");

                    b.Property<int?>("ProcurementSubcategoryId");

                    b.HasIndex("ProcurementSubcategoryId");

                    b.HasDiscriminator().HasValue("SubCategoryCriteria");
                });

            modelBuilder.Entity("DcProcurement.PrequalificationJob", b =>
                {
                    b.HasBaseType("DcProcurement.Job");

                    b.Property<int>("CompanyInfoId");

                    b.HasIndex("CompanyInfoId");

                    b.HasIndex("StaffId");

                    b.HasDiscriminator().HasValue("PrequalificationJob");
                });

            modelBuilder.Entity("DcProcurement.Staff", b =>
                {
                    b.HasBaseType("DcProcurement.User");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Position")
                        .IsRequired();

                    b.Property<string>("StaffCode")
                        .IsRequired();

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("DcProcurement.VendorUser", b =>
                {
                    b.HasBaseType("DcProcurement.User");

                    b.Property<int?>("CompanyInfoId");

                    b.HasIndex("CompanyInfoId")
                        .IsUnique()
                        .HasFilter("[CompanyInfoId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("VendorUser");
                });

            modelBuilder.Entity("DcProcurement.Attachment", b =>
                {
                    b.HasOne("DcProcurement.Requisition")
                        .WithMany("Attachments")
                        .HasForeignKey("RequisitionId");
                });

            modelBuilder.Entity("DcProcurement.CompanyInfoProcurementSubCategory", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithMany("CompanyInfoSelectedSubcategory")
                        .HasForeignKey("CompanyInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DcProcurement.ProcurementSubcategory", "ProcurementSubcategory")
                        .WithMany("CompanyInfos")
                        .HasForeignKey("ProcurementSubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DcProcurement.EquipmentDetails", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithMany("EquipmentDetails")
                        .HasForeignKey("CompanyInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DcProcurement.ExperienceRecord", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithMany("ExperienceRecords")
                        .HasForeignKey("CompanyInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DcProcurement.Item", b =>
                {
                    b.HasOne("DcProcurement.ProcurementSubcategory", "ProcurementSubcategory")
                        .WithMany()
                        .HasForeignKey("ProcurementSubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DcProcurement.PersonnelDetails", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithMany("PersonnelDetails")
                        .HasForeignKey("CompanyInfoId");
                });

            modelBuilder.Entity("DcProcurement.ProcurementItem", b =>
                {
                    b.HasOne("DcProcurement.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("DcProcurement.ProcurementGroup", "ProcurementGroup")
                        .WithMany("ProcurementItems")
                        .HasForeignKey("ProcurementGroupId");

                    b.HasOne("DcProcurement.ProcurementSubcategory")
                        .WithMany("ProcurementItems")
                        .HasForeignKey("ProcurementSubcategoryId");
                });

            modelBuilder.Entity("DcProcurement.ProcurementSubcategory", b =>
                {
                    b.HasOne("DcProcurement.ProcurementCategory", "ProcurementCategory")
                        .WithMany("ProcurementSubcategories")
                        .HasForeignKey("ProcurementCategoryId");
                });

            modelBuilder.Entity("DcProcurement.RequisitionItem", b =>
                {
                    b.HasOne("DcProcurement.Requisition", "Requisition")
                        .WithMany("RequisitionItems")
                        .HasForeignKey("RequisitionId");

                    b.HasOne("DcProcurement.VendorUser", "Vendor")
                        .WithMany("RequisitionItems")
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("DcProcurement.SubmittedCriteria", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithMany("SubmittedCriterias")
                        .HasForeignKey("CompanyInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DcProcurement.Criteria", "Criteria")
                        .WithMany()
                        .HasForeignKey("CriteriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DcProcurement.Workflow", b =>
                {
                    b.HasOne("DcProcurement.Staff", "AlternativeStaffToAssign")
                        .WithMany("AdditionalStaffWorkflows")
                        .HasForeignKey("AlternativeStaffId");

                    b.HasOne("DcProcurement.Staff", "StaffToAssign")
                        .WithMany("StaffWorkflows")
                        .HasForeignKey("StaffId");

                    b.HasOne("DcProcurement.WorkflowAction", "WorkflowAction")
                        .WithMany("Workflows")
                        .HasForeignKey("WorkflowActionId");

                    b.HasOne("DcProcurement.WorkflowType", "WorkflowType")
                        .WithMany("Workflows")
                        .HasForeignKey("WorkflowTypeId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DcProcurement.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DcProcurement.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DcProcurement.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DcProcurement.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DcProcurement.CategoryCriteria", b =>
                {
                    b.HasOne("DcProcurement.ProcurementCategory", "ProcurementCategory")
                        .WithMany("CategoryCriterias")
                        .HasForeignKey("ProcurementCategoryId");
                });

            modelBuilder.Entity("DcProcurement.ItemCriteria", b =>
                {
                    b.HasOne("DcProcurement.Item", "Item")
                        .WithMany("ItemCriterias")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("DcProcurement.SubCategoryCriteria", b =>
                {
                    b.HasOne("DcProcurement.ProcurementSubcategory", "ProcurementSubcategory")
                        .WithMany("SubCategoryCriterias")
                        .HasForeignKey("ProcurementSubcategoryId");
                });

            modelBuilder.Entity("DcProcurement.PrequalificationJob", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithMany("PrequalificationJobs")
                        .HasForeignKey("CompanyInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DcProcurement.Staff", "Staff")
                        .WithMany("AssignedPrequalificationJobs")
                        .HasForeignKey("StaffId");
                });

            modelBuilder.Entity("DcProcurement.VendorUser", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithOne("Vendor")
                        .HasForeignKey("DcProcurement.VendorUser", "CompanyInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
