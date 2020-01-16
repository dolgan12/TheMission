﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheMission.API.Data;

namespace TheMission.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200116170013_AddedSkillIndex")]
    partial class AddedSkillIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("TheMission.API.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SkillName")
                        .HasColumnType("TEXT");

                    b.HasKey("SkillId");

                    b.HasIndex("SkillName")
                        .IsUnique();

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("TheMission.API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheMission.API.Models.UserSkill", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("TheMission.API.Models.UserSkill", b =>
                {
                    b.HasOne("TheMission.API.Models.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheMission.API.Models.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
