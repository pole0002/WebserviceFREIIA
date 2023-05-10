﻿// <auto-generated />
using System;
using FREIIA_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FREIIA_API.Migrations
{
    [DbContext(typeof(FREIIAContext))]
    partial class FREIIAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FREIIA_API.Models.Chart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Charts");
                });

            modelBuilder.Entity("FREIIA_API.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RGBA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("FREIIA_API.Models.Connection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConnectionStyleId")
                        .HasColumnType("int");

                    b.Property<int?>("FirstGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("FirstParticipantId")
                        .HasColumnType("int");

                    b.Property<int?>("FirstZoneId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SecondGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondParticipantId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConnectionStyleId");

                    b.HasIndex("FirstGroupId");

                    b.HasIndex("FirstParticipantId");

                    b.HasIndex("FirstZoneId");

                    b.HasIndex("SecondGroupId");

                    b.HasIndex("SecondParticipantId");

                    b.HasIndex("SecondZoneId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("FREIIA_API.Models.ConnectionStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("LineStyleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("LineStyleId");

                    b.ToTable("ConnectionStyles");
                });

            modelBuilder.Entity("FREIIA_API.Models.Expertise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.ToTable("Expertises");
                });

            modelBuilder.Entity("FREIIA_API.Models.ExpertiseParticipant", b =>
                {
                    b.Property<int>("ExpertiseId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMainExpertise")
                        .HasColumnType("bit");

                    b.HasKey("ExpertiseId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("ExpertiseParticipant");
                });

            modelBuilder.Entity("FREIIA_API.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChartId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChartId");

                    b.HasIndex("ColorId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FREIIA_API.Models.LineStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LineStyles");
                });

            modelBuilder.Entity("FREIIA_API.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChartId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactInfoId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChartId");

                    b.HasIndex("ContactInfoId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoleId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("FREIIA_API.Models.ParticipantContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ParticipantContactInfos");
                });

            modelBuilder.Entity("FREIIA_API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FREIIA_API.Models.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChartId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChartId");

                    b.HasIndex("ColorId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("FREIIA_API.Models.Connection", b =>
                {
                    b.HasOne("FREIIA_API.Models.ConnectionStyle", "ConnectionStyle")
                        .WithMany()
                        .HasForeignKey("ConnectionStyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FREIIA_API.Models.Group", "FirstGroup")
                        .WithMany("ConnectionsAsFirstGroup")
                        .HasForeignKey("FirstGroupId");

                    b.HasOne("FREIIA_API.Models.Participant", "FirstParticipant")
                        .WithMany("ConnectionsAsFirstParticipant")
                        .HasForeignKey("FirstParticipantId");

                    b.HasOne("FREIIA_API.Models.Zone", "FirstZone")
                        .WithMany("ConnectionsAsFirstZone")
                        .HasForeignKey("FirstZoneId");

                    b.HasOne("FREIIA_API.Models.Group", "SecondGroup")
                        .WithMany("ConnectionsAsSecondGroup")
                        .HasForeignKey("SecondGroupId");

                    b.HasOne("FREIIA_API.Models.Participant", "SecondParticipant")
                        .WithMany("ConnectionsAsSecondParticipant")
                        .HasForeignKey("SecondParticipantId");

                    b.HasOne("FREIIA_API.Models.Zone", "SecondZone")
                        .WithMany("ConnectionsAsSecondZone")
                        .HasForeignKey("SecondZoneId");

                    b.Navigation("ConnectionStyle");

                    b.Navigation("FirstGroup");

                    b.Navigation("FirstParticipant");

                    b.Navigation("FirstZone");

                    b.Navigation("SecondGroup");

                    b.Navigation("SecondParticipant");

                    b.Navigation("SecondZone");
                });

            modelBuilder.Entity("FREIIA_API.Models.ConnectionStyle", b =>
                {
                    b.HasOne("FREIIA_API.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FREIIA_API.Models.LineStyle", "LineStyle")
                        .WithMany()
                        .HasForeignKey("LineStyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("LineStyle");
                });

            modelBuilder.Entity("FREIIA_API.Models.Expertise", b =>
                {
                    b.HasOne("FREIIA_API.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("FREIIA_API.Models.ExpertiseParticipant", b =>
                {
                    b.HasOne("FREIIA_API.Models.Expertise", "Expertise")
                        .WithMany("ExpertiseParticipants")
                        .HasForeignKey("ExpertiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FREIIA_API.Models.Participant", "Participant")
                        .WithMany("ExpertiseParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Expertise");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("FREIIA_API.Models.Group", b =>
                {
                    b.HasOne("FREIIA_API.Models.Chart", null)
                        .WithMany("Groups")
                        .HasForeignKey("ChartId");

                    b.HasOne("FREIIA_API.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FREIIA_API.Models.Zone", null)
                        .WithMany("Groups")
                        .HasForeignKey("ZoneId");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("FREIIA_API.Models.Participant", b =>
                {
                    b.HasOne("FREIIA_API.Models.Chart", null)
                        .WithMany("Participants")
                        .HasForeignKey("ChartId");

                    b.HasOne("FREIIA_API.Models.ParticipantContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId");

                    b.HasOne("FREIIA_API.Models.Group", null)
                        .WithMany("Participants")
                        .HasForeignKey("GroupId");

                    b.HasOne("FREIIA_API.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FREIIA_API.Models.Zone", null)
                        .WithMany("Participants")
                        .HasForeignKey("ZoneId");

                    b.Navigation("ContactInfo");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FREIIA_API.Models.Role", b =>
                {
                    b.HasOne("FREIIA_API.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("FREIIA_API.Models.Zone", b =>
                {
                    b.HasOne("FREIIA_API.Models.Chart", null)
                        .WithMany("Zones")
                        .HasForeignKey("ChartId");

                    b.HasOne("FREIIA_API.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("FREIIA_API.Models.Chart", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Participants");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("FREIIA_API.Models.Expertise", b =>
                {
                    b.Navigation("ExpertiseParticipants");
                });

            modelBuilder.Entity("FREIIA_API.Models.Group", b =>
                {
                    b.Navigation("ConnectionsAsFirstGroup");

                    b.Navigation("ConnectionsAsSecondGroup");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("FREIIA_API.Models.Participant", b =>
                {
                    b.Navigation("ConnectionsAsFirstParticipant");

                    b.Navigation("ConnectionsAsSecondParticipant");

                    b.Navigation("ExpertiseParticipants");
                });

            modelBuilder.Entity("FREIIA_API.Models.Zone", b =>
                {
                    b.Navigation("ConnectionsAsFirstZone");

                    b.Navigation("ConnectionsAsSecondZone");

                    b.Navigation("Groups");

                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
