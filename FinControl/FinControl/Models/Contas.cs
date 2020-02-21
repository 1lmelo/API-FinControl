using System;
using System.ComponentModel.DataAnnotations;
using FinControl.Enums;

namespace FinControl.Models
{
    public class Contas
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public string Fornecedor { get; set; }
        [EnumDataType(typeof(StatusPagamento))]
        public string Status { get; set; }
    }
}