using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;
using WorkerServiceSolicitacaoCartao.Adapter.RabbitMQ;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;

namespace WorkerServiceSolicitacaoCartao.Endpoint.Processador
{
    public class WorkerServiceSolicitaCartao : BackgroundService
    {
        private readonly ILogger<WorkerServiceSolicitaCartao> _logger;
        private IUseCaseSolicitaCartao _useCaseSolicitaCartao;
        private Conexao _conexao;
        private IModel channel;

        public WorkerServiceSolicitaCartao(ILogger<WorkerServiceSolicitaCartao> logger, IUseCaseSolicitaCartao Solicita, Conexao conexao)
        {
            _conexao = conexao;
            _useCaseSolicitaCartao= Solicita;
            _logger = logger;

            var factory = new ConnectionFactory { HostName = _conexao.host };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(queue: _conexao.queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Processamento iniciado");
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recebido {message}");

                Task task = new Task(() => _useCaseSolicitaCartao.Executar(channel, ea.DeliveryTag, message));
                task.Start();
            };
            channel.BasicConsume(queue:_conexao.queueName,
                                 autoAck: false,
                                 consumer: consumer);

        

        }
    }
}