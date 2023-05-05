﻿// <auto-generated />
using System;
using FREIIA_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

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

            modelBuilder.Entity("FREIIA_API.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RGBA")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Color");
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

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LineStyleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("LineStyleId");

                    b.ToTable("ConnectionStyles");
                });

            modelBuilder.Entity("FREIIA_API.Models.Expertise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.ToTable("Expertises");
                });

            modelBuilder.Entity("FREIIA_API.Models.ExpertiseParticipant", b =>
                {
                    b.Property<int>("ExpertiseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMainExpertise")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExpertiseId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("ExpertiseParticipants");
                });

            modelBuilder.Entity("FREIIA_API.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LineStyle");
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

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FREIIA_API.Models.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
                        .OnDelete(DeleteBehavior.Cascade)
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
