﻿// <auto-generated />
using System;
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp1.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20201218154906_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ConsoleApp1.Dependent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("ConsoleApp1.Primary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DependentFirstId")
                        .HasColumnType("int");

                    b.Property<int?>("DependentSecondId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TertiaryFirstId")
                        .HasColumnType("int");

                    b.Property<int?>("TertiarySecondId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DependentFirstId");

                    b.HasIndex("DependentSecondId");

                    b.HasIndex("TertiaryFirstId");

                    b.HasIndex("TertiarySecondId");

                    b.ToTable("Primaries");
                });

            modelBuilder.Entity("ConsoleApp1.Tertiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DependentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrimaryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DependentId");

                    b.HasIndex("PrimaryId");

                    b.ToTable("Tertiary");
                });

            modelBuilder.Entity("ConsoleApp1.Primary", b =>
                {
                    b.HasOne("ConsoleApp1.Dependent", "DependentFirst")
                        .WithMany()
                        .HasForeignKey("DependentFirstId");

                    b.HasOne("ConsoleApp1.Dependent", "DependentSecond")
                        .WithMany()
                        .HasForeignKey("DependentSecondId");

                    b.HasOne("ConsoleApp1.Tertiary", "TertiaryFirst")
                        .WithMany()
                        .HasForeignKey("TertiaryFirstId");

                    b.HasOne("ConsoleApp1.Tertiary", "TertiarySecond")
                        .WithMany()
                        .HasForeignKey("TertiarySecondId");

                    b.Navigation("DependentFirst");

                    b.Navigation("DependentSecond");

                    b.Navigation("TertiaryFirst");

                    b.Navigation("TertiarySecond");
                });

            modelBuilder.Entity("ConsoleApp1.Tertiary", b =>
                {
                    b.HasOne("ConsoleApp1.Dependent", "Dependent")
                        .WithMany()
                        .HasForeignKey("DependentId");

                    b.HasOne("ConsoleApp1.Primary", null)
                        .WithMany()
                        .HasForeignKey("PrimaryId");

                    b.Navigation("Dependent");
                });
#pragma warning restore 612, 618
        }
    }
}
