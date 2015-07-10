using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AGAD.Models.Mapping
{
    public class AGADMap : EntityTypeConfiguration<AGAD>
    {
        public AGADMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IL)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ILCESEMT)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.KOY)
                .HasMaxLength(50);

            this.Property(t => t.MAHALLE)
                .HasMaxLength(50);

            this.Property(t => t.BELDEMEVKI)
                .HasMaxLength(50);

            this.Property(t => t.LATITUDE)
                .HasMaxLength(50);

            this.Property(t => t.LONGITUDE)
                .HasMaxLength(50);

            this.Property(t => t.COMMENT)
                .HasMaxLength(50);

            this.Property(t => t.EFFECTTEDAREA)
                .HasMaxLength(50);

            this.Property(t => t.CONFIRMCOMMENT)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AGAD");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AGADTYPE).HasColumnName("AGADTYPE");
            this.Property(t => t.STARTDATE).HasColumnName("STARTDATE");
            this.Property(t => t.ENDDATE).HasColumnName("ENDDATE");
            this.Property(t => t.TIME).HasColumnName("TIME");
            this.Property(t => t.IL).HasColumnName("IL");
            this.Property(t => t.ILCESEMT).HasColumnName("ILCESEMT");
            this.Property(t => t.KOY).HasColumnName("KOY");
            this.Property(t => t.MAHALLE).HasColumnName("MAHALLE");
            this.Property(t => t.BELDEMEVKI).HasColumnName("BELDEMEVKI");
            this.Property(t => t.LATITUDE).HasColumnName("LATITUDE");
            this.Property(t => t.LONGITUDE).HasColumnName("LONGITUDE");
            this.Property(t => t.COMMENT).HasColumnName("COMMENT");
            this.Property(t => t.EFFECTTEDAREA).HasColumnName("EFFECTTEDAREA");
            this.Property(t => t.IMAGEPATH).HasColumnName("IMAGEPATH");
            this.Property(t => t.CONFIRMSTATEID).HasColumnName("CONFIRMSTATEID");
            this.Property(t => t.CONFIRMCOMMENT).HasColumnName("CONFIRMCOMMENT");

            // Relationships
            this.HasRequired(t => t.AGADTYPE1)
                .WithMany(t => t.AGADs)
                .HasForeignKey(d => d.AGADTYPE);
            this.HasRequired(t => t.CONFIRMSTATE)
                .WithMany(t => t.AGADs)
                .HasForeignKey(d => d.CONFIRMSTATEID);

        }
    }
}
