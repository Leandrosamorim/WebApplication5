using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class CalcMDFRepository : ICalcRepository
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\leandro.amorim\source\repos\WebApplication5\App_Data\CalcMDF.mdf;Integrated Security=True;Connect Timeout=30";

        public IEnumerable<CalcModel> GetAll()
        {
            var cmdText = $"SELECT Num1, Num2, Result, Operacao, Data FROM Calc";
            var calcs = new List<CalcModel>();

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var Num1ColumnIndex = reader.GetOrdinal("Num1");
                    var Num2ColumnIndex = reader.GetOrdinal("Num2");
                    var ResultColumnIndex = reader.GetOrdinal("Result");
                    var OpColumnIndex = reader.GetOrdinal("Operacao");
                    var DateColumnIndex = reader.GetOrdinal("Data");
                    while (reader.Read())
                    {
                        var num1 = reader.GetFieldValue<decimal>(Num1ColumnIndex);
                        var num2 = reader.GetFieldValue<decimal>(Num2ColumnIndex);
                        var result = reader.GetFieldValue<decimal>(ResultColumnIndex);
                        var op = reader.GetFieldValue<string>(OpColumnIndex);
                        var date = reader.GetFieldValue<DateTime>(DateColumnIndex);

                        var novaOperacao = new CalcModel
                        {
                            Num1 = num1,
                            Num2 = num2,
                            Result = result,
                            Operacao = op,
                            Data = date
                        };
                        calcs.Add(novaOperacao);
                    }
                }
            }
            return calcs;

        }
        public void Add(CalcModel newCalcModel)
        {
            var cmdText = "INSERT INTO Calc" +
                "		(Num1, Num2, Result, Operacao, Data)" +
                "VALUES	(@calcNum1, @calcNum2, @calcResult, @calcOp, @calcDate);";

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters
                    .Add("@calcNum1", SqlDbType.Decimal).Value = newCalcModel.Num1;
                sqlCommand.Parameters
                    .Add("@calcNum2", SqlDbType.Decimal).Value = newCalcModel.Num2;
                sqlCommand.Parameters
                    .Add("@calcResult", SqlDbType.Decimal).Value = newCalcModel.Result;
                sqlCommand.Parameters
                    .Add("@calcOp", SqlDbType.VarChar).Value = newCalcModel.Operacao;
                sqlCommand.Parameters
                    .Add("@calcDate", SqlDbType.DateTime2).Value = newCalcModel.Data;

                sqlConnection.Open();

                var resultScalar = sqlCommand.ExecuteScalar();

            }
        }
    }
}
