using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApp.Mockup.Model
{
    public class ParentDetails : EntityBase
    {
        //public ParentDetails()
        //{
        //    Parent = new Parent();
        //}
        
        public DateTime? DateCreated { get; set; }
        public string Description { get; set; }

        public virtual Parent Parent { get; set; }
    }
}
