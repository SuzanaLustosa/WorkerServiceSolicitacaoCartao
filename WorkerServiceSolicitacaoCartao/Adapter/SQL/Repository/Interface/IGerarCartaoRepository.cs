using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects;

namespace WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Interface
{
    public interface IGerarCartaoRepository
    {
        public string GerarCartaoNoDb(DadosGerados dadosGerados, DadosRecebidosFila dadosRecebidosFila);
    }
}
