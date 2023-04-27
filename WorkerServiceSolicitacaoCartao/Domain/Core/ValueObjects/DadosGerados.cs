using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects
{
    public class DadosGerados
    {
        public string Pan { get; set; }
        public string Cvv { get; set; }
        public double Limite { get; set; }
        public string Vencimento { get; set; }
    }
}
