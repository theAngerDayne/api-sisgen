﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_sisgen.Data;

namespace api_sisgen.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Detalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DocumentoId")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NmbItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrcItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QtyItem")
                        .HasColumnType("int");

                    b.Property<string>("UnmdItem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.ToTable("DetallesBoleta");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Boletas");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Emisor", b =>
                {
                    b.Property<int>("EncabezadoId")
                        .HasColumnType("int");

                    b.Property<int>("Acteco")
                        .HasColumnType("int");

                    b.Property<int>("CdgSIISucur")
                        .HasColumnType("int");

                    b.Property<string>("CiudadOrigen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CmnaOrigen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirOrigen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiroEmis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RUTEmisor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RznSoc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EncabezadoId");

                    b.ToTable("Emisor");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Encabezado", b =>
                {
                    b.Property<int>("DocumentoId")
                        .HasColumnType("int");

                    b.HasKey("DocumentoId");

                    b.ToTable("Encabezado");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.IdDoc", b =>
                {
                    b.Property<int>("EncabezadoId")
                        .HasColumnType("int");

                    b.Property<string>("FchEmis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FchVenc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Folio")
                        .HasColumnType("int");

                    b.Property<int>("IndMntNeto")
                        .HasColumnType("int");

                    b.Property<int>("IndServicio")
                        .HasColumnType("int");

                    b.Property<string>("PeriodoDesde")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodoHasta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDTE")
                        .HasColumnType("int");

                    b.HasKey("EncabezadoId");

                    b.ToTable("IdDoc");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Receptor", b =>
                {
                    b.Property<int>("EncabezadoId")
                        .HasColumnType("int");

                    b.Property<string>("CdgIntRecep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CiudadPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CiudadRecep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CmnaPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CmnaRecep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirRecep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RUTRecep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RznSocRecep")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EncabezadoId");

                    b.ToTable("Receptor");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Totales", b =>
                {
                    b.Property<int>("EncabezadoId")
                        .HasColumnType("int");

                    b.Property<decimal>("IVA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MntExe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MntNeto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MntTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EncabezadoId");

                    b.ToTable("Totales");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Detalle", b =>
                {
                    b.HasOne("api_sisgen.Models.BoletaElectronica.Documento", null)
                        .WithMany("Detalles")
                        .HasForeignKey("DocumentoId");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Emisor", b =>
                {
                    b.HasOne("api_sisgen.Models.BoletaElectronica.Encabezado", "Encabezado")
                        .WithOne("Emisor")
                        .HasForeignKey("api_sisgen.Models.BoletaElectronica.Emisor", "EncabezadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encabezado");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Encabezado", b =>
                {
                    b.HasOne("api_sisgen.Models.BoletaElectronica.Documento", "Documento")
                        .WithOne("Encabezado")
                        .HasForeignKey("api_sisgen.Models.BoletaElectronica.Encabezado", "DocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Documento");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.IdDoc", b =>
                {
                    b.HasOne("api_sisgen.Models.BoletaElectronica.Encabezado", "Encabezado")
                        .WithOne("IdDoc")
                        .HasForeignKey("api_sisgen.Models.BoletaElectronica.IdDoc", "EncabezadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encabezado");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Receptor", b =>
                {
                    b.HasOne("api_sisgen.Models.BoletaElectronica.Encabezado", "Encabezado")
                        .WithOne("Receptor")
                        .HasForeignKey("api_sisgen.Models.BoletaElectronica.Receptor", "EncabezadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encabezado");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Totales", b =>
                {
                    b.HasOne("api_sisgen.Models.BoletaElectronica.Encabezado", "Encabezado")
                        .WithOne("Totales")
                        .HasForeignKey("api_sisgen.Models.BoletaElectronica.Totales", "EncabezadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encabezado");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Documento", b =>
                {
                    b.Navigation("Detalles");

                    b.Navigation("Encabezado");
                });

            modelBuilder.Entity("api_sisgen.Models.BoletaElectronica.Encabezado", b =>
                {
                    b.Navigation("Emisor");

                    b.Navigation("IdDoc");

                    b.Navigation("Receptor");

                    b.Navigation("Totales");
                });
#pragma warning restore 612, 618
        }
    }
}
