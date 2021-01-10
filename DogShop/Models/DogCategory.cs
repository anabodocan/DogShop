using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShop.Models
{
    public class DogCategory
    {
        public int ID { get; set; }
        public int DogID { get; set; }
        public Dog Dog { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
