using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.ConfigTool
{
    public static class ConfigHelper
    {
        /// <summary>
        /// 根據傳入的appsettings.json中的節點路徑，找出對應的value。節點路徑要用：分開
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        public static string GetConfig(string jsonFileName,string jsonPath)
        {
            ArgumentNullException.ThrowIfNull(jsonFileName);
            ArgumentNullException.ThrowIfNull(jsonPath);    
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile(jsonFileName, optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();
            if (config == null) throw new Exception("IConfiguration config  is null");
            if (config[jsonPath] == null) throw new Exception($"[{jsonPath}] is not find");
            return Convert.ToString(config[jsonPath]);

        }

        /// <summary>
        /// 根據傳入的appsettings.json中的節點路徑，把Section下的設定用T撈出來
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public static IOptionsSnapshot<T> GetConfigByOption<T>(string jsonFileName, string section) where T : class 
        {
            ArgumentNullException.ThrowIfNull(jsonFileName);
            ArgumentNullException.ThrowIfNull(section);
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile(jsonFileName, optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();
            if (config == null) throw new Exception("IConfiguration config  is null");
            ServiceCollection services = new ServiceCollection();
            var serviceProvider=services.AddOptions()
            .Configure<T>(e=>config.GetSection(section).Bind(e))
            .BuildServiceProvider();
            return serviceProvider.GetService<IOptionsSnapshot<T>>();

        }



    }
}
