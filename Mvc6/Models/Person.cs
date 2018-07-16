using System.ComponentModel.DataAnnotations;
namespace Mvc6.Models
{

    public class Person
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Phonenumber { get; set; }
        [Required]
        public string City { get; set; }
    }
}