namespace Biblioteca.Models.ViewModels
{
    public class LocacaoFromViewModels
    {
        public Locacao Locacao { get; set; }
        public ICollection<Livro> Livros { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
