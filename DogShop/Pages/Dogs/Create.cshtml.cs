using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogShop.Data;
using DogShop.Models;

namespace DogShop.Pages.Dogs
{
    public class CreateModel : DogCategoriesPageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public CreateModel(DogShop.Data.DogShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BreederID"] = new SelectList(_context.Set<Breeder>(), "ID", "BreederName");
            var dog = new Dog();
            dog.DogCategories = new List<DogCategory>();
            PopulateAssignedCategoryData(_context, dog);
            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newDog = new Dog();
            if (selectedCategories != null)
            {
                newDog.DogCategories = new List<DogCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new DogCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newDog.DogCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Dog>(
            newDog,
            "Dog",
            i => i.Name, i => i.Breed,
            i => i.Price, i => i.BirthDate, i => i.BreederID))
            {
                _context.Dog.Add(newDog);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newDog);
            return Page();
        }
    }
    
}
