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
    public class ParentDetailsConfiguration : EntityTypeConfiguration<ParentDetails>
    {
        internal ParentDetailsConfiguration()
        {
            this.Property(parentDetails => parentDetails.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(parentDetails => parentDetails.Description).HasColumnName("Description").HasMaxLength(250);
            this.Property(parentDetails => parentDetails.DateCreated).HasColumnName("DateCreated");

            //this.HasRequired(parentDetails => parentDetails.Parent).WithRequiredDependent(p => p.ParentDetails).Map(pd => pd.MapKey("P";
        }
    }
}
