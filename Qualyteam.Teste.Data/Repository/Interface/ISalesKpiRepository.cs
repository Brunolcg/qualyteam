using System.Linq;
using Qualyteam.Teste.Domain.Entities;

namespace Qualyteam.Teste.Data.Repository.Interface
{
    public interface ISalesKpiRepository
    {
         IQueryable<SalesKpi> GetAll();
    }
}