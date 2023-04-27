using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Connection;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Interface;
using WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects;

namespace WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Services
{
    public class GerarCartaoRepository : IGerarCartaoRepository
    {
        private connectionStrings connectionStrings;
        public GerarCartaoRepository(connectionStrings _connectionStrings)
        {
            this.connectionStrings = _connectionStrings;
        }
        public string GerarCartaoNoDb(DadosGerados dadosGerados, DadosRecebidosFila dadosRecebidosFila)
        {
            try
            {
                using (var connect = new SqlConnection(connectionStrings.GetConnectionStrings()))
                {
                    var InserirCartao = $"INSERT INTO Cartao VALUES ('{dadosRecebidosFila.cartao.Id}', '{dadosRecebidosFila.CPF}', " +
                        $"'{dadosRecebidosFila.Nome}', '{dadosGerados.Cvv}', '{dadosGerados.Pan}', '{dadosGerados.Vencimento}'," +
                        $"{dadosGerados.Limite})";

                    connect.QueryAsync(InserirCartao).Wait();
                    return "Processado com sucesso";
                };
            }catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
