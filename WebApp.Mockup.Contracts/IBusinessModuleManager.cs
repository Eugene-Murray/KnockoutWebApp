using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.Contracts.Dtos;

namespace WebApp.Mockup.Contracts
{
    public interface IBusinessModuleManager
    {
        List<ParentDto> GetAllParents();
        List<ChildrenDto> GetChildrenByParentId(int parentId);
    }
}
