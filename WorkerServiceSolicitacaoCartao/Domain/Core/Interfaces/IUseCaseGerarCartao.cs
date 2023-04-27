using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects;

namespace WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces
{
    public interface IUseCaseGerarCartao
    {
        public DadosGerados DadosCartao();
    }
}
