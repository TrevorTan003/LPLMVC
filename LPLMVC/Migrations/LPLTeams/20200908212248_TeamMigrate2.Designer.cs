﻿// <auto-generated />
using LPLMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LPLMVC.Migrations.LPLTeams
{
    [DbContext(typeof(LPLTeamsContext))]
    [Migration("20200908212248_TeamMigrate2")]
    partial class TeamMigrate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LPLMVC.Models.TeamDataModel", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<string>("Player1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.ToTable("TeamDataModels");
                });
#pragma warning restore 612, 618
        }
    }
}
