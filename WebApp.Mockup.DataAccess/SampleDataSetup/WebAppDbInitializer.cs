using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.Model;

namespace WebApp.Mockup.DataAccess.SampleDataSetup
{
    public class WebAppDbInitializer : DropCreateDatabaseIfModelChanges<WebAppDBContext>
    {
        protected override void Seed(WebAppDBContext context)
        {
            AddParents(context);
            AddChildren(context);
        }

        private void AddChildren(WebAppDBContext context)
        {
            var parents = context.Parents.Select(p => p).ToList();

            parents.ForEach(parent =>
                {
                    
                   context.ParentDetails.Add(new  ParentDetails { Id = parent.Id, Description = "This is parent" + parent.Id.ToString() , DateCreated = DateTime.Now.AddDays(-2) });

                   context.SaveChanges();

                    if (parent.Id == 1)
                    {
                        context.Children.Add(new Child { Parent = parent, Name = "1. * Child of Parent: " + parent.Id.ToString(), Description = "Some Description fsdfdsf  fdsfd fdsfd..." });
                        context.Children.Add(new Child { Parent = parent, Name = "2. * Child of Parent: " + parent.Id.ToString(), Description = "Some Description dsff..." });
                        context.Children.Add(new Child { Parent = parent, Name = "3. * Child of Parent: " + parent.Id.ToString(), Description = "Some Description fdfd..." });
                        context.Children.Add(new Child { Parent = parent, Name = "4. * Child of Parent: " + parent.Id.ToString(), Description = "Some Description fsdf ;ksd;fkl..." });
                        context.Children.Add(new Child { Parent = parent, Name = "5. * Child of Parent: " + parent.Id.ToString(), Description = "Some Description dsfd fdsfsdf..." });
                        context.Children.Add(new Child { Parent = parent, Name = "6. * Child of Parent: " + parent.Id.ToString(), Description = "Some Description ggg fdsfsdf..." });
                    }
                    else if (parent.Id == 3)
                    {
                        context.Children.Add(new Child { Parent = parent, Name = "1. % Child of Parent: " + parent.Id.ToString(), Description = "Optionally, you can pass a function to control how the array should be sorted. Your function should accept any two objects from the array and return a negative value if the first argument is smaller, a positive value is the second is smaller, or zero to treat them as equal. For example, to sort an array " });
                        context.Children.Add(new Child { Parent = parent, Name = "2. % Child of Parent: " + parent.Id.ToString(), Description = "By default, it sorts alphabetically (for strings) or numerically (for numbers)." });
                        context.Children.Add(new Child { Parent = parent, Name = "3. % Child of Parent: " + parent.Id.ToString(), Description = "myObservableArray.destroy(someItem) finds any objects in the array that equal someItem and gives them a special property called _destroy with value true" });
                        context.Children.Add(new Child { Parent = parent, Name = "4. % Child of Parent: " + parent.Id.ToString(), Description = "myObservableArray.destroy(function(someItem) { return someItem.age < 18 }) finds any objects in the array whose age property is less than 18, and gives those objects a special property called _destroy with value true" });
                    }
                    else
                    {
                        context.Children.Add(new Child { Parent = parent, Name = "1. ## Child of Parent: " + parent.Id.ToString(), Description = "Optionally, you can pass a function to control how the array should be sorted. Your function should accept any two objects from the array and return a negative value if the first argument is smaller, a positive value is the second is smaller, or zero to treat them as equal. For example, to sort an array " });
                        context.Children.Add(new Child { Parent = parent, Name = "2. ## Child of Parent: " + parent.Id.ToString(), Description = "By default, it sorts alphabetically (for strings) or numerically (for numbers)." });
                    }


                });

            context.SaveChanges();
        }

        private void AddParents(WebAppDBContext context)
        {
            var parents = new List<Parent>();

            parents.Add(new Parent { Name = "Parent 1", Live = true });
            parents.Add(new Parent { Name = "Parent 2", Live = true });
            parents.Add(new Parent { Name = "Parent 3", Live = false });
            parents.Add(new Parent { Name = "Parent 4", Live = true  });
            parents.Add(new Parent { Name = "Parent 5", Live = false});

            parents.ForEach(parent =>
                {
                    context.Parents.Add(parent);
                });
            

            context.SaveChanges();
           
        }
    }
}
