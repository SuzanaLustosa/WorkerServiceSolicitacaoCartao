using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSolicitacaoCartao.Adapter.RabbitMQ
{
    public class Conexao
    {
        public string host { get; set; }
        public string queueName { get; set; }
    }
}
