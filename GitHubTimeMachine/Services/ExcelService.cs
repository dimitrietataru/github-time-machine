using ExcelDataReader;
using GitHubTimeMachine.Interfaces;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace GitHubTimeMachine.Services
{
    internal sealed class ExcelService : IExcelService
    {
        private const int DAYS_IN_WEEK = 7;
        private const int HEADER_COUNT = 1;

        public DataTable ReadSheet(string excelFilePath, int sheetNumber = 0)
        {
            using var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateOpenXmlReader(
                fileStream: stream,
                configuration: new ExcelReaderConfiguration()
                {
                    FallbackEncoding = Encoding.GetEncoding(1252)
                });

            var dataSet = reader.AsDataSet(
                configuration:new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true }
                });

            return dataSet.Tables[sheetNumber];
        }

        public int[][] ParseSheet(DataTable dataTable)
        {
            var result = new int[DAYS_IN_WEEK][];

            for (int row = 0; row < dataTable.Rows.Count - 1; ++row)
            {
                var currentRowData = dataTable.Rows[row].ItemArray.Skip(HEADER_COUNT).ToArray();
                result[row] = Array.ConvertAll(currentRowData, Convert.ToInt32);
            }

            return result;
        }
    }
}
