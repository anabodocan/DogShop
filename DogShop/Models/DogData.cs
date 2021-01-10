using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShop.Models
{
    public class DogData
    {
        public IEnumerable<Dog> Dogs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<DogCategory> SogCategories { get; set; }
    }
}
