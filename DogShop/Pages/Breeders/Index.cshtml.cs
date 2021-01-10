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
    public class IndexModel : PageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public IndexModel(DogShop.Data.DogShopContext context)
        {
            _context = context;
        }

        public IList<Breeder> Breeder { get;set; }

        public async Task OnGetAsync()
        {
            Breeder = await _context.Breeder.ToListAsync();
        }
    }
}
