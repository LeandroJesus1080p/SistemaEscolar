using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities.Mappings
{
    public class TurmaMappings : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");

            builder.Property(x => x.AnoLetivo)
                .HasColumnName("AnoLetivo")
                .HasColumnType("date");

            builder.Property(x => x.Serie)
                .IsRequired()
                .HasColumnName("Serie")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);
        }
    }
}
