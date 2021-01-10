using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogShop.Models
{
    public class Dog
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Dog's Name")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$"), Required,
StringLength(50, MinimumLength = 3)]

        public string Breed { get; set; }

        [Range(1, 2000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int BreederID { get; set; }
        public Breeder Breeder { get; set; }
        public ICollection<DogCategory> DogCategories { get; set; }
    }
}
