using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Qualyteam.Teste.Domain.Entities;
using Qualyteam.Teste.Domain.Enums;
using Qualyteam.Teste.Service.Interface;
using Qualyteam.Teste.Service.ViewModel;

namespace Qualyteam.Teste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesKpiController : ControllerBase
    {
        private readonly ISalesKpiService _salesKpiService;
        
        public SalesKpiController
        (
            ISalesKpiService salesKpiService 
        )
        {
            _salesKpiService = salesKpiService;
        }
        
        [HttpGet]
        public SalesKpiViewModel Get()
        {
            return _salesKpiService.GetGroup();
        }
    }
}