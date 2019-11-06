﻿// <auto-generated />
using System;
using AspNetWebCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetWebCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191103214127_newtableeeee")]
    partial class newtableeeee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetWebCore.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("KulaniciAdi");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("AspNetWebCore.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeaderId");

                    b.Property<DateTime>("KayitTarihi");

                    b.Property<string>("Question");

                    b.Property<string>("QuestionAnswerA");

                    b.Property<string>("QuestionAnswerB");

                    b.Property<string>("QuestionAnswerC");

                    b.Property<string>("QuestionAnswerD");

                    b.Property<string>("TrueAnswer");

                    b.HasKey("Id");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("AspNetWebCore.Models.QuestionsHeaderContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Header");

                    b.HasKey("Id");

                    b.ToTable("questionsHeaderContents");
                });
#pragma warning restore 612, 618
        }
    }
}
