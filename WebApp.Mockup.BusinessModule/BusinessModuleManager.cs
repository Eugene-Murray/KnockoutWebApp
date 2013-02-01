using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.Contracts;
using WebApp.Mockup.Contracts.Dtos;

namespace WebApp.Mockup.BusinessModule
{
    public class BusinessModuleManager : IBusinessModuleManager
    {
        private readonly IUnitOfWork _context;

        public BusinessModuleManager(IUnitOfWork context)
        {
            this._context = context;
        }

        public List<ParentDto> GetAllParents()
        {
            var parentListDtos = new List<ParentDto>();
            using (_context)
            {
                var parents = _context.Parents.GetAll("ParentDetails").ToList();

                parents.ForEach(p =>
                    {
                        parentListDtos.Add(new ParentDto { Id = p.Id, Name = p.Name, Live = p.Live, Description = p.ParentDetails.Description, DateCreated = p.ParentDetails.DateCreated  });
                    });
            }

            return parentListDtos;
        }

        public List<ChildrenDto> GetChildrenByParentId(int parentId)
        {
            var childrenListDtos = new List<ChildrenDto>();
            using (_context)
            {
                var parents = _context.Children.FindByExp(c => c.ParentId == parentId).ToList();

                parents.ForEach(p =>
                {
                    childrenListDtos.Add(new ChildrenDto { Name = p.Name, Description = p.Description, Range = p.Range });
                });
            }

            return childrenListDtos;
        }
    }
}
