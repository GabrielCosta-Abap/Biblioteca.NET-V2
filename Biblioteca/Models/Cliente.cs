using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome do cliente")]
        public string NomeCliente { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Cpf { get; set; }

        [Display(Name = "Status ativo")]
        public string StatusAtivo { get; set; }
    }
}
