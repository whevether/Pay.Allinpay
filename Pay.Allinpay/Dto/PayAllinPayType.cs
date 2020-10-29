using System.ComponentModel;

namespace Pay.Allinpay.Dto
{
  /// <summary>
  /// 通联 收银宝交易方式
  /// </summary>
  public enum PayAllinPayType
  {
    [Description("微信扫码支付")]
    W01,
    [Description("微信JS支付")]
    W02,
    [Description("微信小程序支付")]
    W06,
    [Description("支付宝扫码支付")]
    A01,
    [Description("支付宝JS支付")]
    A02,
    [Description("支付宝APP支付")]
    A03,
    [Description("手机QQ扫码支付")]
    Q01,
    [Description("手机QQ JS支付")]
    Q02,
    [Description("银联扫码支付(CSB)")]
    U01,
    [Description("银联JS支付")]
    U02
  }
}