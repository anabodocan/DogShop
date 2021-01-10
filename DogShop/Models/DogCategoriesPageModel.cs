using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DogShop.Data;


namespace DogShop.Models
{
    public class DogCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(DogShopContext context,
        Dog dog)
        {
            var allCategories = context.Category;
            var dogCategories = new HashSet<int>(
            dog.DogCategories.Select(c => c.DogID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = dogCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateDogCategories(DogShopContext context,
        string[] selectedCategories, Dog dogToUpdate)
        {
            if (selectedCategories == null)
            {
                dogToUpdate.DogCategories = new List<DogCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var dogCategories = new HashSet<int>
            (dogToUpdate.DogCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!dogCategories.Contains(cat.ID))
                    {
                        dogToUpdate.DogCategories.Add(
                        new DogCategory
                        {
                            DogID = dogToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (dogCategories.Contains(cat.ID))
                    {
                        DogCategory courseToRemove
                        = dogToUpdate
                        .DogCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

