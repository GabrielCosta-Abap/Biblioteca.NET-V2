using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome do cliente"), Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeCliente { get; set; }

        [Display(Name = "E-mail"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "Endereço"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "Status ativo")]
        public string StatusAtivo { get; set; }
    }
}
