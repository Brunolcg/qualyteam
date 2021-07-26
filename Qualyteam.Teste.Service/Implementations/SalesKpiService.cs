using System.Collections.Generic;
using System.Linq;
using Qualyteam.Teste.Data.Repository.Interface;
using Qualyteam.Teste.Domain.Entities;
using Qualyteam.Teste.Domain.Enums;
using Qualyteam.Teste.Service.Interface;
using Qualyteam.Teste.Service.ViewModel;

namespace Qualyteam.Teste.Service.Implementations
{
    public class SalesKpiService : ISalesKpiService
    {
        private readonly ISalesKpiRepository _salesKpiRepository;
        public SalesKpiService
        (
            ISalesKpiRepository salesKpiRepository 
        )
        {
            _salesKpiRepository = salesKpiRepository;
        }

        public List<SalesKpi> GetAll()
        {
            return _salesKpiRepository
                        .GetAll()
                        .ToList();
        }

        public SalesKpiViewModel GetGroup()
        {
            return _salesKpiRepository
                        .GetAll()
                        .GroupBy(x => new {})
                        .Select(x => new SalesKpiViewModel
                        {
                            Sum = x.Sum(k => k.Amount),
                            Average = x.Average(k => k.Amount)
                        })
                        .FirstOrDefault();
        }

    }
}