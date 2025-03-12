using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resolve.Domain.Registrations.Entities;

namespace Resolve.Infra.Data.EntityConfigurations
{
    public class ProgramacaoFinanceiraDespesaConfigConfiguration : IEntityTypeConfiguration<ProgramacaoFinanceiraDespesaConfig>
    {
        public void Configure(EntityTypeBuilder<ProgramacaoFinanceiraDespesaConfig> builder)
        {
            builder.ToTable("ProgramacaoFinanceiraDespesaConfig");

            builder.HasKey(p => p.ProgramacaoFinanceiraDespesaConfigId)
                   .HasName("PK_ProgramacaoFinanceiraDespesaConfig");

            builder.Property(p => p.ProgramacaoFinanceiraDespesaConfigId)
                   .HasColumnName("ProgramacaoFinanceiraDespesaConfigID")
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Ano)
                   .IsRequired();

            builder.Property(p => p.UnidadeGestoraIdfk)
                   .HasColumnName("UnidadeGestoraIDFK")
                   .IsRequired();

            builder.Property(p => p.Mes01Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes02Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes03Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes04Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes05Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes06Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes07Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes08Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes09Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes10Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes11Perc).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Mes12Perc).HasColumnType("decimal(10,2)");
        }
    }
}
