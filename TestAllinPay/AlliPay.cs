using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pay.Allinpay.Dto;
using Pay.Allinpay.Service;
using Xunit;

namespace TestAllinPay
{
  public class AlliPay
  {
    public IPayAllinPayService _payAllinPay;
    public AlliPay()
    {
      IServiceCollection services = new ServiceCollection();
      services.AddAlliPay();
      services.AddOptions().Configure<PayAllinPaySetting>(t =>
      {

        t.CusId = "990581007426001";
        t.AppId = "00000051";
        t.ApiGateWay = "https://test.allinpaygd.com/";
        t.AppKey =
          @"allinpay888";
          t.SignType = SignTypeValue.MD5.ToString();
          t.NotifyUrl = "http://www.baidu.com"; // 二维码 与支付宝 app 支付必传
          // t.SubAppid = "wx67dd2304917e7e6c"; // 微信公众号或小程序appid jssdk与小程序 支付必传
          // t.SubAppid = "2018122562635796sadsada"; // 支付宝appid  支付宝jssdk 支付必传
      });
      var _serviceProvider = services.BuildServiceProvider();
      this._payAllinPay = _serviceProvider.GetService<IPayAllinPayService>();
    }
    /// <summary>
    /// 微信支付
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task WeixinPay()
    {
      var res = await this._payAllinPay.Pay(new PayRequestDto()
      {
        Trxamt = 10,
        PayType = PayAllinPayType.W01.ToString(),
        Reqsn = "dsadsad15523142asd",
        Acct = "o8BFy5xRRAEUCG8x3kUaR7F6fZts"
      });
      Assert.True(true);
    }
    /// <summary>
    /// 支付宝支付
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task AliPay()
    {
      var res = await this._payAllinPay.Pay(new PayRequestDto()
      {
        Trxamt = 10,
        PayType = PayAllinPayType.A01.ToString(),
        Reqsn = "dsadsad15523142asd",
        Acct = "o8BFy5xRRAEUCG8x3kUaR7F6fZts"
      });
      Assert.True(true);
    }
  }
}