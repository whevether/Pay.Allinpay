using System;
using System.Threading.Tasks;
using Pay.Allinpay.Dto;

namespace Pay.Allinpay.Service
{
  /// <summary>
  /// 通联支付服务
  /// </summary>
  public interface IPayAllinPayService
  {
    /// <summary>
    /// 微信jsapi支付
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AllinpayResponse> Pay(PayRequestDto request);
  }
}