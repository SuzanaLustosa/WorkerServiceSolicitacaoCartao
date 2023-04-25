using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;

namespace WorkerServiceSolicitacaoCartao.Domain.Application.UseCase;

public class UseCaseSolicitaCartao : IUseCaseSolicitaCartao
{
    private string queueName = "SolicitarCartao";
    private string host = "192.168.0.63";
    public Task Executar()
    {
        #region chamada rabbit
        var factory = new ConnectionFactory { HostName = host };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
       string message = "";

        channel.QueueDeclare(queue: queueName,
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
        };
        channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);
        #endregion

        #region construindo dados cartao
        var ret = message;
        #endregion

        return Task.CompletedTask;
    }
}
