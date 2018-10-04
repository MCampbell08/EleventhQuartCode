﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using StreamerSite.API.Data;
using System;

namespace StreamerSite.API.Migrations
{
    [DbContext(typeof(StreamersContext))]
    [Migration("20180601231840_StreamerSite.API.Data.StreamersContext")]
    partial class StreamerSiteAPIDataStreamersContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("StreamerSite.API.Models.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<bool>("Admin");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("FollowerCount")
                        .HasColumnName("FollowerCount");

                    b.Property<int>("PageViewCount")
                        .HasColumnName("PageViewCount");

                    b.Property<string>("Password")
                        .HasColumnName("Password")
                        .HasColumnType("TEXT")
                        .HasMaxLength(14);

                    b.Property<int>("SubscriberCount")
                        .HasColumnName("SubcriberCount");

                    b.Property<string>("Username")
                        .HasColumnName("Username")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("StreamerSite.API.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.Property<int?>("UserDetailId");

                    b.Property<int>("UserId")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserDetailId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("StreamerSite.API.Models.Video", b =>
                {
                    b.HasOne("StreamerSite.API.Models.UserDetail")
                        .WithMany("Videos")
                        .HasForeignKey("UserDetailId");
                });
#pragma warning restore 612, 618
        }
    }
}