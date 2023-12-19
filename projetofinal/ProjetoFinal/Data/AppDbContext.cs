using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Model;

namespace ProjetoFinal.Data {
    public class AppDbContext : DbContext
    {
        public DbSet<AlunoModel>? Alunos { get; set; }
        public DbSet<NotaModel>? Notas { get; set; }
        public DbSet<PlanejamentoModel>? Planejamentos { get; set; }
        public DbSet<ProfessorModel>? Professores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=tds.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoModel>().ToTable("Alunos").HasKey(a => a.AlunoID);
            modelBuilder.Entity<AlunoModel>().Property(a => a.AlunoID).ValueGeneratedOnAdd();

            modelBuilder.Entity<NotaModel>().ToTable("Notas").HasKey(n => n.NotaID);
            modelBuilder.Entity<NotaModel>().Property(n => n.NotaID).ValueGeneratedOnAdd();

            modelBuilder.Entity<PlanejamentoModel>().ToTable("Planejamentos").HasKey(p => p.PlanejamentoID);
            modelBuilder.Entity<PlanejamentoModel>().Property(p => p.PlanejamentoID).ValueGeneratedOnAdd();

            modelBuilder.Entity<ProfessorModel>().ToTable("Professores").HasKey(t => t.ProfessorID);
            modelBuilder.Entity<ProfessorModel>().Property(t => t.ProfessorID).ValueGeneratedOnAdd();

            modelBuilder.Entity<NotaModel>()
                .HasMany(c => c.Alunos)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "NotaAluno",
                    a => a.HasOne<AlunoModel>().WithMany().HasForeignKey("AlunoID"),
                    n => n.HasOne<NotaModel>().WithMany().HasForeignKey("NotaID"),
                    nA =>
                    {
                        nA.HasKey("NotaID", "AlunoID");
                        nA.ToTable("NotasEAlunos");
                    });
        }
    }
}