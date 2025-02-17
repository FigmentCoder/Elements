﻿// <auto-generated />
using System;
using Elements.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Elements.Persistence.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220901145933_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Elements.Domain.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Elements.Domain.Models.Disclaimer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasDisplayed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Disclaimers");
                });

            modelBuilder.Entity("Elements.Domain.Models.Reminder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Recurrence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Season")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Elements.Domain.Models.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ArticleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Elements.Persistence.Update", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Value");

                    b.ToTable("Updates");
                });

            modelBuilder.Entity("Elements.Domain.Models.Article", b =>
                {
                    b.OwnsOne("Elements.Domain.Models.ImageName", "ImageName", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsOne("Elements.Domain.Models.Title", "Title", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.Navigation("ImageName");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Elements.Domain.Models.Disclaimer", b =>
                {
                    b.OwnsOne("Elements.Domain.Models.Message", "Message", b1 =>
                        {
                            b1.Property<Guid>("DisclaimerId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("DisclaimerId");

                            b1.ToTable("Disclaimers");

                            b1.WithOwner()
                                .HasForeignKey("DisclaimerId");
                        });

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Elements.Domain.Models.Reminder", b =>
                {
                    b.OwnsOne("Elements.Domain.Models.PlatformId", "PlatformId", b1 =>
                        {
                            b1.Property<Guid>("ReminderId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.HasKey("ReminderId");

                            b1.ToTable("Reminders");

                            b1.WithOwner()
                                .HasForeignKey("ReminderId");
                        });

                    b.OwnsOne("Elements.Domain.Models.Title", "Title", b1 =>
                        {
                            b1.Property<Guid>("ReminderId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.HasKey("ReminderId");

                            b1.ToTable("Reminders");

                            b1.WithOwner()
                                .HasForeignKey("ReminderId");
                        });

                    b.Navigation("PlatformId");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Elements.Domain.Models.Section", b =>
                {
                    b.HasOne("Elements.Domain.Models.Article", null)
                        .WithMany("Sections")
                        .HasForeignKey("ArticleId");

                    b.OwnsOne("Elements.Domain.Models.Header", "Header", b1 =>
                        {
                            b1.Property<Guid>("SectionId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.HasKey("SectionId");

                            b1.ToTable("Sections");

                            b1.WithOwner()
                                .HasForeignKey("SectionId");
                        });

                    b.OwnsOne("Elements.Domain.Models.Order", "Order", b1 =>
                        {
                            b1.Property<Guid>("SectionId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Value")
                                .HasColumnType("INTEGER");

                            b1.HasKey("SectionId");

                            b1.ToTable("Sections");

                            b1.WithOwner()
                                .HasForeignKey("SectionId");
                        });

                    b.OwnsOne("Elements.Domain.Models.Text", "Text", b1 =>
                        {
                            b1.Property<Guid>("SectionId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("SectionId");

                            b1.ToTable("Sections");

                            b1.WithOwner()
                                .HasForeignKey("SectionId");
                        });

                    b.Navigation("Header");

                    b.Navigation("Order");

                    b.Navigation("Text");
                });

            modelBuilder.Entity("Elements.Domain.Models.Article", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
