using Gameficacao01.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<SprintModel>? Sprints { get; set; }
        public DbSet<TarefaModel>? Tarefas { get; set; }
        public DbSet<ClienteModel>? Clientes { get; set; } 
        public DbSet<ProjetoModel>? Projetos { get; set; } 
        public DbSet<EquipeModel>? Equipes { get; set; } 
        public DbSet<MembroModel>? Membros { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // Configuração do relacionamento entre SprintModel e TarefaModel
            modelBuilder.Entity<SprintModel>()
                .HasMany(s => s.Tarefas)
                .WithOne(t => t.Sprints)
                .HasForeignKey(t => t.SprintId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            modelBuilder.Entity<TarefaModel>()
                .HasOne(t => t.Sprints)
                .WithMany(s => s.Tarefas)
                .HasForeignKey(t => t.SprintId);

        modelBuilder.Entity<ProjetoModel>()
                .HasMany(h => h.Tarefas)
                .WithOne(t => t.Projetos)
                .HasForeignKey(t => t.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

    modelBuilder.Entity<ProjetoModel>()
        .HasOne(p => p.Equipe) // Singular, pois cada projeto tem uma equipe
        .WithOne(e => e.Projeto) // Singular aqui também
        .HasForeignKey<EquipeModel>(e => e.ProjetoId)  // Aqui está o erro. ForeignKey deve ser de EquipeModel
        .IsRequired(false);

                     modelBuilder.Entity<EquipeModel>()
                .HasMany(s => s.Membros)
                .WithOne(t => t.Equipes)
                .HasForeignKey(t => t.EquipeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

    // Relacionamento de Clientes com Projetos
            modelBuilder.Entity<ClienteModel>()
                .HasMany(s => s.Projetos)
                .WithOne(t => t.Clientes)
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

        }
    }
}
