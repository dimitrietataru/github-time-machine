using GitHubTimeMachine.Dtos;
using GitHubTimeMachine.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Services
{
    internal sealed class ConfigurationService : IConfigurationService
    {
        private const string CONFIG_FILE_NAME = "config.json";

        public async Task<ConfigDto> ReadConfigAsync()
        {
            string configFilePath = Path.Combine(Environment.CurrentDirectory, CONFIG_FILE_NAME);

            using var stream = new StreamReader(configFilePath);
            string jsonConfig = await stream.ReadToEndAsync();

            return JsonConvert.DeserializeObject<ConfigDto>(jsonConfig);
        }
    }
}
