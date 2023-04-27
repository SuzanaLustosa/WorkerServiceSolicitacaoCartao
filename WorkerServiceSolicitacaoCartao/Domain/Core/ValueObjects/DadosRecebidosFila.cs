using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects
{
    public class DadosRecebidosFila
    {
        public IdCartao cartao { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }

    public class IdCartao
    {
        public string Id { get; set; }
    }
}

