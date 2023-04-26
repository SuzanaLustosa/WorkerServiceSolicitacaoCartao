﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSolicitacaoCartao.Domain.Core.ValueObjects
{
    public class PrimeiroCartao
    {
        public Cartao cartao { get; set; }
        public string Id { get; set; }
        public string SenhaRef { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroPan { get; set; }
        public string Cvv { get; set; }
        public float Limite { get; set; }
        public string Status { get; set; }
    }

    public class Cartao
    {
        public string Id { get; set; }
    }
}

