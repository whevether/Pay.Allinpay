using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Pay.Allinpay.Dto;
using Pay.Allinpay.Extension.Helper;
using Pay.Allinpay.Extension.Http;

namespace Pay.Allinpay.Service
{
  /// <summary>
  /// 通联支付服务
  /// </summary>
  public class PayAllinPayService: IPayAllinPayService
  {
    // http request
    private readonly IHttpHelper _http;
    private PayAllinPaySetting _options;
    private const string payUrl = "apiweb/unitorder/pay";
    public PayAllinPayService(IHttpHelper http,IOptions<PayAllinPaySetting> options)
    {
      _http = http;
      _options = options?.Value;
    }
    /// <summary>
    /// 通联支付支付
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<AllinpayResponse> Pay(PayRequestDto request)
    {
      var req = new RequestPublic(_options.CusId,_options.AppId,request.Trxamt,request.Reqsn,request.PayType,_options.SignType);
      req.ValidTime = request.ValidTime;
      req.Body = request.Body;
      req.Remark = request.Remark;
      req.Acct = request.Acct;
      if (!string.IsNullOrWhiteSpace(_options.AppKey))
        req.AppKey = _options.AppKey;
      if (!string.IsNullOrWhiteSpace(_options.NotifyUrl))
        req.NotifyUrl = _options.NotifyUrl;
      if (!string.IsNullOrWhiteSpace(_options.SubAppid))
        req.SubAppid = _options.SubAppid;
      if (!string.IsNullOrWhiteSpace(_options.Version))
        req.Version = _options.Version;
      var param = req.GetPublicParams();
      var res = await _http.PostResponse<AllinpayResponse>(_options.ApiGateWay + payUrl, param);
      if (!string.IsNullOrWhiteSpace(res.Sign))
      {
        if (PayHelper.ValidSign(param, _options.AppKey, _options.SignType))
        {
          return await Task.FromResult<AllinpayResponse>(res);
        }
        else
        {
          return await Task.FromException<AllinpayResponse>(new Exception("验证签名失败"));
        }
      }
      else
      {
        return await Task.FromResult<AllinpayResponse>(res);
      }
    }
  }
}