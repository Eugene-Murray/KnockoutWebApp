using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.Model;

namespace WebApp.Mockup.DataAccess.EntityConfig
{
    public class ChildConfiguration : EntityTypeConfiguration<Child>
    {
        internal ChildConfiguration()
        {
            this.Property(child => child.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(child => child.Name).HasColumnName("Name").HasMaxLength(30);
            this.Property(child => child.Description).HasColumnName("Description").HasMaxLength(500);
            this.Property(child => child.Range).HasColumnName("Range");

            //this.Property(child => child.ParentId).HasColumnName("ParentId");
            //this.HasRequired(child => child.Parent).WithMany().HasForeignKey(child => child.ParentId);

            this.ToTable("Child");
        }
    }
}
