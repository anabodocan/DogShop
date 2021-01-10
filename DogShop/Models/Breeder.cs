using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShop.Models
{
    public class Breeder
    {
        public int ID { get; set; }
        public string BreederName { get; set; }
        public ICollection<Dog> Dogs { get; set; }
    }
}
