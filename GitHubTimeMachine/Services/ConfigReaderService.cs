using GitHubTimeMachine.Dtos;
using GitHubTimeMachine.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Services
{
    internal sealed class ConfigReaderService : IConfigReaderService
    {
        private const string CONFIG_FILE_NAME = "config.json";

        public async Task<ConfigDto> GetConfigAsync()
        {
            var configPath = Path.Combine(Environment.CurrentDirectory, CONFIG_FILE_NAME);

            using var stream = new StreamReader(configPath);
            string serializedStream = await stream.ReadToEndAsync();

            stream.Close();

            return JsonConvert.DeserializeObject<ConfigDto>(serializedStream);
        }
    }
}
