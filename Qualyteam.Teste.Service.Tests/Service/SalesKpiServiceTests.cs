using NUnit.Framework;
using Qualyteam.Teste.Data.Repository.Interface;
using Moq;
using Qualyteam.Teste.Service.Implementations;
using System.Collections.Generic;
using System.Linq;
using Qualyteam.Teste.Domain.Entities;
using System;

namespace Qualyteam.Teste.Service.Tests.Service
{
    public class SalesKpiServiceTests
    {
        private Mock<ISalesKpiRepository> _salesKpiRepositoryMock;
        private SalesKpiService _salesKpiService;
        private List<SalesKpi> SalesKpis;

        [SetUp]
        public void Setup()
        {
            _salesKpiRepositoryMock = new Mock<ISalesKpiRepository>();
            _salesKpiService = new SalesKpiService(_salesKpiRepositoryMock.Object);

            SalesKpis = new List<SalesKpi>
            {
                new SalesKpi
                {
                    Amount = 100,
                    Date = DateTime.Now
                },
                new SalesKpi
                {
                    Amount = 200,
                    Date = DateTime.Now
                },
                new SalesKpi
                {
                    Amount = 300,
                    Date = DateTime.Now
                },
            };

        }

        [Test]
        public void GetKpi_ReturnsSuccess()
        {
            _salesKpiRepositoryMock
                .Setup(x => x.GetAll())
                .Returns(SalesKpis.AsQueryable());

            var result = _salesKpiService
                            .GetGroup();
            
            Assert.AreEqual(result.Average, SalesKpis.Average(x => x.Amount));
            Assert.AreEqual(result.Sum, SalesKpis.Sum(x => x.Amount));
        }
    }
}