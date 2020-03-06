using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public interface ICalcRepository
    {
        IEnumerable<CalcModel> GetAll();
        void Add(CalcModel newCalc);
        
    }
}
