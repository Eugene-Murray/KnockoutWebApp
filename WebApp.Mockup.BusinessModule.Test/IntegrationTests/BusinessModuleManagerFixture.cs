using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Mockup.Contracts;
using WebApp.Mockup.DataAccess;
using System.Linq;

namespace WebApp.Mockup.BusinessModule.Test.IntegrationTests
{
    [TestClass]
    public class BusinessModuleManagerFixture
    {
        [TestMethod]
        public void GetAllParents_Success()
        {
            // Assign
            IUnitOfWork context = new UnitOfWork(new WebAppDBContext());

            // Act
            var parents = context.Parents.GetAll("ParentDetails").ToList();

            // Assert
            Assert.IsTrue(parents.Count > 0);
        }


        [TestMethod]
        public void GetParent_LazyLoadChildren_Success()
        {
            // Assign
            IUnitOfWork context = new UnitOfWork(new WebAppDBContext());
            var expectedChildCount = 6;

            // Act
            var actualChildCount = context.Parents.FindByExp(p => p.Id == 1, "Children").FirstOrDefault().Children.Count();
            

            // Assert
            Assert.AreEqual(expectedChildCount, actualChildCount);
        }


        [TestMethod]
        public void GetAllChildren_Success()
        {
            // Assign
            IUnitOfWork context = new UnitOfWork(new WebAppDBContext());

            // Act
            var children = context.Children.GetAll().ToList();


            // Assert
            Assert.IsTrue(children.Count > 0);
        }

        [TestMethod]
        public void Get_ParentsChildren_Success()
        {
            // Assign
            IUnitOfWork context = new UnitOfWork(new WebAppDBContext());
            IBusinessModuleManager manager = new BusinessModuleManager(context);
            int parentId = 1;
            int expectedCount = 6;

            // Act
            var actualCount = manager.GetChildrenByParentId(parentId).Count();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
