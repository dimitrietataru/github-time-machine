using Newtonsoft.Json;

namespace GitHubTimeMachine.Config
{
    internal sealed class ConfigDto
    {
        public int Year { get; set; }

        [JsonProperty("Paths.RepositoryPath")]
        public string RepositoryPath { get; set; }

        [JsonProperty("Paths.ExcelPath")]
        public string ExcelPath { get; set; }
    }
}
