using WorkerServiceSolicitacaoCartao.Domain.Application.UseCase;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;
using WorkerServiceSolicitacaoCartao.Endpoint.Processador;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IUseCaseSolicitaCartao, UseCaseSolicitaCartao>();
        services.AddHostedService<WorkerServiceSolicitaCartao>();
    })
    .Build();

host.Run();
