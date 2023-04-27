
using RabbitMQ.Client;
using System.Text.Json;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Connection;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Interface;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Services;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;
using WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects;

namespace WorkerServiceSolicitacaoCartao.Domain.Application.UseCase;

public class UseCaseSolicitaCartao : IUseCaseSolicitaCartao
{
    private IGerarCartaoRepository _repository;
    private IUseCaseGerarCartao _UseCaseGerarCartao;
    public UseCaseSolicitaCartao(IGerarCartaoRepository gerarCartaoRepository, IUseCaseGerarCartao useCaseGerarCartao)
    {
        _repository = gerarCartaoRepository;
        _UseCaseGerarCartao = useCaseGerarCartao;
    }
    public Task Executar(IModel channel, ulong deliverTag, string message)
    {
        var dadosFila = JsonSerializer.Deserialize<DadosRecebidosFila>(message);
        Console.WriteLine(dadosFila);
        var dadosGerados = _UseCaseGerarCartao.DadosCartao();

        _repository.GerarCartaoNoDb(dadosGerados,dadosFila);
        channel.BasicAck(deliverTag, false);
        return Task.CompletedTask;
    }
}
