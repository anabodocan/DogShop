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

namespace DogShop.Pages.Breeders
{
    public class EditModel : PageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public EditModel(DogShop.Data.DogShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Breeder Breeder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Breeder = await _context.Breeder.FirstOrDefaultAsync(m => m.ID == id);

            if (Breeder == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Breeder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreederExists(Breeder.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BreederExists(int id)
        {
            return _context.Breeder.Any(e => e.ID == id);
        }
    }
}
