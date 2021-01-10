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
    public class DetailsModel : PageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public DetailsModel(DogShop.Data.DogShopContext context)
        {
            _context = context;
        }

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
    }
}
