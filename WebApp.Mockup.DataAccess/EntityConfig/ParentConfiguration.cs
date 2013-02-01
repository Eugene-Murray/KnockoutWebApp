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
    public class ParentConfiguration : EntityTypeConfiguration<Parent>
    {
        public ParentConfiguration()
        {
            this.Property(parent => parent.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(parent => parent.Name).HasColumnName("Name").HasMaxLength(30);
            this.Property(parent => parent.Live).HasColumnName("Live");

            this.HasRequired(parent => parent.ParentDetails).WithRequiredPrincipal(pd => pd.Parent); //.Map(p => p.MapKey("ParentDetailsId"));

            //this.HasRequired(parent => parent.Children).WithMany( x => x.).HasForeignKey(child => child.Id);

            this.ToTable("Parent");
        }
    }
}
