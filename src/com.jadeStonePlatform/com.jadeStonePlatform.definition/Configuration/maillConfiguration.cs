namespace com.jadeStonePlatform.definition.Configuration
{
    /// <summary>
    /// 邮箱配置
    /// </summary>
    public class maillServerConfiguration
    {
        /// <summary>
        /// 邮箱服务地址
        /// </summary>
        public string smtpserver { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }

        /// <summary>
        /// 发件昵称
        /// </summary>
        public string nickName { get; set; }

        /// <summary>
        /// 发件地址
        /// </summary>
        public string fromMail { get; set; }
    }
}