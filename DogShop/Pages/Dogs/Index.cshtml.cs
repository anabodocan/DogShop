using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogShop.Data;
using DogShop.Models;

namespace DogShop.Pages.Dogs
{
    public class IndexModel : PageModel
    {
        private readonly DogShop.Data.DogShopContext _context;

        public IndexModel(DogShop.Data.DogShopContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; }
        public DogData DogD { get; set; }
        public int DogID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            DogD = new DogData();

            DogD.Dogs = await _context.Dog
            .Include(b => b.Breeder)
            .Include(b => b.DogCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                DogID = id.Value;
                Dog dog = DogD.Dogs
                .Where(i => i.ID == id.Value).Single();
                DogD.Categories = dog.DogCategories.Select(s => s.Category);
            }
        }

        public async Task OnGetAsync()
        {
            Dog = await _context.Dog
                .Include(b => b.Breeder).ToListAsync();
        }
    }
}
