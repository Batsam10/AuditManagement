﻿// <auto-generated />
using System;
using AuditManagement.DataAcces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuditManagement.DataAcces.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240430032832_audit-db-init")]
    partial class auditdbinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuditManagement.Models.AuditTransaction", b =>
                {
                    b.Property<long>("AuditTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AuditTransactionId"));

                    b.Property<long>("AuditId")
                        .HasColumnType("bigint");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Base")
                        .HasColumnType("decimal(20,10)");

                    b.Property<DateTime>("ConfirmedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("DCM")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DCMTransFeeUSD")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DCMTransFeeZAR")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DCMUSDSpread")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DCMZAR")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DCMZARMarkUp")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DCMZARPerc")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DCMZARSpread")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("DTBaseLive")
                        .HasColumnType("decimal(30, 15)");

                    b.Property<decimal?>("DaytonaPerc")
                        .HasColumnType("decimal((30, 15))");

                    b.Property<decimal?>("DaytonaUSDBase")
                        .HasColumnType("decimal(30, 15)");

                    b.Property<decimal?>("DaytonaUSDMarkUp")
                        .HasColumnType("decimal(30, 15)");

                    b.Property<decimal?>("DaytonaZARBase")
                        .HasColumnType("decimal((30, 15))");

                    b.Property<decimal?>("DaytonaZARMarkUp")
                        .HasColumnType("decimal((30, 15))");

                    b.Property<decimal?>("DaytonaZARPerc")
                        .HasColumnType("decimal((30, 15))");

                    b.Property<decimal?>("HPAfterMarkUp")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("HPTransFeeZAR")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("HPZARSpread")
                        .HasColumnType("decimal(20,10)");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("InternalServiceFeeUSD")
                        .HasColumnType("decimal(30, 15)");

                    b.Property<decimal?>("InternalServiceFeeZAR")
                        .HasColumnType("decimal(30, 15)");

                    b.Property<decimal?>("MarkUp")
                        .HasColumnType("decimal(20,10)");

                    b.Property<int>("MatchStatus")
                        .HasColumnType("int");

                    b.Property<decimal?>("OfferAmount")
                        .HasColumnType("decimal(20,10)");

                    b.Property<long>("OfferId")
                        .HasColumnType("bigint");

                    b.Property<string>("PartnerMTAI")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PartnerReference")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PartnerStatus")
                        .HasColumnType("int");

                    b.Property<decimal?>("Perc")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("PrincipleSpreadDCMZAR")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("Randdiff")
                        .HasColumnType("decimal(20,10)");

                    b.Property<string>("Refnumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sarb")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ToCurr")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("TotalTransFee")
                        .HasColumnType("decimal(10,5)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("USDMarkUp")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("USDPerc")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("XEDCM")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal?>("ZARTotalSpread")
                        .HasColumnType("decimal(20,10)");

                    b.HasKey("AuditTransactionId");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
