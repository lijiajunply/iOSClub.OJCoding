﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OJCoding.Share.DataModels;

#nullable disable

namespace OJCoding.Share.Migrations
{
    [DbContext(typeof(OJContext))]
    [Migration("20231231065253_AddNameFromTest")]
    partial class AddNameFromTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("OJCoding.Share.DataModels.CourseModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Guid");

                    b.ToTable("CourseModels");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.LearnCourseModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("CourseGuid")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("UserModelGuid")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Guid");

                    b.HasIndex("CourseGuid");

                    b.HasIndex("UserModelGuid");

                    b.ToTable("LearnCourseModel");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.LearnTestModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LearnCourseModelGuid")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("TestGuid")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Guid");

                    b.HasIndex("LearnCourseModelGuid");

                    b.HasIndex("TestGuid");

                    b.ToTable("LearnTestModel");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.TestModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Arg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseModelGuid")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Guid");

                    b.HasIndex("CourseModelGuid");

                    b.ToTable("TestModels");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.UserModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Guid");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.LearnCourseModel", b =>
                {
                    b.HasOne("OJCoding.Share.DataModels.CourseModel", "Course")
                        .WithMany()
                        .HasForeignKey("CourseGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OJCoding.Share.DataModels.UserModel", null)
                        .WithMany("Courses")
                        .HasForeignKey("UserModelGuid");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.LearnTestModel", b =>
                {
                    b.HasOne("OJCoding.Share.DataModels.LearnCourseModel", null)
                        .WithMany("Schedule")
                        .HasForeignKey("LearnCourseModelGuid");

                    b.HasOne("OJCoding.Share.DataModels.TestModel", "Test")
                        .WithMany()
                        .HasForeignKey("TestGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.TestModel", b =>
                {
                    b.HasOne("OJCoding.Share.DataModels.CourseModel", null)
                        .WithMany("Tests")
                        .HasForeignKey("CourseModelGuid");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.CourseModel", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.LearnCourseModel", b =>
                {
                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("OJCoding.Share.DataModels.UserModel", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
