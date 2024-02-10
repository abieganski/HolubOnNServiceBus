﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.Context;

#nullable disable

namespace Warehouse.Entities
{
    [DbContext(typeof(WarehouseDbContext))]
    partial class WarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Warehouse.Entities.PickList", b =>
                {
                    b.Property<int>("PickListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PickListId"));

                    b.Property<bool>("IsPicked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("WhenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WhenPicked")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WhenUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("PickListId");

                    b.ToTable("PickLists");
                });

            modelBuilder.Entity("Warehouse.Entities.PickListItem", b =>
                {
                    b.Property<int>("PickListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PickListItemId"));

                    b.Property<int?>("PickListId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("WhenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WhenUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("PickListItemId");

                    b.HasIndex("PickListId");

                    b.ToTable("PickListItems");
                });

            modelBuilder.Entity("Warehouse.Entities.PickListItem", b =>
                {
                    b.HasOne("Warehouse.Entities.PickList", null)
                        .WithMany("Items")
                        .HasForeignKey("PickListId");
                });

            modelBuilder.Entity("Warehouse.Entities.PickList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
