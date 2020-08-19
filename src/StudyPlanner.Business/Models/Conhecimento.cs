
namespace StudyPlanner.Business.Models
{
    public class Conhecimento : Entity
    {

        public string Nome { get; set; }
        public int NivelConhecimentoAtual { get; set; }
        public int NivelConhecimentoDesejado { get; set; }
        public int Prioridade { get; set; }
        public TipoConhecimento TipoConhecimento { get; set; }
        public string PlanoAcao { get; set; }
    }
}
