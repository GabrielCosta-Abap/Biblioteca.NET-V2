namespace Biblioteca.Models.ViewModels
{
    public class LivroFromViewModels
    {
        public Livro Livro { get; set; }
        public ICollection<Autor> Autors { get; set; }
        public Locacao Locacao { get; set; }
        public ICollection<Locacao> Locacaos { get; set; }

    }
}