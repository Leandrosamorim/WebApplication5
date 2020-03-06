using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalcRepository _calcRepository;

        public CalcController(
            ICalcRepository calcRepository)
        {
            _calcRepository = calcRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var calcs = _calcRepository.GetAll();
            return View(calcs);
        }
        public IActionResult Addition(CalcModel newCalcModel)
        {
            try
            {
                decimal result = newCalcModel.Num1 + newCalcModel.Num2;
                newCalcModel.Result = result;
                newCalcModel.Operacao = "Adição";
                newCalcModel.Data = DateTime.Now;
                _calcRepository.Add(newCalcModel);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

             
            
        }
        public IActionResult Subtraction(CalcModel newCalcModel)
        {
            try
            {
                decimal result = newCalcModel.Num1 - newCalcModel.Num2;
                newCalcModel.Result = result;
                newCalcModel.Operacao = "Subtração";
                newCalcModel.Data = DateTime.Now;
                _calcRepository.Add(newCalcModel);
                
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
            
        }
        public IActionResult Multiplication(CalcModel newCalcModel)
        {
            try
            {
                decimal result = newCalcModel.Num1 * newCalcModel.Num2;
                newCalcModel.Result = result;
                newCalcModel.Operacao = "Multiplicação";
                newCalcModel.Data = DateTime.Now;
                _calcRepository.Add(newCalcModel);
                
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Division(CalcModel newCalcModel)
        {
            try
            {
                decimal result = newCalcModel.Num1 / newCalcModel.Num2;
                newCalcModel.Result = result;
                newCalcModel.Operacao = "Divisão";
                newCalcModel.Data = DateTime.Now;
                _calcRepository.Add(newCalcModel);
                
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}