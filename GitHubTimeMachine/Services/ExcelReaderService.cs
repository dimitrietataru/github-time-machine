using ExcelDataReader;
using GitHubTimeMachine.Interfaces;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace GitHubTimeMachine.Services
{
    internal sealed class ExcelReaderService : IExcelReaderService
    {
        public DataTable OpenSheet(string filePath, int sheetNumber = 0)
        {
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateOpenXmlReader(
                stream,
                new ExcelReaderConfiguration()
                {
                    FallbackEncoding = Encoding.GetEncoding(1252)
                });

            var dataSet = reader.AsDataSet(
                new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true }
                });

            return dataSet.Tables[sheetNumber];
        }

        public int[][] ParseSheet(DataTable dataTable)
        {
            var result = new int[7][];

            for (int row = 0; row < dataTable.Rows.Count - 1; ++row)
            {
                var currentRowData = dataTable.Rows[row].ItemArray.Skip(1).ToArray();
                result[row] = Array.ConvertAll(currentRowData, Convert.ToInt32);
            }

            return result;
        }
    }
}
