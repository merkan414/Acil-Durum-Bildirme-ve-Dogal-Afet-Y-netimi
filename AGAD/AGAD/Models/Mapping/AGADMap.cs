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
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.STARTDATE)
                 .HasColumnType("datetime2")
                 .HasPrecision(0);
            this.Property(t => t.ENDDATE)
                 .HasColumnType("datetime2")
                 .HasPrecision(0);

            this.Property(t => t.VILLAGE)
                .HasMaxLength(50);

            this.Property(t => t.DISTINCT_REGION)
                .HasMaxLength(50);

            this.Property(t => t.REGION)
                .HasMaxLength(50);

            this.Property(t => t.COMMENT)
                .HasMaxLength(50);

            this.Property(t => t.EFFECTTEDAREA)
                .HasMaxLength(50);

            this.Property(t => t.CONFIRMCOMMENT)
                .HasMaxLength(50);

            this.Property(t => t.USER_TC)
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("AGAD");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AGADTYPE).HasColumnName("AGADTYPE");
            this.Property(t => t.STARTDATE).HasColumnName("STARTDATE");
            this.Property(t => t.ENDDATE).HasColumnName("ENDDATE");
            this.Property(t => t.CITY).HasColumnName("CITY");
            this.Property(t => t.TOWN).HasColumnName("TOWN");
            this.Property(t => t.VILLAGE).HasColumnName("VILLAGE");
            this.Property(t => t.DISTINCT_REGION).HasColumnName("DISTINCT_REGION");
            this.Property(t => t.REGION).HasColumnName("REGION");
            this.Property(t => t.COMMENT).HasColumnName("COMMENT");
            this.Property(t => t.EFFECTTEDAREA).HasColumnName("EFFECTTEDAREA");
            this.Property(t => t.CONFIRMSTATEID).HasColumnName("CONFIRMSTATEID");
            this.Property(t => t.CONFIRMCOMMENT).HasColumnName("CONFIRMCOMMENT");
            this.Property(t => t.USER_TC).HasColumnName("USER_TC");

            // Relationships
            this.HasRequired(t => t.AGADTYPE_Item)
                .WithMany(t => t.AGADs)
                .HasForeignKey(d => d.AGADTYPE);

            this.HasRequired(t => t.CITY_Item)
                .WithMany(t => t.AGADs)
                .HasForeignKey(d => d.CITY);

            this.HasRequired(t => t.CONFIRMSTATE_Item)
                .WithMany(t => t.AGADs)
                .HasForeignKey(d => d.CONFIRMSTATEID);

            this.HasRequired(t => t.TOWN_Item)
                .WithMany(t => t.AGADs)
                .HasForeignKey(d => d.TOWN);

            this.HasRequired(t => t.USER_Item)
                .WithMany(t => t.AGADs)
                .HasForeignKey(d => d.USER_TC);

        }
    }
}
