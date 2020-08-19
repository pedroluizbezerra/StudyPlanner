using StudyPlanner.Business.Interfaces;
using StudyPlanner.Business.Models;
using StudyPlanner.Data.Context;

namespace StudyPlanner.Data.Repository
{
    public class ConhecimentoRepository : Repository<Conhecimento>, IConhecimentoRepository
    {
        public ConhecimentoRepository(StudyPlannerContext context) : base(context)
        {

        }
    }
}
