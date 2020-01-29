using GitHubTimeMachine.Extensions;
using System;
using System.IO;

namespace GitHubTimeMachine.Dtos.CommitArtDtos
{
    internal sealed class CommitArtDto
    {
        public bool Enabled { private get; set; }
        public int Year { get; set; }
        public string RepositoryPath { get; set; }

        public ExcelConfigDto ExcelConfig { get; set; }

        public bool ShouldRun()
        {
            if (!Enabled)
            {
                Console.WriteLine("Commit art | Status: OFF");

                return false;
            }

            if (!IsValid())
            {
                return false;
            }

            return true;
        }

        private bool IsValid()
        {
            if (Year < 2006)
            {
                Console.WriteLine($"Commit art | Invalid year: { Year }");

                return false;
            }

            if (!Directory.Exists(RepositoryPath))
            {
                Console.WriteLine($"Commit art | Invalid repository path");

                return false;
            }

            if (!File.Exists(ExcelConfig.FilePath))
            {
                Console.WriteLine($"Commit art | Invalid excel file path");

                return false;
            }

            if (!ExcelConfig.SheetNumber.IsInInterval(leftBound: 0))
            {
                Console.WriteLine($"Commit art | Invalid sheet number: { ExcelConfig.SheetNumber }");

                return false;
            }

            return true;
        }
    }
}
