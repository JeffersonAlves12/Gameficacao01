﻿// <auto-generated />
using System;
using Gameficacao01.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gameficacao01.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Gameficacao01.API.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.EquipeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId")
                        .IsUnique();

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.MembroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Papel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("Membros");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.ProjetoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataConclusaoPrevista")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.SprintModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.TarefaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SprintId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("SprintId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.EquipeModel", b =>
                {
                    b.HasOne("Gameficacao01.API.Models.ProjetoModel", "Projeto")
                        .WithOne("Equipe")
                        .HasForeignKey("Gameficacao01.API.Models.EquipeModel", "ProjetoId");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.MembroModel", b =>
                {
                    b.HasOne("Gameficacao01.API.Models.EquipeModel", "Equipes")
                        .WithMany("Membros")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Equipes");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.ProjetoModel", b =>
                {
                    b.HasOne("Gameficacao01.API.Models.ClienteModel", "Clientes")
                        .WithMany("Projetos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.TarefaModel", b =>
                {
                    b.HasOne("Gameficacao01.API.Models.ProjetoModel", "Projetos")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gameficacao01.API.Models.SprintModel", "Sprints")
                        .WithMany("Tarefas")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Projetos");

                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.ClienteModel", b =>
                {
                    b.Navigation("Projetos");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.EquipeModel", b =>
                {
                    b.Navigation("Membros");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.ProjetoModel", b =>
                {
                    b.Navigation("Equipe");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("Gameficacao01.API.Models.SprintModel", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
