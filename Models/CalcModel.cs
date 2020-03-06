using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class CalcModel
    {
        public decimal Num1 { get; set; }

        public decimal Num2 { get; set; }

        public decimal Result { get; set; }
        public string Operacao { get; set; }
        public DateTime Data { get; set; }
    }
}
