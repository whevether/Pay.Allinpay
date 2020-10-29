using Pay.Allinpay.Dto;
using Pay.Allinpay.Extension.Http;
using Pay.Allinpay.Service;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class AlliPayServiceCollectionExtensions
  {
    /// <summary>
    /// 添加通联支付
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAlliPay(
      this IServiceCollection services)
    {
      services.AddHttpClient();
      services.AddTransient<IHttpHelper, HttpHelper>();
      services.AddTransient<IPayAllinPayService, PayAllinPayService>();
      return services;
    }
  }
}