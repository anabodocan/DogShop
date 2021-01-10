using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogShop.Data;
using DogShop.Models;

namespace DogShop.Pages.Dogs
{
    public class EditModel: DogCategoriesPageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public EditModel(DogShop.Data.DogShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        Dog = await _context.Dog
            .Include(b => b.Breeder)
            .Include(b => b.DogCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
           .FirstOrDefaultAsync(m => m.ID == id);

        if (Dog == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Dog);
            ViewData["BreederID"] = new SelectList(_context.Set<Breeder>(), "ID", "BreederName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
 {
            if (id == null)
            {
                return NotFound();
            }
            var dogToUpdate = await _context.Dog
            .Include(i => i.Breeder)
            .Include(i => i.DogCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (dogToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Dog>(
            dogToUpdate,
            "Dog",
            i => i.Name, i => i.Breed,
            i => i.Price, i => i.BirthDate, i => i.Breeder))
            {
                UpdateDogCategories(_context, selectedCategories, dogToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
          
            UpdateDogCategories(_context, selectedCategories, dogToUpdate);
            PopulateAssignedCategoryData(_context, dogToUpdate);
            return Page();
        }
    }
    
       
}
