using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces
{
    public interface IUseCaseGerarCartao
    {
        public string GerarPan();
        public string GerarCvv();
        public string GerarLimite();
    }
}
