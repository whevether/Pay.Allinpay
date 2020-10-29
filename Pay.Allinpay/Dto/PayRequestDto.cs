using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pay.Allinpay.Dto
{
  /// <summary>
  /// 支付请求
  /// </summary>
  public class PayRequestDto
  {
    /// <summary>
    /// 交易金额分
    /// </summary>
    [JsonPropertyName("trxamt")]
    [Range(1,100000000,ErrorMessage = "交易金额只能为1-100000000分")]
    public long Trxamt { get; set; }
    /// <summary>
    /// 商户交易单号
    /// </summary>
    [JsonPropertyName("reqsn")]
    [Required(ErrorMessage = "交易单号不能为空")]
    public string Reqsn { get; set; }
    /// <summary>
    /// 交易方式
    /// </summary>
    [JsonPropertyName("paytype")]
    [Required(ErrorMessage = "交易方式不能为空")]
    public string PayType { get; set; }
    /// <summary>
    /// 有效时间 默认五分
    /// </summary>
    [JsonPropertyName("validtime")]
    public string ValidTime { get; set; } = "5";
    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; }
    /// <summary>
    /// 支付方法
    /// JS支付时使用
    /// 微信支付-用户的微信openid
    /// 支付宝支付-用户user_id
    /// 微信小程序-用户小程序的openid
    /// </summary>
    [JsonPropertyName("acct")]
    public string Acct { get; set; }
  }
}