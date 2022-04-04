using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EtlLocadora.Data.Domain.Entities.Dw;

namespace EtlLocadora.Data.Context
{
    public partial class LocadoraDwContext : DbContext
    {
        public LocadoraDwContext(DbContextOptions<LocadoraDwContext> options)
              : base(options)
        {
        }

        public virtual DbSet<DmArtista> DmArtista { get; set; } = null!;
        public virtual DbSet<DmGravadora> DmGravadora { get; set; } = null!;
        public virtual DbSet<DmSocio> DmSocio { get; set; } = null!;
        public virtual DbSet<DmTempo> DmTempo { get; set; } = null!;
        public virtual DbSet<DmTitulo> DmTitulo { get; set; } = null!;
        public virtual DbSet<FtLocacoes> FtLocacoes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DW_LOCADORA");

            modelBuilder.Entity<DmArtista>(entity =>
            {
                entity.HasKey(e => e.IdArt)
                    .HasName("DM_ARTISTAS_PK");

                entity.ToTable("DM_ARTISTA");

                entity.Property(e => e.IdArt)
                    .HasPrecision(4)
                    .HasColumnName("ID_ART");

                entity.Property(e => e.NacBras)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NAC_BRAS");

                entity.Property(e => e.NomArt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOM_ART");

                entity.Property(e => e.TpoArt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TPO_ART");
            });

            modelBuilder.Entity<DmGravadora>(entity =>
            {
                entity.HasKey(e => e.IdGrav)
                    .HasName("DM_GRAVADORA_PK");

                entity.ToTable("DM_GRAVADORA");

                entity.Property(e => e.IdGrav)
                    .HasPrecision(4)
                    .HasColumnName("ID_GRAV");

                entity.Property(e => e.NacBras)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NAC_BRAS");

                entity.Property(e => e.NomGrav)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOM_GRAV");

                entity.Property(e => e.UfGrav)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UF_GRAV");
            });

            modelBuilder.Entity<DmSocio>(entity =>
            {
                entity.HasKey(e => e.IdSoc)
                    .HasName("DM_SOCIOS_PK");

                entity.ToTable("DM_SOCIO");

                entity.Property(e => e.IdSoc)
                    .HasPrecision(4)
                    .HasColumnName("ID_SOC");

                entity.Property(e => e.NomSoc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOM_SOC");

                entity.Property(e => e.TipoSocio)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_SOCIO");
            });

            modelBuilder.Entity<DmTempo>(entity =>
            {
                entity.HasKey(e => e.IdTempo)
                    .HasName("DM_TEMPO_PK");

                entity.ToTable("DM_TEMPO");

                entity.Property(e => e.IdTempo)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TEMPO");

                entity.Property(e => e.DtTempo)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_TEMPO");

                entity.Property(e => e.NmMes)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NM_MES");

                entity.Property(e => e.NmMesano)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("NM_MESANO")
                    .IsFixedLength();

                entity.Property(e => e.NuAno)
                    .HasPrecision(4)
                    .HasColumnName("NU_ANO");

                entity.Property(e => e.NuAnomes)
                    .HasPrecision(7)
                    .HasColumnName("NU_ANOMES");

                entity.Property(e => e.NuDia)
                    .HasPrecision(2)
                    .HasColumnName("NU_DIA");

                entity.Property(e => e.NuHora)
                    .HasPrecision(2)
                    .HasColumnName("NU_HORA");

                entity.Property(e => e.NuMes)
                    .HasPrecision(2)
                    .HasColumnName("NU_MES");

                entity.Property(e => e.SgMes)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SG_MES")
                    .IsFixedLength();

                entity.Property(e => e.Turno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TURNO");
            });

            modelBuilder.Entity<DmTitulo>(entity =>
            {
                entity.HasKey(e => e.IdTitulo)
                    .HasName("DM_TITULOS_PK");

                entity.ToTable("DM_TITULO");

                entity.Property(e => e.IdTitulo)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TITULO");

                entity.Property(e => e.ClaTitulo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CLA_TITULO");

                entity.Property(e => e.DscTitulo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DSC_TITULO");

                entity.Property(e => e.TpoTitulo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TPO_TITULO");
            });

            modelBuilder.Entity<FtLocacoes>(entity =>
            {
                entity.HasKey(e => new { e.IdSoc, e.IdTitulo, e.IdArt, e.IdGrav, e.IdTempo })
                    .HasName("FT_LOCACOES_PK");

                entity.ToTable("FT_LOCACOES");

                entity.Property(e => e.IdSoc)
                    .HasPrecision(4)
                    .HasColumnName("ID_SOC");

                entity.Property(e => e.IdTitulo)
                    .HasPrecision(6)
                    .HasColumnName("ID_TITULO");

                entity.Property(e => e.IdArt)
                    .HasPrecision(4)
                    .HasColumnName("ID_ART");

                entity.Property(e => e.IdGrav)
                    .HasPrecision(4)
                    .HasColumnName("ID_GRAV");

                entity.Property(e => e.IdTempo)
                    .HasPrecision(6)
                    .HasColumnName("ID_TEMPO");

                entity.Property(e => e.MultaAtraso)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("MULTA_ATRASO");

                entity.Property(e => e.TempoDevolucao)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("TEMPO_DEVOLUCAO");

                entity.Property(e => e.ValorArrecadado)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("VALOR_ARRECADADO");

                entity.HasOne(d => d.IdArtNavigation)
                    .WithMany(p => p.FtLocacoes)
                    .HasForeignKey(d => d.IdArt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FT_LOCACOES_DM_ARTISTA_FK");

                entity.HasOne(d => d.IdGravNavigation)
                    .WithMany(p => p.FtLocacoes)
                    .HasForeignKey(d => d.IdGrav)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FT_LOCACOES_DM_GRAVADORA_FK");

                entity.HasOne(d => d.IdSocNavigation)
                    .WithMany(p => p.FtLocacoes)
                    .HasForeignKey(d => d.IdSoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FT_LOCACOES_DM_SOCIO_FK");

                entity.HasOne(d => d.IdTempoNavigation)
                    .WithMany(p => p.FtLocacoes)
                    .HasForeignKey(d => d.IdTempo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FT_LOCACOES_DM_TEMPO_FK");

                entity.HasOne(d => d.IdTituloNavigation)
                    .WithMany(p => p.FtLocacoes)
                    .HasForeignKey(d => d.IdTitulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FT_LOCACOES_DM_TITULO_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
