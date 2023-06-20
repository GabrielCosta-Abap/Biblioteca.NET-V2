using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Locacao
    {
        public int Id { get; set; }

        [Display(Name = "Livro"), Required(ErrorMessage = "Campo Obrigatório")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        [Display(Name = "Cliente"), Required(ErrorMessage = "Campo Obrigatório")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Usuário"), Required(ErrorMessage = "Campo Obrigatório")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Dt/Hr Locação"), Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataHoraLocacao { get; set;}

        [Display(Name = "Dt. Prevista Devol."), DataType(DataType.Date)]
        public DateTime DataPrevista { get; set; }

        [Display(Name = "Dt. Devolução"), DataType(DataType.Date)]
        public DateTime? DataDevolucao { get; set; }

        [Display(Name = "Valor Locação"), Required(ErrorMessage = "Campo Obrigatório")]
        public double ValorLocacao { get; set; }

        [Display(Name = "Multa Atraso")]
        public double? MultaAtraso { get; set; } 


    }
}
