﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EtlLocadora.Data.Domain.Entities.Relacional;

namespace EtlLocadora.Data.Context
{
    public partial class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options)
               : base(options)
        {
        }

        public virtual DbSet<Artistas> Artistas { get; set; } = null!;
        public virtual DbSet<Copias> Copias { get; set; } = null!;
        public virtual DbSet<Gravadoras> Gravadoras { get; set; } = null!;
        public virtual DbSet<ItensLocacoes> ItensLocacoes { get; set; } = null!;
        public virtual DbSet<Locacoes> Locacoes { get; set; } = null!;
        public virtual DbSet<Socios> Socios { get; set; } = null!;
        public virtual DbSet<TiposSocios> TiposSocios { get; set; } = null!;
        public virtual DbSet<Titulos> Titulos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("LOCADORA");

            modelBuilder.Entity<Artistas>(entity =>
            {
                entity.HasKey(e => e.CodArt)
                    .HasName("ART_PK");

                entity.ToTable("ARTISTAS");

                entity.HasIndex(e => e.CodGrav, "ART_FK_GRV_I");

                entity.HasIndex(e => e.NomArt, "ART_NOM_ART_I");

                entity.Property(e => e.CodArt)
                    .HasPrecision(4)
                    .HasColumnName("COD_ART");

                entity.Property(e => e.CodGrav)
                    .HasPrecision(4)
                    .HasColumnName("COD_GRAV");

                entity.Property(e => e.MedAnual)
                    .HasColumnType("NUMBER(4,2)")
                    .HasColumnName("MED_ANUAL");

                entity.Property(e => e.NacBras)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NAC_BRAS")
                    .IsFixedLength();

                entity.Property(e => e.NomArt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOM_ART");

                entity.Property(e => e.QtdTit)
                    .HasPrecision(4)
                    .HasColumnName("QTD_TIT");

                entity.Property(e => e.TpoArt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TPO_ART")
                    .IsFixedLength();

                entity.HasOne(d => d.CodGravNavigation)
                    .WithMany(p => p.Artistas)
                    .HasForeignKey(d => d.CodGrav)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ART_FK_GRV");
            });

            modelBuilder.Entity<Copias>(entity =>
            {
                entity.HasKey(e => new { e.CodTit, e.NumCop })
                    .HasName("COP_PK");

                entity.ToTable("COPIAS");

                entity.HasIndex(e => e.CodTit, "COP_FK_TIT_I");

                entity.Property(e => e.CodTit)
                    .HasPrecision(6)
                    .HasColumnName("COD_TIT");

                entity.Property(e => e.NumCop)
                    .HasPrecision(2)
                    .HasColumnName("NUM_COP");

                entity.Property(e => e.DatAq)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_AQ");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.HasOne(d => d.CodTitNavigation)
                    .WithMany(p => p.Copias)
                    .HasForeignKey(d => d.CodTit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("COP_FK_TIT");
            });

            modelBuilder.Entity<Gravadoras>(entity =>
            {
                entity.HasKey(e => e.CodGrav)
                    .HasName("GRV_PK");

                entity.ToTable("GRAVADORAS");

                entity.HasIndex(e => e.NomGrav, "GRV_NOM_GRAV_I");

                entity.Property(e => e.CodGrav)
                    .HasPrecision(4)
                    .HasColumnName("COD_GRAV");

                entity.Property(e => e.NacBras)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NAC_BRAS")
                    .IsFixedLength();

                entity.Property(e => e.NomGrav)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOM_GRAV");

                entity.Property(e => e.UfGrav)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF_GRAV")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ItensLocacoes>(entity =>
            {
                entity.HasKey(e => new { e.CodSoc, e.DatLoc, e.CodTit })
                    .HasName("ITL_PK");

                entity.ToTable("ITENS_LOCACOES");

                entity.HasIndex(e => new { e.CodTit, e.NumCop }, "ITL_FK_COP_I");

                entity.Property(e => e.CodSoc)
                    .HasColumnName("COD_SOC");

                entity.Property(e => e.DatLoc)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_LOC");

                entity.Property(e => e.CodTit)
                    .HasPrecision(6)
                    .HasColumnName("COD_TIT");

                entity.Property(e => e.DatDev)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_DEV");

                entity.Property(e => e.DatPrev)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_PREV");

                entity.Property(e => e.NumCop)
                    .HasPrecision(2)
                    .HasColumnName("NUM_COP");

                entity.Property(e => e.StaMul)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STA_MUL")
                    .IsFixedLength();

                entity.Property(e => e.ValLoc)
                    .HasColumnType("NUMBER(6,2)")
                    .HasColumnName("VAL_LOC");

                entity.HasOne(d => d.Locacoes)
                    .WithMany(p => p.ItensLocacoes)
                    .HasForeignKey(d => new { d.CodSoc, d.DatLoc })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ITL_FK_LOC");

                entity.HasOne(d => d.Copias)
                    .WithMany(p => p.ItensLocacoes)
                    .HasForeignKey(d => new { d.CodTit, d.NumCop })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ITL_FK_COP");
            });

            modelBuilder.Entity<Locacoes>(entity =>
            {
                entity.HasKey(e => new { e.CodSoc, e.DatLoc })
                    .HasName("LOC_PK");

                entity.ToTable("LOCACOES");

                entity.Property(e => e.CodSoc)
                    .HasColumnName("COD_SOC");

                entity.Property(e => e.DatLoc)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_LOC");

                entity.Property(e => e.DatPgto)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_PGTO");

                entity.Property(e => e.DatVenc)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_VENC");

                entity.Property(e => e.StaPgto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STA_PGTO")
                    .IsFixedLength();

                entity.Property(e => e.ValLoc)
                    .HasColumnType("NUMBER(5,2)")
                    .HasColumnName("VAL_LOC");

                entity.HasOne(d => d.CodSocNavigation)
                    .WithMany(p => p.Locacoes)
                    .HasForeignKey(d => d.CodSoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LOC_FK_SOC");
            });

            modelBuilder.Entity<Socios>(entity =>
            {
                entity.HasKey(e => e.CodSoc)
                    .HasName("SOC_PK");

                entity.ToTable("SOCIOS");

                entity.HasIndex(e => e.CodTps, "SOC_FK_TPS_I");

                entity.HasIndex(e => e.NomSoc, "SOC_NOM_SOC_I");

                entity.Property(e => e.CodSoc)
                    .HasColumnName("COD_SOC");

                entity.Property(e => e.CodTps)
                    .HasPrecision(4)
                    .HasColumnName("COD_TPS");

                entity.Property(e => e.DatCad)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_CAD");

                entity.Property(e => e.NomSoc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOM_SOC");

                entity.Property(e => e.StaSoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STA_SOC")
                    .IsFixedLength();

                entity.HasOne(d => d.CodTpsNavigation)
                    .WithMany(p => p.Socios)
                    .HasForeignKey(d => d.CodTps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SOC_FK_TPS");
            });

            modelBuilder.Entity<TiposSocios>(entity =>
            {
                entity.HasKey(e => e.CodTps)
                    .HasName("TPS_PK");

                entity.ToTable("TIPOS_SOCIOS");

                entity.HasIndex(e => e.DscTps, "TPS_DSC_TPS_I");

                entity.Property(e => e.CodTps)
                    .HasPrecision(4)
                    .HasColumnName("COD_TPS");

                entity.Property(e => e.DscTps)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DSC_TPS");

                entity.Property(e => e.LimTit)
                    .HasPrecision(2)
                    .HasColumnName("LIM_TIT");

                entity.Property(e => e.ValBase)
                    .HasColumnType("NUMBER(6,2)")
                    .HasColumnName("VAL_BASE");
            });

            modelBuilder.Entity<Titulos>(entity =>
            {
                entity.HasKey(e => e.CodTit)
                    .HasName("TIT_PK");

                entity.ToTable("TITULOS");

                entity.HasIndex(e => e.DscTit, "TIT_DSC_TIT_I");

                entity.HasIndex(e => e.CodArt, "TIT_FK_ART_I");

                entity.HasIndex(e => e.CodGrav, "TIT_FK_GRV_I");

                entity.Property(e => e.CodTit)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("COD_TIT");

                entity.Property(e => e.ClaTit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CLA_TIT")
                    .IsFixedLength();

                entity.Property(e => e.CodArt)
                    .HasPrecision(4)
                    .HasColumnName("COD_ART");

                entity.Property(e => e.CodGrav)
                    .HasPrecision(4)
                    .HasColumnName("COD_GRAV");

                entity.Property(e => e.DatLanc)
                    .HasColumnType("DATE")
                    .HasColumnName("DAT_LANC");

                entity.Property(e => e.DscTit)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DSC_TIT");

                entity.Property(e => e.QtdCop)
                    .HasPrecision(3)
                    .HasColumnName("QTD_COP");

                entity.Property(e => e.TpoTit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TPO_TIT")
                    .IsFixedLength();

                entity.HasOne(d => d.CodArtNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.CodArt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIT_FK_ART");

                entity.HasOne(d => d.CodGravNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.CodGrav)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIT_FK_GRV");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
