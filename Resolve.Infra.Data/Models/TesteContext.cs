using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Resolve.Infra.Data.Models;

public partial class TesteContext : DbContext
{
    public TesteContext()
    {
    }

    public TesteContext(DbContextOptions<TesteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrcamentoDespesa> OrcamentoDespesas { get; set; }

    public virtual DbSet<ProgramacaoFinanceiraDespesaConfig> ProgramacaoFinanceiraDespesaConfigs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TESTE;User Id=sa;Password=12345678@Bc;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<OrcamentoDespesa>(entity =>
        {
            entity.HasKey(e => e.OrcamentoDespesaId).HasName("PK_OrcamentoDespesa_OrcamentoDespesaID");

            entity.ToTable("OrcamentoDespesa");

            entity.HasIndex(e => new { e.Codigo, e.Ano, e.UnidadeGestora }, "UQ_OrcamentoDespesa_Codigo_Ano_UnidadeGestora").IsUnique();

            entity.Property(e => e.OrcamentoDespesaId).HasColumnName("OrcamentoDespesaID");
            entity.Property(e => e.ElencoContaCodigo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Ficha)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<ProgramacaoFinanceiraDespesaConfig>(entity =>
        {
            entity.ToTable("ProgramacaoFinanceiraDespesaConfig");

            entity.Property(e => e.ProgramacaoFinanceiraDespesaConfigId)
                .ValueGeneratedNever()
                .HasColumnName("ProgramacaoFinanceiraDespesaConfigID");
            entity.Property(e => e.Mes01Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes02Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes03Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes04Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes05Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes06Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes07Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes08Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes09Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes10Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes11Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mes12Perc).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnidadeGestoraIdfk).HasColumnName("UnidadeGestoraIDFK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
