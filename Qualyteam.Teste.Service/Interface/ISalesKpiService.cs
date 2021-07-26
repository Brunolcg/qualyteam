using System.Collections.Generic;
using Qualyteam.Teste.Domain.Entities;
using Qualyteam.Teste.Domain.Enums;
using Qualyteam.Teste.Service.ViewModel;

namespace Qualyteam.Teste.Service.Interface
{
    public interface ISalesKpiService
    {
        List<SalesKpi> GetAll();
        SalesKpiViewModel GetGroup();
    }
}