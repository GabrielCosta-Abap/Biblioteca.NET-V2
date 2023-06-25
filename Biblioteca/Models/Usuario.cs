using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Senha { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "Status ativo")]
        public string Status { get; set; }


    }
}
