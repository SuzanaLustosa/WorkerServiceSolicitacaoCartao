using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSolicitacaoCartao.Adapter.SQL.Connection
{
    public class connectionStrings
    {
        public string Servidor { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string BancoDados { get; set; }

        public string GetConnectionStrings()
        {
            return $"Data Source={Servidor};Initial Catalog={BancoDados};Persist Security Info=True;User ID={Usuario};Password={Senha}";
        }
    }
}
