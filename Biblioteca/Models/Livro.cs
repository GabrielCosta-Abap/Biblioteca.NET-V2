using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Display(Name = "Nome do livro")]
        public string NomeLivro { get; set; }

        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        [Display(Name = "Editora")]
        public string Editora { get; set; }
        public int Ano { get; set; }

        [Display(Name = "Tema")]
        public string tema { get; set; }

        [Display(Name = "Nº do volume")]
        public int NumVolume { get; set; }

        [Display(Name = "Qtd. volumes")]
        public int QtdVolumes { get; set; }

        [Display(Name = "Valor locação")]
        public double ValorLocacao { get; set; }
    }
}