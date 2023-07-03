using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Display(Name = "Nome do autor"), Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeAutor { get; set; }


        [EmailAddress(ErrorMessage = "O campo deve ser um endereço de e-mail válido.")]
        [Display(Name = "E-mail"), Required(ErrorMessage = "Campo Obrigatório")]
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
