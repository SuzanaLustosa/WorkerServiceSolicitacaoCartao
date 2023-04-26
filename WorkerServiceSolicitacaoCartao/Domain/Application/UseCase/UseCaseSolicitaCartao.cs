using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces.Adappters;

namespace WorkerServiceSolicitacaoCartao.Domain.Application.UseCase;

public class UseCaseSolicitaCartao : IUseCaseSolicitaCartao
{
    private IRConsumer _rabbit;

    public UseCaseSolicitaCartao(IRConsumer rabbit)
    {
        _rabbit= rabbit;
    }
    public Task Executar()
    { 
        var rabbit = _rabbit.RecebendoMensagemRabbit();

        return Task.CompletedTask;
    }
}
