using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Mockup.Contracts;
using WebApp.Mockup.Contracts.Dtos;

namespace WebApp.Mockup.Controllers
{
    public class BusinessModuleController : ApiController
    {
        private readonly IBusinessModuleManager _manager;

        public BusinessModuleController(IBusinessModuleManager manager)
        {
            _manager = manager;
        }
        
        // GET api/businessmodule
        public IEnumerable<ParentDto> GetAllParents()
        {
            return _manager.GetAllParents();
        }

        // GET api/businessmodule/5
        public string GetParent(int id)
        {
            return "value";
        }

        public IEnumerable<ChildrenDto> GetChildren(int parentId)
        {
            return _manager.GetChildrenByParentId(parentId);
        }

        // POST api/businessmodule
        public void Post([FromBody]string value)
        {
        }

        // PUT api/businessmodule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/businessmodule/5
        public void Delete(int id)
        {
        }
    }
}
