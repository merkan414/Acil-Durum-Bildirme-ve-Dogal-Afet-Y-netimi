using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AGAD.Models.Mapping
{
    public class IMAGEPATHMap:EntityTypeConfiguration<IMAGEPATH>
    {
        public IMAGEPATHMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.AGAD_ID)
                .IsRequired();

            this.Property(t => t.PATH)
                .IsRequired()
                .HasMaxLength(50);

           
            // Table & Column Mappings
            this.ToTable("IMAGEPATH");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AGAD_ID).HasColumnName("AGAD_ID");
            this.Property(t => t.PATH).HasColumnName("PATH");
            

            // Relationships
            this.HasRequired(t => t.AGAD_)
                .WithMany(t => t.ImagePATHS)
                .HasForeignKey(d => d.AGAD_ID);
            
        }
    }
}