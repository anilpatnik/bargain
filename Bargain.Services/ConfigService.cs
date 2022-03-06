using Microsoft.Extensions.Configuration;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;

namespace Bargain.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfiguration _config;

        public ConfigService(IConfiguration config)
        {
            _config = config;
        }

        public string Secret => _config["Secret"];        
    }
}
