using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Mockup.Contracts.Dtos
{
    public class ParentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Live { get; set; }
        public string Description {get; set;}
        public DateTime? DateCreated { get; set; }
    }
}
