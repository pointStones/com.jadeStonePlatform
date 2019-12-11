using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace com.jadeStonePlatform.common.helper
{
    /// <summary>
    /// 邮件
    /// </summary>
    public static class Mail
    {
        /// <summary>
        /// 异步发送电子邮件
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        public static async Task SendMailAsync(MailRequest mailRequest)
        {
            var smtpClient = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,//指定电子邮件发送方式
                Host = mailRequest.smtpserver,//指定SMTP服务器
                Credentials = new NetworkCredential(mailRequest.userName, mailRequest.pwd),//用户名和密码
                EnableSsl = mailRequest.enableSsl
            };
            var fromAddress = new MailAddress(mailRequest.fromMail, mailRequest.nickName);
            var toAddress = new MailAddress(mailRequest.toMail);
            var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = mailRequest.subj,//主题
                Body = mailRequest.bodys, //内容
                BodyEncoding = Encoding.Default,//正文编码
                IsBodyHtml = true,//设置为HTML格式
                Priority = MailPriority.Normal//优先级
            };
            await smtpClient.SendMailAsync(mailMessage);
        }
    }

    /// <summary>
    /// mail requests
    /// </summary>
    public class MailRequest
    {
        /// <summary>
        /// SMTP服务器
        /// </summary>
        public string smtpserver { get; set; }

        /// <summary>
        /// 是否启用SSL加密
        /// </summary>
        public bool enableSsl { get; set; }

        /// <summary>
        /// 登录帐号
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string pwd { get; set; }

        /// <summary>
        /// 发件人昵称
        /// </summary>
        public string nickName { get; set; }

        /// <summary>
        /// 发件人
        /// </summary>
        public string fromMail { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public string toMail { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string subj { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string bodys { get; set; }
    }
}
