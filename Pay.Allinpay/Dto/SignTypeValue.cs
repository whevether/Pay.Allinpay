using System.ComponentModel;

namespace Pay.Allinpay.Dto
{
  /// <summary>
  /// 签名方式
  /// </summary>
  public enum SignTypeValue
  {
    [Description("md5")]
    MD5,
    [Description("RSA")]
    RSA,
    [Description("SM2")]
    SM2
  }
}