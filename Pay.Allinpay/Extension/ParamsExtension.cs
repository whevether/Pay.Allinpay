using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pay.Allinpay.Extension.Helper
{
  public static class ParamsExtension
  {
    /// <summary>
    /// 组合成key=value&key=value字符串
    /// 并按照第一个字符的键值ASCII码递增排序（字母升序排序）
    /// </summary>
    /// <param name="param">参数集合</param>
    /// <returns></returns>
    public static string BuildUrlQuery<T>(this Dictionary<string, T> param)
    {
      StringBuilder builder = new StringBuilder();
      foreach (var item in param)
      {
        if (item.Value == null)
          continue;
        string value = item.Value.ToString();
        builder.Append(item.Key + "=" + value + "&");
      }

      return builder.ToString().TrimEnd(new char[] {'&'});
    }

    /// <summary>
    /// 忽略空值并排序
    /// </summary>
    public static Dictionary<string, T> IgnoreNull<T>(this Dictionary<string, T> param)
    {
      Dictionary<string, T> dic = new Dictionary<string, T>();
      foreach (var item in param)
      {
        if (null != item.Value)
          dic.Add(item.Key, item.Value);
      }
      return dic;
    }

    /// <summary>
    /// 字典排序
    /// </summary>
    public static Dictionary<string, T> Sort<T>(this Dictionary<string, T> dic)
    {
      return dic.OrderBy(t => t.Key).ToDictionary(p => p.Key, o => o.Value);
    }

    // 序列化为驼峰
    public static string WriteFromObject<T>(this object obj) where T : class
    {
      JsonSerializerSettings settings = new JsonSerializerSettings();
      settings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
      string dcjs = (string) JsonConvert.SerializeObject(obj, settings);
      return dcjs;
    }

    //反序列化
    public static JObject ReadToObject(this string json)
    {
      JObject dcjs = (JObject) JsonConvert.DeserializeObject(json);
      return dcjs;
    }

    //泛型反序列化
    public static T ReadToObject<T>(this string json) where T : class
    {
      T dcjs = JsonConvert.DeserializeObject<T>(json);
      return dcjs;
    }
  }
}