﻿// <auto-generated />
using GamaEdtech.DataSource.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace GamaEdtech.DataSource.Migrations
{
    [DbContext(typeof(GamaEdtechDbContext))]
    [Migration("20250113072848_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GamaEdtech.Domain.Countries.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("GamaEdtech.Domain.Schools.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("School", (string)null);
                });

            modelBuilder.Entity("GamaEdtech.Domain.States.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Code");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("State", (string)null);
                });

            modelBuilder.Entity("GamaEdtech.Domain.Schools.School", b =>
                {
                    b.OwnsOne("GamaEdtech.Domain.Schools.Address", "Address", b1 =>
                        {
                            b1.Property<int>("SchoolId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("AddressCity");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("AddressDescription");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("AddressState");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("AddressZipCode");

                            b1.HasKey("SchoolId");

                            b1.ToTable("School");

                            b1.WithOwner()
                                .HasForeignKey("SchoolId");

                            b1.OwnsOne("GamaEdtech.Domain.Schools.Location", "Location", b2 =>
                                {
                                    b2.Property<int>("AddressSchoolId")
                                        .HasColumnType("int");

                                    b2.Property<Point>("Geography")
                                        .IsRequired()
                                        .HasColumnType("GEOGRAPHY")
                                        .HasColumnName("AddressGeography");

                                    b2.HasKey("AddressSchoolId");

                                    b2.ToTable("School");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressSchoolId");
                                });

                            b1.Navigation("Location")
                                .IsRequired();
                        });

                    b.OwnsOne("GamaEdtech.Domain.Schools.SchoolName", "Name", b1 =>
                        {
                            b1.Property<int>("SchoolId")
                                .HasColumnType("int");

                            b1.Property<string>("InEnglish")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("NameInEnglish");

                            b1.Property<string>("InLocalLanguage")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("NameInLocalLanguage");

                            b1.HasKey("SchoolId");

                            b1.ToTable("School");

                            b1.WithOwner()
                                .HasForeignKey("SchoolId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("GamaEdtech.Domain.States.State", b =>
                {
                    b.HasOne("GamaEdtech.Domain.Countries.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
