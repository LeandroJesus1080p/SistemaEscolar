using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Models.Entities.Mappings
{
    public class TurmaDisciplinasMappings : IEntityTypeConfiguration<TurmaDisciplinas>
    {
        private const string Name = "escola";
        public void Configure(EntityTypeBuilder<TurmaDisciplinas> builder)
        {
            builder.ToTable("TurmaDisciplinas");

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.TurmaDisciplinas)
                .HasForeignKey(x => x.TurmaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{Name}_turmaDisciplinas{Name}_turma");

            builder.HasOne(x => x.Disciplina)
                .WithMany(x => x.TurmaDisciplinas)
                .HasForeignKey(x => x.DisciplinaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{Name}_turmaDisciplinas{Name}_disciplina");

            builder.HasOne(x => x.Professor)
                .WithMany(x => x.TurmaDisciplinas)
                .HasForeignKey(x => x.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{Name}_turmaDisciplinas_{Name}_professor");
        }
    }
}
