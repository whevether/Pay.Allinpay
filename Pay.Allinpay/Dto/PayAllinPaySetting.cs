namespace Pay.Allinpay.Dto
{
  /// <summary>
  /// 通联收银宝配置
  /// </summary>
  public class PayAllinPaySetting
  {
    /// <summary>
    ///     实际交易的商户号
    /// </summary>
    public string CusId { get; set; }

    /// <summary>
    ///     平台分配的APPID
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 平台分配的AppKey
    /// </summary>
    public string AppKey { get; set; }

    /// <summary>
    ///     接口网关
    /// </summary>
    public string ApiGateWay { get; set; }

    /// <summary>
    ///     版本
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    ///     回调地址
    /// </summary>
    public string NotifyUrl { get; set; }
    /// <summary>
    /// 微信公众号或小程序或支付宝AppId
    /// </summary>
    public string SubAppid { get; set; }
    /// <summary>
    /// 签名类型 支持MD5和rsa
    /// </summary>
    public string SignType { get; set; }
  }
}