using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Display(Name = "Nome do autor")]
        public string NomeAutor { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
