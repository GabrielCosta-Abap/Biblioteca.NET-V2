namespace Biblioteca.Models.ViewModels
{
    public class LivroFromViewModels
    {
        public Livro Livro { get; set; }
        public ICollection<Autor> Autors { get; set; }
    }
}