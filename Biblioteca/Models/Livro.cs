using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Display(Name = "Nome do livro"), Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeLivro { get; set; }

        [Display(Name = "Autor"), Required(ErrorMessage = "Campo Obrigatório")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public Autor Autor { get; set; }

        [Display(Name = "Editora"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Editora { get; set; }

        [Range(1000, int.MaxValue, ErrorMessage = "O valor do ano deve ser maior ou igual a 1000."), Required(ErrorMessage = "Campo Obrigatório")]
        public int Ano { get; set; }

        [Display(Name = "Tema"), Required(ErrorMessage = "Campo Obrigatório")]
        public string tema { get; set; }

        [Display(Name = "Nº do volume"), Required(ErrorMessage = "Campo Obrigatório")]
        public int NumVolume { get; set; }

        [Display(Name = "Qtd. volumes"), Required(ErrorMessage = "Campo Obrigatório")]
        public int QtdVolumes { get; set; }

        [Display(Name = "Valor locação"), Required(ErrorMessage = "Campo Obrigatório")]
        public double ValorLocacao { get; set; }
    }
}