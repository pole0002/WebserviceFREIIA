﻿// <auto-generated />
using System;
using FREIIA_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FREIIA_API.Migrations
{
    [DbContext(typeof(FREIIAContext))]
    [Migration("20230424094219_AddedRolesAndExpertiseNUllable")]
    partial class AddedRolesAndExpertiseNUllable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ExpertiseParticipant", b =>
                {
                    b.Property<int>("ExpertisesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExpertisesId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("ExpertiseParticipant");
                });

            modelBuilder.Entity("FREIIA_API.Models.Chart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Charts");
                });

            modelBuilder.Entity("FREIIA_API.Models.Connection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConnectionStyleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FirstGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FirstParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FirstZoneId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SecondGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SecondParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SecondZoneId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Font")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LineStyle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ConnectionStyles");
                });

            modelBuilder.Entity("FREIIA_API.Models.Expertise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Expertises");
                });

            modelBuilder.Entity("FREIIA_API.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChartId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChartId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FREIIA_API.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChartId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContactInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FromCompany")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ParticipantContactInfos");
                });

            modelBuilder.Entity("FREIIA_API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FREIIA_API.Models.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChartId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChartId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("ExpertiseParticipant", b =>
                {
                    b.HasOne("FREIIA_API.Models.Expertise", null)
                        .WithMany()
                        .HasForeignKey("ExpertisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FREIIA_API.Models.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("FREIIA_API.Models.Group", b =>
                {
                    b.HasOne("FREIIA_API.Models.Chart", null)
                        .WithMany("Groups")
                        .HasForeignKey("ChartId");

                    b.HasOne("FREIIA_API.Models.Zone", null)
                        .WithMany("Groups")
                        .HasForeignKey("ZoneId");
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

            modelBuilder.Entity("FREIIA_API.Models.Zone", b =>
                {
                    b.HasOne("FREIIA_API.Models.Chart", null)
                        .WithMany("Zones")
                        .HasForeignKey("ChartId");
                });

            modelBuilder.Entity("FREIIA_API.Models.Chart", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Participants");

                    b.Navigation("Zones");
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