using StudyPlanner.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace StudyPlanner.API.DTO
{
    public class ConhecimentoDTO
    {
        //[Key]
        public Guid Id { get; set;  }
        //TODO Criar resources com mensagens

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre menos que {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 5, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres.")]
        public int NivelConhecimentoAtual { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 5, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres.")]
        public int NivelConhecimentoDesejado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Prioridade { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //public string TipoConhecimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 0)]
        public string PlanoAcao { get; set; }

    }
}
