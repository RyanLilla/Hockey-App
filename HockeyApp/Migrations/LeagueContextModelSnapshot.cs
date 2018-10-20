﻿// <auto-generated />
using System;
using HockeyApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HockeyApp.Migrations
{
    [DbContext(typeof(LeagueContext))]
    partial class LeagueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HockeyApp.Models.Coach", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("HockeyApp.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachID");

                    b.Property<DateTime>("DraftDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("Position");

                    b.Property<int>("TeamID");

                    b.HasKey("ID");

                    b.HasIndex("CoachID");

                    b.HasIndex("TeamID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("HockeyApp.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachID");

                    b.Property<string>("TeamLocation");

                    b.Property<string>("TeamName");

                    b.HasKey("ID");

                    b.HasIndex("CoachID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("HockeyApp.Models.Player", b =>
                {
                    b.HasOne("HockeyApp.Models.Coach", "Coach")
                        .WithMany("Players")
                        .HasForeignKey("CoachID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HockeyApp.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HockeyApp.Models.Team", b =>
                {
                    b.HasOne("HockeyApp.Models.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachID");
                });
#pragma warning restore 612, 618
        }
    }
}
