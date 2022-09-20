﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProleiT.OeeBaseClassifiers.Storage;

namespace MasterData.Storage.Migrations
{
    [DbContext(typeof(MasterDataContext))]
    [Migration("20220920124130_Initial_Create")]
    partial class Initial_Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MasterData.Storage.Enities.CounterTrend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("dtCreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nKey")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<int>("RecordMode")
                        .HasColumnName("nRecordMode")
                        .HasColumnType("integer");

                    b.Property<Guid>("TrendId")
                        .HasColumnName("gTrendId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnName("nType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("Key");

                    b.HasIndex("TrendId");

                    b.ToTable("tblCounterTrend");
                });

            modelBuilder.Entity("MasterData.Storage.Enities.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("dtCreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsUsed")
                        .HasColumnName("bIsUsed")
                        .HasColumnType("boolean");

                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nKey")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("text");

                    b.Property<Guid>("UnitId")
                        .HasColumnName("gUnitId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("Key");

                    b.HasIndex("UnitId");

                    b.ToTable("tbEquipment");
                });

            modelBuilder.Entity("MasterData.Storage.Enities.ParameterTrend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("dtCreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nKey")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<int>("RecordMode")
                        .HasColumnName("nRecordMode")
                        .HasColumnType("integer");

                    b.Property<Guid>("TrendId")
                        .HasColumnName("gTrendId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("Key");

                    b.HasIndex("TrendId");

                    b.ToTable("tblParameterTrend");
                });

            modelBuilder.Entity("MasterData.Storage.Enities.Trend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("dtCreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("EquipmentId")
                        .HasColumnName("gEquipmentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nKey")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<Guid?>("UnitId")
                        .HasColumnName("gUnitId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("Key");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("UnitId");

                    b.ToTable("tblTrend");
                });

            modelBuilder.Entity("MasterData.Storage.Enities.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("dtCreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nKey")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("text");

                    b.Property<short>("Type")
                        .HasColumnName("nType")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasAlternateKey("Key");

                    b.ToTable("tblUnit");
                });

            modelBuilder.Entity("MasterData.Storage.Enities.CounterTrend", b =>
                {
                    b.HasOne("MasterData.Storage.Enities.Trend", "Trend")
                        .WithMany()
                        .HasForeignKey("TrendId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterData.Storage.Enities.Equipment", b =>
                {
                    b.HasOne("MasterData.Storage.Enities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterData.Storage.Enities.ParameterTrend", b =>
                {
                    b.HasOne("MasterData.Storage.Enities.Trend", "Trend")
                        .WithMany()
                        .HasForeignKey("TrendId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterData.Storage.Enities.Trend", b =>
                {
                    b.HasOne("MasterData.Storage.Enities.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("MasterData.Storage.Enities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");
                });
#pragma warning restore 612, 618
        }
    }
}
