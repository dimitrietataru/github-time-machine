using System;
using System.IO;

namespace GitHubTimeMachine.Dtos
{
    internal sealed class CommitArtDto
    {
        public bool Enabled { private get; set; }
        public int Year { get; set; }
        public string RepositoryPath { get; set; }

        public string ExcelPath { get; set; }
        public int SheetNumber { get; set; } = 0;

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

            if (!File.Exists(ExcelPath))
            {
                Console.WriteLine($"Commit art | Invalid excel path");

                return false;
            }

            return true;
        }
    }
}
