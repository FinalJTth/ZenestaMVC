﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenestaMVC.Data;

#nullable disable

namespace ZenestaMVC.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241215125000_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZenestaMVC.Models.Entity.Prediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PredictionBatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredictionBatchId");

                    b.ToTable("Predictions");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.PredictionBatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PredictionBatches");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.PredictionImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredictionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredictionId")
                        .IsUnique();

                    b.ToTable("PredictionImages");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.PredictionResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Confidence")
                        .HasColumnType("real");

                    b.Property<string>("Object")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredictionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredictionId");

                    b.ToTable("PredictionResults");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(72)
                        .HasColumnType("nvarchar(72)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("Username", "Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.Prediction", b =>
                {
                    b.HasOne("ZenestaMVC.Models.Entity.PredictionBatch", "PredictionBatch")
                        .WithMany("Predictions")
                        .HasForeignKey("PredictionBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PredictionBatch");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.PredictionBatch", b =>
                {
                    b.HasOne("ZenestaMVC.Models.Entity.User", "User")
                        .WithMany("PredictionBatches")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.PredictionImage", b =>
                {
                    b.HasOne("ZenestaMVC.Models.Entity.Prediction", "Prediction")
                        .WithOne("PredictionImage")
                        .HasForeignKey("ZenestaMVC.Models.Entity.PredictionImage", "PredictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prediction");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.PredictionResult", b =>
                {
                    b.HasOne("ZenestaMVC.Models.Entity.Prediction", "Prediction")
                        .WithMany("PredictionResults")
                        .HasForeignKey("PredictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prediction");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.Prediction", b =>
                {
                    b.Navigation("PredictionImage")
                        .IsRequired();

                    b.Navigation("PredictionResults");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.PredictionBatch", b =>
                {
                    b.Navigation("Predictions");
                });

            modelBuilder.Entity("ZenestaMVC.Models.Entity.User", b =>
                {
                    b.Navigation("PredictionBatches");
                });
#pragma warning restore 612, 618
        }
    }
}
