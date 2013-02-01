using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.DataAccess.EntityConfig;
using WebApp.Mockup.DataAccess.SampleDataSetup;
using WebApp.Mockup.Model;

namespace WebApp.Mockup.DataAccess
{
    public class WebAppDBContext : DbContext
    {
        static WebAppDBContext()
        {
            Database.SetInitializer(new WebAppDbInitializer());
        }

        public WebAppDBContext()
            : base(nameOrConnectionString: "WebAppMockUp") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ParentConfiguration());
            modelBuilder.Configurations.Add(new ParentDetailsConfiguration());
            modelBuilder.Configurations.Add(new ChildConfiguration());
        }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentDetails> ParentDetails { get; set; }
        public DbSet<Child> Children { get; set; }
    }
}
