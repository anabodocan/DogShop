using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShop.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<DogCategory> DogCategories { get; set; }
    }
}
