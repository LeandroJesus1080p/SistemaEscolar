using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities.Mappings
{
    public class DisciplinasMappings : IEntityTypeConfiguration<Disciplinas>
    {
        public void Configure(EntityTypeBuilder<Disciplinas> builder)
        {
            builder.ToTable("Disciplinas");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(120);

            builder.Property(x => x.CargaHoraria)
                .IsRequired()
                .HasColumnName("CargaHoraria")
                .HasColumnType("INT");
        }
    }
}
