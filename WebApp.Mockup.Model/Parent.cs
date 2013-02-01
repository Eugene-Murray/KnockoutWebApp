using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Mockup.Model
{
    public class Parent : EntityBase
    {
        //public Parent()
        //{
        //    ParentDetails = new ParentDetails();
        //}
        
        public string Name { get; set; }
        public bool Live { get; set; }

        public ParentDetails ParentDetails { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}
