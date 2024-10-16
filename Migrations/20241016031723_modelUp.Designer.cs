﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetoTecnico.Models;

#nullable disable

namespace RetoTecnico.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20241016031723_modelUp")]
    partial class modelUp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RetoTecnico.Models.Alhaja", b =>
                {
                    b.Property<int>("AlhajaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AlhajaID"));

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaLiquidacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaOperacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FolioID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("MontoEmpeño")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MontoInteres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PesoKG")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PorInteresMomento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PreOroMomento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AlhajaID");

                    b.HasIndex("ClienteID");

                    b.ToTable("Alhaja");
                });

            modelBuilder.Entity("RetoTecnico.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ClienteID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RetoTecnico.Models.Parametros", b =>
                {
                    b.Property<int>("ParametroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ParametroID"));

                    b.Property<decimal>("Interes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MontoAcumulado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecioGramo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("limOperaciones")
                        .HasColumnType("int");

                    b.HasKey("ParametroID");

                    b.ToTable("Parametros");
                });

            modelBuilder.Entity("RetoTecnico.Models.Alhaja", b =>
                {
                    b.HasOne("RetoTecnico.Models.Cliente", "Cliente")
                        .WithMany("Alhajas")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("RetoTecnico.Models.Cliente", b =>
                {
                    b.Navigation("Alhajas");
                });
#pragma warning restore 612, 618
        }
    }
}
