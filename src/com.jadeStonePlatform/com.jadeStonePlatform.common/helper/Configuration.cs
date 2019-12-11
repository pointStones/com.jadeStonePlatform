using com.jadeStonePlatform.common.Ex;
using com.jadeStonePlatform.definition.Configuration;

namespace com.jadeStonePlatform.common.helper
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public static class Configuration
    {
        static Configuration()
        {
            MaillConfiguration = new maillServerConfiguration
            {
                fromMail = ConfigurationEx.Get("maillServerConfiguration:fromMail"),
                nickName = ConfigurationEx.Get("maillServerConfiguration:nickName"),
                pwd = ConfigurationEx.Get("maillServerConfiguration:pwd"),
                smtpserver = ConfigurationEx.Get("maillServerConfiguration:smtpserver"),
                userName = ConfigurationEx.Get("maillServerConfiguration:userName")
            };
            maillRecipientConfiguration = ConfigurationEx.Get("maillRecipientConfiguration");
        }

        public static maillServerConfiguration MaillConfiguration { get; private set; }
        public static string maillRecipientConfiguration { get; set; }
    }
}
