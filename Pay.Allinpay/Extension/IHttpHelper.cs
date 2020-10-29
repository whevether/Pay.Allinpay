using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pay.Allinpay.Extension.Http
{
  /// <summary>
  /// http请求接口辅助方法
  /// </summary>
  public interface IHttpHelper
  {
    /// <summary>
    /// put泛型请求
    /// </summary>
    Task<T> PutResponse<T>(string url, string putData) where T : class, new();
    /// <summary>
    /// get 泛型请求
    /// </summary>
    Task<T> GetResponse<T>(string url) where T : class, new();
    /// <summary>
    /// post泛型请求
    /// </summary>
    Task<T> PostResponse<T>(string url, Dictionary<string, string> dic) where T : class, new();
    /// <summary>
    /// post泛型请求 传入json对象
    /// </summary>
    Task<T> PostResponse<T>(string url, object content) where T : class, new();
  }
}