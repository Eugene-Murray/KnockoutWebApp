using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApp.Mockup.BusinessModule;
using WebApp.Mockup.Contracts;
using WebApp.Mockup.DataAccess;

namespace WebApp.Mockup.App_Start
{
    public static class IocConfig
    {
        static readonly IUnityContainer container = new UnityContainer();
        
        public static void RegisterIoc(HttpConfiguration config)
        {
            IServiceLocator serviceLocator = new UnityServiceLocator(container);

            EnterpriseLibraryContainer.Current = serviceLocator;


            container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>());
            container.RegisterType<IBusinessModuleManager, BusinessModuleManager>(new HttpContextLifetimeManager<IBusinessModuleManager>());

            System.Web.Mvc.DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));
            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}