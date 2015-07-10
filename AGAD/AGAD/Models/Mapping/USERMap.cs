using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AGAD.Models.Mapping
{
    public class USERMap : EntityTypeConfiguration<USER>
    {
        public USERMap()
        {
            // Primary Key
            this.HasKey(t => t.TC);

            // Properties
            this.Property(t => t.TC)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.AD)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SOYAD)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EMAIL)
                .HasMaxLength(50);

            this.Property(t => t.PASS)
                .IsRequired();

            this.Property(t => t.PHONE)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("USER");
            this.Property(t => t.TC).HasColumnName("TC");
            this.Property(t => t.AD).HasColumnName("AD");
            this.Property(t => t.SOYAD).HasColumnName("SOYAD");
            this.Property(t => t.EMAIL).HasColumnName("EMAIL");
            this.Property(t => t.PASS).HasColumnName("PASS");
            this.Property(t => t.ADRES).HasColumnName("ADRES");
            this.Property(t => t.PHONE).HasColumnName("PHONE");
        }
    }
}
