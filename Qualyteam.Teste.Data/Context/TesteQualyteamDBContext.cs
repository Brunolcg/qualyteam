using Microsoft.EntityFrameworkCore;
using Qualyteam.Teste.Domain.Entities;

namespace Qualyteam.Teste.Data.Context
{
    public class TesteQualyteamDBContext : DbContext
    {
        public TesteQualyteamDBContext(DbContextOptions<TesteQualyteamDBContext> options) : base (options)
        {

        }

        public DbSet<SalesKpi> SalesKpi { get; set; }
    }
}