using NuGet.Protocol.Plugins;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string NomeLivro { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public string Editora { get; set; }
        public int Ano { get; set; }
        public string tema { get; set; }
        public int NumVolume { get; set; }
        public int QtdVolumes { get; set; }
        public double ValorLocacao { get; set; }
    }
}