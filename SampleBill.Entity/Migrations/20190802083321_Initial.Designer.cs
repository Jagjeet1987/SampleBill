﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleBill.Entity;

namespace SampleBill.Entity.Migrations
{
    [DbContext(typeof(AccountingDbContext))]
    [Migration("20190802083321_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleBill.Entity.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BillDate");

                    b.Property<Guid>("ContactId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsActive");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<long>("Number");

                    b.Property<decimal>("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("SampleBill.Entity.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("SampleBill.Entity.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DueDate");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<bool>("IsActive");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<long>("Number");

                    b.Property<decimal?>("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("SampleBill.Entity.JVoucher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<decimal>("Credit");

                    b.Property<decimal>("Debit");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<DateTime>("PostingDate");

                    b.Property<string>("Reference");

                    b.Property<Guid>("TransactionId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("JVoucher");
                });

            modelBuilder.Entity("SampleBill.Entity.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<Guid>("EntityId");

                    b.Property<int>("EntityType");

                    b.Property<bool>("IsActive");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.HasKey("Id");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("SampleBill.Entity.Bill", b =>
                {
                    b.HasOne("SampleBill.Entity.Contact", "Contact")
                        .WithMany("Bill")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SampleBill.Entity.Invoice", b =>
                {
                    b.HasOne("SampleBill.Entity.Contact", "Contact")
                        .WithMany("Invoice")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SampleBill.Entity.JVoucher", b =>
                {
                    b.HasOne("SampleBill.Entity.Transaction", "Transaction")
                        .WithMany("JVoucher")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}