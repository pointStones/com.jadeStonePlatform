using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace com.jadeStonePlatform.common.tools
{
    /// <summary>
    /// Json序列化 帮助类
    /// </summary>
    public static class Json
    {
        /// <summary>
        /// string反序列化至 object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static object ToJson(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return ToJson(obj, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="datetimeformats">日期格式</param>
        /// <returns></returns>
        public static string ToJson(this object obj, string datetimeformats = "yyyy-MM-dd HH:mm:ss")
        {
            if (string.IsNullOrWhiteSpace(datetimeformats))
            {
                var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
                return JsonConvert.SerializeObject(obj, timeConverter);
            }
            else
            {
                return JsonConvert.SerializeObject(obj);
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="retainProps">指定序列化字段</param>
        /// <param name="dateFormatString"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, string[] retainProps, string dateFormatString = "yyyy-MM-dd HH:mm:ss")
        {
            var jsetting = new JsonSerializerSettings();
            jsetting.ContractResolver = new LimitPropsContractResolver(retainProps);
            if (!string.IsNullOrWhiteSpace(dateFormatString))
            {
                jsetting.DateFormatString = dateFormatString;
            }
            return JsonConvert.SerializeObject(obj, Formatting.Indented, jsetting);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string TableToJson(this DataTable data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToTable(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<DataTable>(json);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string json)
        {
            return json == null ? JObject.Parse("{}") : JObject.Parse(json.Replace("&nbsp;", ""));
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static IEnumerable<JProperty> ToJProperties(this string json)
        {
            return ToJObject(json).Properties();
        }

        /// <summary>
        /// 向json object追加item，并返回序列化后的string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Merge(object obj, object content)
        {
            try
            {
                var reqStr = ToJson(obj);
                JObject jobject = (JObject)JsonConvert.DeserializeObject(reqStr);
                if (content is JObject)
                {
                    jobject.Merge(content);
                }
                else
                {
                    jobject.Merge(JObject.FromObject(content));
                }
                return jobject.ToJson();
            }
            catch
            {
                //非json格式
                return obj == null ? "" : obj.ToString();
            }
        }

    }
}
