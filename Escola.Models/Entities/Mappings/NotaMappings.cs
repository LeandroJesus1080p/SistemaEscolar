using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Models.Entities.Mappings
{
    public class NotaMappings : IEntityTypeConfiguration<Nota>
    {
        private const string Name = "escola";

        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("Nota");

            builder.Property(x => x.NotaAluno)
                .HasColumnName("NotaAluno")
                .HasColumnType("INT");

            builder.Property(x => x.DataAvaliacao)
                .HasColumnName("DataAvaliacao")
                .HasColumnType("date");

            builder.HasOne(x => x.Matricula)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.MatriculaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{Name}_nota_{Name}_matricula");

            builder.HasOne(x => x.TurmaDisciplinas)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.TurmaDisciplinasId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{Name}_nota_{Name}_turmaDisciplinas");
        }
    }
}
