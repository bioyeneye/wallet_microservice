using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WalletMicroservice.Common.Base
{
    public abstract class BaseService<T>
    {
        private readonly ILogger<T> _logger;

        protected BaseService(ILogger<T> logger)
        {
            _logger = logger;
        }

        protected void LogInformation(string message, object data)
        {
            _logger.LogInformation($"{message}: \n{JsonConvert.SerializeObject(data, Formatting.Indented)}\n");
        }

        protected void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, $"\n {message}");
        }
    }

}
