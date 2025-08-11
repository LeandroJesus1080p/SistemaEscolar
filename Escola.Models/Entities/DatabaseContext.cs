using Microsoft.EntityFrameworkCore;

namespace Escola.Models.Entities
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Disciplinas> Disciplinas { get; set; }
        public virtual DbSet<Frequencia> Frequencias { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<TurmaDisciplinas> TurmaDisciplinas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}