using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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