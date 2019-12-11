using System;
using System.Diagnostics;
using com.jadeStonePlatform.business.customer.process;
using com.jadeStonePlatform.definition.Models;
using Microsoft.AspNetCore.Mvc;
using com.jadeStonePlatform.web.Models;

namespace com.jadeStonePlatform.web.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var userAgent = Request.Headers["User-Agent"].ToString().ToLower();
            if (!string.IsNullOrWhiteSpace(userAgent)
                && (userAgent.IndexOf("android", StringComparison.Ordinal) != -1
                || userAgent.IndexOf("iphone", StringComparison.Ordinal) != -1
                || userAgent.IndexOf("ipad", StringComparison.Ordinal) != -1))
            {
                return View("Mobile");
            }
            return View("Index");
        }

        /// <summary>
        /// 移动版
        /// </summary>
        /// <returns></returns>
        public IActionResult Mobile()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 提交询价
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public string SubmitInquiry(SubmitInquiryRequest customer)
        {
            return new Inquiry().SubmitInquiry(customer);
        }
    }
}
