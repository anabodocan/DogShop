using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogShop.Data;
using DogShop.Models;

namespace DogShop.Pages.Breeders
{
    public class DeleteModel : PageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public DeleteModel(DogShop.Data.DogShopContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Breeder = await _context.Breeder.FindAsync(id);

            if (Breeder != null)
            {
                _context.Breeder.Remove(Breeder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
