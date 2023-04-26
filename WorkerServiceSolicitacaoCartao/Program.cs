using WorkerServiceSolicitacaoCartao.Adapter.RabbitMQ.Repositorio;
using WorkerServiceSolicitacaoCartao.Domain.Application.UseCase;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces.Adappters;
using WorkerServiceSolicitacaoCartao.Endpoint.Processador;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IUseCaseSolicitaCartao, UseCaseSolicitaCartao>();
        services.AddSingleton<IRConsumer, RConsumer>();
        services.AddHostedService<WorkerServiceSolicitaCartao>();
    })
    .Build();

host.Run();
