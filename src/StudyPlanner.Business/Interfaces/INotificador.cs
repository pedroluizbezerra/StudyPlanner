using StudyPlanner.Business.Notificacoes;
using System.Collections.Generic;

namespace StudyPlanner.Business.Interfaces
{
    public interface INotificador
    {

        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);

    }
}
