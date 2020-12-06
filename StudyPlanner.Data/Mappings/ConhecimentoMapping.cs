using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyPlanner.Business.Models;

namespace StudyPlanner.Data.Mappings
{
    public class ConhecimentoMapping : IEntityTypeConfiguration<Conhecimento>
    {

        public void Configure(EntityTypeBuilder<Conhecimento> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.NivelConhecimentoAtual)
                .IsRequired();

            builder.Property(c => c.NivelConhecimentoDesejado)
                .IsRequired();

            builder.Property(c => c.Prioridade)
                .IsRequired();

            //builder.Property(c => c.TipoConhecimento)
            //    .HasConversion<string>()
            //    .IsRequired();

            builder.Property(c => c.PlanoAcao)
                .IsRequired()
                .HasColumnType("varchar(1000)");
        }
    }
}
