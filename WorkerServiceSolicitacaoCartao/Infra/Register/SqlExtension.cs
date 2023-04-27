using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Adapter.RabbitMQ;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Connection;

namespace WorkerServiceSolicitacaoCartao.Infra.Register
{
    public static class SQLExtension
    {
        public static void AddSQLExtension(this IServiceCollection service)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json").Build();
            service.AddSingleton(x => configuration.GetSection("SQLDBConnection").Get<connectionStrings>());
        }
    }
}
