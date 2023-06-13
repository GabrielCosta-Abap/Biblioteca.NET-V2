using NuGet.Protocol.Plugins;
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

        public ICollection<Livro> Livros { get; set; } = new List<Livro>();

        public Autor()
        {
        }

        public Autor(string name)
        {
            NomeAutor = name;
        }
    }
}
