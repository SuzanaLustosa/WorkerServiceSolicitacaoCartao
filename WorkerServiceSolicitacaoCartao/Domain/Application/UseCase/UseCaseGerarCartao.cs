using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;

namespace WorkerServiceSolicitacaoCartao.Domain.Application.UseCase
{
    public class UseCaseGerarCartao : IUseCaseGerarCartao
    {
        public string GerarPan()
        {
            Random random = new Random();
            string Pan = "";

            for (int i = 0; i < 16; i++)
            {
                int numero = random.Next(1, 101);
                Pan += numero.ToString();

                if (i != 17)
                {
                    Pan += " ";
                }
            }

            return Pan;
        }

        public string GerarCvv()
        {
            Random random = new Random();
            string Cvv = "";

            for (int i = 0; i < 3; i++)
            {
                int numero = random.Next(1, 101);
                Cvv += numero.ToString("D3");

                if (i != 4)
                {
                    Cvv += " ";
                }
            }

            return Cvv.ToString();

        }

        public string GerarLimite()
        {
            throw new NotImplementedException();
        }
    }
}
