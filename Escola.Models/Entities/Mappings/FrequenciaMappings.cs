using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities.Mappings
{
    public class FrequenciaMappings : IEntityTypeConfiguration<Frequencia>
    {
        private const string Name = "escola";
        public void Configure(EntityTypeBuilder<Frequencia> builder)
        {
            builder.ToTable("Frequencia");

            builder.Property(x => x.DataAula)
                .HasColumnName("DataAula")
                .HasColumnType("date");

            builder.Property(x => x.Presente)
                .HasColumnName("Presente");

            builder.HasOne(x => x.Matricula)
                .WithMany(x => x.Frequencias)
                .HasForeignKey(x => x.MatriculaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{Name}_frequencia_{Name}_matricula");

            builder.HasOne(x => x.TurmaDisciplinas)
                .WithMany(x => x.Frequencias)
                .HasForeignKey(x => x.TurmaDisciplinasId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{Name}_frequencia_{Name}_turmaDisciplinas");
        }
    }
}
