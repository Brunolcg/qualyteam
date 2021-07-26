using System.Linq;
using Microsoft.EntityFrameworkCore;
using Qualyteam.Teste.Data.Repository.Interface;
using Qualyteam.Teste.Domain.Entities;

namespace Qualyteam.Teste.Data.Repository
{
    public class SalesKpiRepository : ISalesKpiRepository
    {
        private readonly DbSet<SalesKpi> _dbSet;

        public SalesKpiRepository(DbContext context)
        {
            _dbSet = context.Set<SalesKpi>();
        }

        public IQueryable<SalesKpi> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}