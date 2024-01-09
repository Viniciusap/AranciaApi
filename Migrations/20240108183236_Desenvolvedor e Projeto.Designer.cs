﻿// <auto-generated />
using Arancia_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arancia_Api.Migrations
{
    [DbContext(typeof(EmpresaContext))]
    [Migration("20240108183236_Desenvolvedor e Projeto")]
    partial class DesenvolvedoreProjeto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Arancia_Api.Modelos.Desenvolvedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Desenvolvedor");
                });

            modelBuilder.Entity("Arancia_Api.Modelos.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Arancia_Api.Modelos.Projeto", b =>
                {
                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("DesenvolvedorId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmpresaId");

                    b.HasIndex("DesenvolvedorId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("Arancia_Api.Modelos.Projeto", b =>
                {
                    b.HasOne("Arancia_Api.Modelos.Desenvolvedor", "Desenvolvedor")
                        .WithMany("Projeto")
                        .HasForeignKey("DesenvolvedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arancia_Api.Modelos.Empresa", "Empresa")
                        .WithMany("Projeto")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desenvolvedor");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Arancia_Api.Modelos.Desenvolvedor", b =>
                {
                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Arancia_Api.Modelos.Empresa", b =>
                {
                    b.Navigation("Projeto");
                });
#pragma warning restore 612, 618
        }
    }
}
