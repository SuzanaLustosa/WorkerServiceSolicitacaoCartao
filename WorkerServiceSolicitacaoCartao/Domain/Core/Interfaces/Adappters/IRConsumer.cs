using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces.Adappters
{
    public interface IRConsumer 
    {
        string RecebendoMensagemRabbit();
    }
}
