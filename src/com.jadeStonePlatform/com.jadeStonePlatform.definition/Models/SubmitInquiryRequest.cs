namespace com.jadeStonePlatform.definition.Models
{
    /// <summary>
    /// 询价请求内容
    /// </summary>
    public class SubmitInquiryRequest
    {

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
    }
}
