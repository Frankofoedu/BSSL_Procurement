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
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DcProcurement.CompanyInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyRegNo");

                    b.Property<string>("ContactDesignation");

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactPhoneNumber");

                    b.Property<DateTime>("DateEstablishment");

                    b.Property<string>("Email");

                    b.Property<string>("NatureOfBusiness");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalAddress");

                    b.Property<string>("Sector");

                    b.Property<string>("State");

                    b.Property<string>("TIN");

                    b.HasKey("Id");

                    b.ToTable("CompanyInfo");
                });

            modelBuilder.Entity("DcProcurement.Criteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CriteriaDescription");

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

            modelBuilder.Entity("DcProcurement.JoinTables.CompanyInfoProcurementSubCategory", b =>
                {
                    b.Property<int>("CompanyInfoId");

                    b.Property<int>("ProcurementSubcategoryId");

                    b.HasKey("CompanyInfoId", "ProcurementSubcategoryId");

                    b.HasIndex("ProcurementSubcategoryId");

                    b.ToTable("CompanyInfoProcurementSubCategory");
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

            modelBuilder.Entity("DcProcurement.ProcurementCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CriteriaDescription")
                        .IsRequired();

                    b.Property<int?>("MinValue");

                    b.Property<bool>("NeedsDocument");

                    b.Property<int?>("ProcurementItemId");

                    b.Property<bool>("isCompulsory");

                    b.HasKey("Id");

                    b.HasIndex("ProcurementItemId");

                    b.ToTable("ProcurementCriteria");
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

                    b.Property<string>("Description");

                    b.Property<string>("ItemCode");

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<int?>("ProcurementGroupId");

                    b.Property<int?>("ProcurementSubcategoryId");

                    b.HasKey("Id");

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

            modelBuilder.Entity("DcProcurement.SubmittedCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyInfoId");

                    b.Property<int>("CriteriaId");

                    b.Property<int>("MyProperty");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CompanyInfoId");

                    b.HasIndex("CriteriaId");

                    b.ToTable("SubmittedCriteria");
                });

            modelBuilder.Entity("DcProcurement.CategoryCriteria", b =>
                {
                    b.HasBaseType("DcProcurement.Criteria");

                    b.Property<int?>("ProcurementCategoryId");

                    b.HasIndex("ProcurementCategoryId");

                    b.ToTable("CategoryCriteria");

                    b.HasDiscriminator().HasValue("CategoryCriteria");
                });

            modelBuilder.Entity("DcProcurement.ItemCriteria", b =>
                {
                    b.HasBaseType("DcProcurement.Criteria");

                    b.Property<int?>("ProcurementItemId");

                    b.HasIndex("ProcurementItemId");

                    b.ToTable("ItemCriteria");

                    b.HasDiscriminator().HasValue("ItemCriteria");
                });

            modelBuilder.Entity("DcProcurement.SubCategoryCriteria", b =>
                {
                    b.HasBaseType("DcProcurement.Criteria");

                    b.Property<int?>("ProcurementSubcategoryId");

                    b.HasIndex("ProcurementSubcategoryId");

                    b.ToTable("SubCategoryCriteria");

                    b.HasDiscriminator().HasValue("SubCategoryCriteria");
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

            modelBuilder.Entity("DcProcurement.JoinTables.CompanyInfoProcurementSubCategory", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo", "CompanyInfo")
                        .WithMany("CompanyInfos")
                        .HasForeignKey("CompanyInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DcProcurement.ProcurementSubcategory", "ProcurementSubcategory")
                        .WithMany("CompanyInfos")
                        .HasForeignKey("ProcurementSubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DcProcurement.PersonnelDetails", b =>
                {
                    b.HasOne("DcProcurement.CompanyInfo")
                        .WithMany("PersonnelDetails")
                        .HasForeignKey("CompanyInfoId");
                });

            modelBuilder.Entity("DcProcurement.ProcurementCriteria", b =>
                {
                    b.HasOne("DcProcurement.ProcurementItem", "ProcurementItem")
                        .WithMany("ProcurementCriterias")
                        .HasForeignKey("ProcurementItemId");
                });

            modelBuilder.Entity("DcProcurement.ProcurementItem", b =>
                {
                    b.HasOne("DcProcurement.ProcurementGroup", "ProcurementGroup")
                        .WithMany("ProcurementItems")
                        .HasForeignKey("ProcurementGroupId");

                    b.HasOne("DcProcurement.ProcurementSubcategory", "ProcurementSubcategory")
                        .WithMany("ProcurementItems")
                        .HasForeignKey("ProcurementSubcategoryId");
                });

            modelBuilder.Entity("DcProcurement.ProcurementSubcategory", b =>
                {
                    b.HasOne("DcProcurement.ProcurementCategory", "ProcurementCategory")
                        .WithMany("ProcurementSubcategories")
                        .HasForeignKey("ProcurementCategoryId");
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

            modelBuilder.Entity("DcProcurement.CategoryCriteria", b =>
                {
                    b.HasOne("DcProcurement.ProcurementCategory", "ProcurementCategory")
                        .WithMany()
                        .HasForeignKey("ProcurementCategoryId");
                });

            modelBuilder.Entity("DcProcurement.ItemCriteria", b =>
                {
                    b.HasOne("DcProcurement.ProcurementItem", "ProcurementItem")
                        .WithMany()
                        .HasForeignKey("ProcurementItemId");
                });

            modelBuilder.Entity("DcProcurement.SubCategoryCriteria", b =>
                {
                    b.HasOne("DcProcurement.ProcurementSubcategory", "ProcurementSubcategory")
                        .WithMany()
                        .HasForeignKey("ProcurementSubcategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
