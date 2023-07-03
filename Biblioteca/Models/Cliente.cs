using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome do cliente"), Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeCliente { get; set; }

        [Display(Name = "E-mail"), Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "O campo deve ser um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "Endereço"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório"), StringLength(11, MinimumLength = 11, ErrorMessage = "O campo deve ter 11 caracteres")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "A propriedade deve conter apenas números.")]
        public string Cpf { get; set; }

        [Display(Name = "Status ativo")]
        public string StatusAtivo { get; set; }
    }
}
