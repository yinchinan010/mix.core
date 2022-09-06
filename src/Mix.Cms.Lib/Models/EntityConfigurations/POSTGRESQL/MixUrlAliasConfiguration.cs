﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mix.Cms.Lib.Enums;
using Mix.Cms.Lib.Models.Cms;

namespace Mix.Cms.Lib.Models.EntityConfigurations.POSTGRESQL
{
    public class MixUrlAliasConfiguration : IEntityTypeConfiguration<MixUrlAlias>
    {
        public void Configure(EntityTypeBuilder<MixUrlAlias> entity)
        {
            entity.HasKey(e => new { e.Id, e.Specificulture })
                    .HasName("PK_mix_url_alias");

            entity.ToTable("mix_url_alias");

            entity.HasIndex(e => e.Specificulture);

            entity.Property(e => e.Specificulture)
                .HasColumnType("varchar(10)")
                .HasCharSet("utf8")
                .UseCollation("und-x-icu");

            entity.Property(e => e.Alias)
                .HasColumnType("varchar(250)")
                .HasCharSet("utf8")
                .UseCollation("und-x-icu");

            entity.Property(e => e.CreatedBy)
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8")
                .UseCollation("und-x-icu");

            entity.Property(e => e.CreatedDateTime).HasColumnType("timestamp without time zone");

            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasCharSet("utf8")
                .UseCollation("und-x-icu");

            entity.Property(e => e.LastModified).HasColumnType("timestamp without time zone");

            entity.Property(e => e.ModifiedBy)
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8")
                .UseCollation("und-x-icu");

            entity.Property(e => e.SourceId)
                .HasColumnType("varchar(250)")
                .HasCharSet("utf8")
                .UseCollation("und-x-icu");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<MixContentStatus>())
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8")
                .UseCollation("und-x-icu");

            entity.HasOne(d => d.SpecificultureNavigation)
                .WithMany(p => p.MixUrlAlias)
                .HasPrincipalKey(p => p.Specificulture)
                .HasForeignKey(d => d.Specificulture)
                .HasConstraintName("FK_Mix_Url_Alias_Mix_Culture");
        }
    }
}