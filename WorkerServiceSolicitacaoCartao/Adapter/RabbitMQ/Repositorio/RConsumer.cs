using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces.Adappters;

namespace WorkerServiceSolicitacaoCartao.Adapter.RabbitMQ.Repositorio
{ 
    public class RConsumer : IRConsumer
    {
        private string queueName = "clienteQueue";
        private string host = "192.168.0.63";
        public string RecebendoMensagemRabbit()
        {
            var factory = new ConnectionFactory { HostName = host };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            string message = "";

            channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine("Aguardando dados.");

            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recebido {message}");
                channel.BasicAck(ea.DeliveryTag, true);
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: false,
                                 consumer: consumer);

            return message;
        }
    }
}
