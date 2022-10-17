﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationManagement.Infrastructure.Database;

namespace TranslationManagement.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221017180322_AddedJobSeedData")]
    partial class AddedJobSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TranslationManagement.Domain.Entities.TranslationJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalContent")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TranslatedContent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TranslationJobs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerName = "Roman",
                            OriginalContent = "OriginalContent",
                            Price = 0.5,
                            Status = 0,
                            TranslatedContent = "TranslatedContent"
                        },
                        new
                        {
                            Id = 2,
                            CustomerName = "Michal",
                            OriginalContent = "OriginalContent",
                            Price = 0.29999999999999999,
                            Status = 1,
                            TranslatedContent = "TranslatedContent"
                        });
                });

            modelBuilder.Entity("TranslationManagement.Domain.Entities.Translator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("HourlyRate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });
#pragma warning restore 612, 618
        }
    }
}
