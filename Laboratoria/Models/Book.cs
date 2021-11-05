using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratoria.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Musisz podać tytuł książki!")]
        [MinLength(2)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Musisz podoać autora!")]
        public string Author { get; set; }
        [Range(minimum: 2000, maximum: 2030, ErrorMessage = "Rok wydania musi być pomiędzy 2000 a 2030")]
        public int PublishingYear { get; set; }
        [HiddenInput]
        public int Id { get; set; }
    }
}