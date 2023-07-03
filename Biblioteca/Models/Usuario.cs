using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Display(Name = "Nome do usuário"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }


        [EmailAddress(ErrorMessage = "O campo deve ser um endereço de e-mail válido.")]
        [Display(Name = "E-mail"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Endereço"), Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "Status ativo")]
        public string Status { get; set; }


    }
}
