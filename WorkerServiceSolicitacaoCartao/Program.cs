
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Interface;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Services;
using WorkerServiceSolicitacaoCartao.Domain.Application.UseCase;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;
using WorkerServiceSolicitacaoCartao.Endpoint.Processador;
using WorkerServiceSolicitacaoCartao.Infra.Register;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IUseCaseGerarCartao, UseCaseGerarCartao>();
        services.AddSingleton<IUseCaseSolicitaCartao, UseCaseSolicitaCartao>();
        services.AddSingleton<IGerarCartaoRepository, GerarCartaoRepository>();
        services.AddRabbitExtension();
        services.AddSQLExtension();
        services.AddHostedService<WorkerServiceSolicitaCartao>();
    })
    .Build();

host.Run();
