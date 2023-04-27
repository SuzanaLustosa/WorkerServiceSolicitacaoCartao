using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Adapter.RabbitMQ;

namespace WorkerServiceSolicitacaoCartao.Infra.Register
{
    public static class RabbitExtension
    {
        public static void AddRabbitExtension(this IServiceCollection service)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json").Build();
            service.AddSingleton(x => configuration.GetSection("Rabbitmq").Get<Conexao>());
        }
    }
}
