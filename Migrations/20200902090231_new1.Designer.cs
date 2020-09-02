﻿// <auto-generated />
using System;
using Fuela.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lubricants.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20200902090231_new1")]
    partial class new1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lubricants.Models.CatItems", b =>
                {
                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CatId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("catItems");
                });

            modelBuilder.Entity("Lubricants.Models.CategoriesBooks", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CatName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CategoriesBooks");
                });

            modelBuilder.Entity("Lubricants.Models.Item_category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Item_categoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Item_categoryID");

                    b.ToTable("Items_category");
                });

            modelBuilder.Entity("Lubricants.Models.Item_category", b =>
                {
                    b.HasOne("Lubricants.Models.Item_category", null)
                        .WithMany("item_Categories")
                        .HasForeignKey("Item_categoryID");
                });
#pragma warning restore 612, 618
        }
    }
}