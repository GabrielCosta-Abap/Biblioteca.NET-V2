namespace Biblioteca.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string StatusAtivo { get; set; }
    }
}
