using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Models.Entities.Mappings
{
    public class MatriculaMappings : IEntityTypeConfiguration<Matricula>
    {
        private const string Name = "escola";
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matricula");

            builder.Property(x => x.DataMatricula)
                .HasColumnName("DataMatricula")
                .HasColumnType("date");

            builder.HasIndex(x => x.DataMatricula).IsUnique();

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.AlunoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{Name}_matricula_{Name}_aluno");

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.TurmaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{Name}_matricula_{Name}_turma");

        }
    }
}
