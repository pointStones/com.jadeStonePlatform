namespace com.jadeStonePlatform.definition.Configuration
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class appsettings
    {

        /// <summary>
        /// 日志
        /// </summary>
        public Logging Logging { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AllowedHosts { get; set; }

        /// <summary>
        /// 邮箱配置
        /// </summary>
        public maillServerConfiguration maillServerConfiguration { get; set; }
    }
}
