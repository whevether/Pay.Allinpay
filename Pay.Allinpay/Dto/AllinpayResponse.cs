using System;
using Newtonsoft.Json;

namespace Pay.Allinpay.Dto
{
  [Serializable]
  public class AllinpayResponse
  {
    /// <summary>
    /// 通联返回状态码
    /// </summary>
    [JsonProperty("retcode")] 
    public string RetCode { get; set; }
    /// <summary>
    /// 返回码说明
    /// </summary>
    [JsonProperty("retmsg")] 
    public string RetMsg { get; set; }
    /// <summary>
    /// 商户号
    /// </summary>
    [JsonProperty("cusid")] 
    public string Cusid { get; set; }
    /// <summary>
    /// 应用ID
    /// </summary>
    [JsonProperty("appid")] 
    public string Appid { get; set; }
    /// <summary>
    /// 渠道平台交易单号
    /// </summary>
    [JsonProperty("trxid")] 
    public string TrxId { get; set; }
    /// <summary>
    /// 渠道平台交易单号
    /// </summary>
    [JsonProperty("chnltrxid")] 
    public string ChnltrxId { get; set; }
    /// <summary>
    /// 商户交易单号
    /// </summary>
    [JsonProperty("reqsn")] 
    public string ReqSn { get; set; }
    /// <summary>
    /// 随机字符串
    /// </summary>
    [JsonProperty("randomstr")] 
    public string RandomStr { get; set; }
    /// <summary>
    /// 交易状态
    /// </summary>
    [JsonProperty("trxstatus")] 
    public string TrxStatus { get; set; }
    /// <summary>
    /// 交易完成时间
    /// </summary>
    [JsonProperty("fintime")] 
    public string FinTime { get; set; }
    /// <summary>
    /// 错误原因
    /// </summary>
    [JsonProperty("errmsg")] 
    public string ErrMsg { get; set; }
    /// <summary>
    /// 支付串
    /// </summary>
    [JsonProperty("payinfo")] 
    public string PayInfo { get; set; }
    /// <summary>
    /// 签名
    /// </summary>
    [JsonProperty("sign")] 
    public string Sign { get; set; }
  }
}