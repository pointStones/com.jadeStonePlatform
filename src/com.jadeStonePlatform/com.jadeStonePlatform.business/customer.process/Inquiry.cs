using System;
using System.Collections.Generic;
using System.Text;
using com.jadeStonePlatform.common.helper;
using Newtonsoft.Json;
using com.jadeStonePlatform.definition.Models;
using com.jadeStonePlatform.common.tools;

namespace com.jadeStonePlatform.business.customer.process
{
    /// <summary>
    /// 询价
    /// </summary>
    public class Inquiry
    {

        /// <summary>
        /// 提交询价
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public string SubmitInquiry(SubmitInquiryRequest customer)
        {
            if (customer == null) return "请填写个人信息";
            if (string.IsNullOrWhiteSpace(customer.email) && string.IsNullOrWhiteSpace(customer.telephone)) return "请填写联系方式";
            SendMailToBusiness(customer);
            return "";
        }

        private void SendMailToBusiness(SubmitInquiryRequest customer)
        {
            var maillContent = customer.ToJson();
            var rp = Configuration.maillRecipientConfiguration;
            var mr = new MailRequest
            {
                smtpserver = Configuration.MaillConfiguration.smtpserver,
                userName = Configuration.MaillConfiguration.userName,
                pwd = Configuration.MaillConfiguration.pwd,
                nickName = Configuration.MaillConfiguration.nickName,
                fromMail = Configuration.MaillConfiguration.fromMail,
                toMail = Configuration.maillRecipientConfiguration,
                subj = "Inquiry",
                bodys = maillContent
            };
            var sma = Mail.SendMailAsync(mr);
        }
    }
}
