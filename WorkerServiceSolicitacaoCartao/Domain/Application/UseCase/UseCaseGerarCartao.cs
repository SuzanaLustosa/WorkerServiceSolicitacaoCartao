using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Interface;
using WorkerServiceSolicitacaoCartao.Adapter.SQL.Repository.Services;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;
using WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects;

namespace WorkerServiceSolicitacaoCartao.Domain.Application.UseCase
{
    public class UseCaseGerarCartao : IUseCaseGerarCartao
    {
        private string GerarPan()
        {
            Random random = new Random();
            string Pan = "";

            for (int i = 0; i < 16; i++)
            {
                int numero = random.Next(1, 9);
                Pan += numero.ToString();

                if (i != 17)
                {
                    Pan += "";
                }
            }

            return Pan;
        }
        private string GerarCvv()
        {
            Random random = new Random();
            string Cvv = "";

            for (int i = 0; i < 3; i++)
            {
                int numero = random.Next(1, 9);
                Cvv += numero.ToString();

                if (i != 4)
                {
                    Cvv += "";
                }
            }

            return Cvv.ToString();

        }
        private double GerarLimite()
        {
            double limite = 1000;
            return limite;
        }
        private string GerarVencimento()
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddYears(4);
            return dateTime.ToString("dd/MM/yyyy");
        }
        
        public DadosGerados DadosCartao()
        {
            return new DadosGerados
            {
                Cvv = GerarCvv(),
                Limite = GerarLimite(),
                Pan = GerarPan(),
                Vencimento = GerarVencimento()
            };
        }
    }
}
