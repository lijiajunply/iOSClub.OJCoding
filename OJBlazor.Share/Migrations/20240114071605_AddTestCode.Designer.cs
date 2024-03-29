﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OJBlazor.Share.DataModels;

#nullable disable

namespace OJBlazor.Share.Migrations
{
    [DbContext(typeof(OJContext))]
    [Migration("20240114071605_AddTestCode")]
    partial class AddTestCode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("OJBlazor.Share.DataModels.CourseModel", b =>
                {
                    b.Property<string>("HashName")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("HashName");

                    b.ToTable("CourseModels");
                });

            modelBuilder.Entity("OJBlazor.Share.DataModels.TestModel", b =>
                {
                    b.Property<string>("HashName")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseModelHashName")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TestCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("HashName");

                    b.HasIndex("CourseModelHashName");

                    b.ToTable("TestModels");
                });

            modelBuilder.Entity("OJBlazor.Share.DataModels.TestModel", b =>
                {
                    b.HasOne("OJBlazor.Share.DataModels.CourseModel", null)
                        .WithMany("Tests")
                        .HasForeignKey("CourseModelHashName");
                });

            modelBuilder.Entity("OJBlazor.Share.DataModels.CourseModel", b =>
                {
                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
