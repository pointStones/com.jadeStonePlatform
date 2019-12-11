using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace com.jadeStonePlatform.common.Ex
{
    /// <summary>
    /// configuration extension
    /// </summary>
    public class ConfigurationEx
    {
        /// <summary>
        /// AppSettings
        /// </summary>
        public static IConfiguration AppSettings { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configuration"></param>
        public static void Init(IConfiguration configuration)
        {
            AppSettings = configuration;
        }

        /// <summary>
        /// 获取配置值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Get(string name)
        {
            return AppSettings[name];
        }

        /// <summary>
        /// IConfigurationSection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IConfigurationSection GetSection(string name)
        {
            return AppSettings.GetSection(name);
        }

        /// <summary>
        /// IConfigurationSection
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IConfigurationSection> GetChildren()
        {
            return AppSettings.GetChildren();
        }

        /// <summary>
        /// Get Connection String
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            return AppSettings.GetConnectionString(name);
        }

        /// <summary>
        /// Get Section Exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Exist(string name)
        {
            return GetSection(name).Exists();
        }
    }
}
