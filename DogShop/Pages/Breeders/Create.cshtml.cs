using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogShop.Data;
using DogShop.Models;

namespace DogShop.Pages.Breeders
{
    public class CreateModel : PageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public CreateModel(DogShop.Data.DogShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Breeder Breeder { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Breeder.Add(Breeder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
