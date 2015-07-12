using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AGAD.Models.Mapping
{
    public class CITYMap : EntityTypeConfiguration<CITY>
    {
        public CITYMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NAME)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CITY");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.NAME).HasColumnName("NAME");
        }
    }
}
