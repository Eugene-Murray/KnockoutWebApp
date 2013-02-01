using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Mockup.Model
{
    public class Child : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Range { get; set; }

        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
