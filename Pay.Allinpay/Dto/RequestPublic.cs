using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pay.Allinpay.Extension.Helper;

namespace Pay.Allinpay.Dto
{
  /// <summary>
  /// 通联收银宝公共请求参数
  /// </summary>
  public class RequestPublic
  {
    public RequestPublic(string cusid,string appid,long trxamt,string reqsn, string payType,string signType)
    {
      Cusid = cusid;
      AppId = appid;
      Trxamt = trxamt;
      Reqsn = reqsn;
      PayType = payType;
      if(!string.IsNullOrWhiteSpace(signType))
        SignType = signType;
    }
    /// <summary>
    /// 商户号
    /// </summary>
    [JsonPropertyName("cusid")]
    public string Cusid { get; set; }
    /// <summary>
    /// 版本
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; } = "11";
    /// <summary>
    /// 交易金额分
    /// </summary>
    [JsonPropertyName("trxamt")]
    public long Trxamt { get; set; }
    /// <summary>
    /// 商户交易单号
    /// </summary>
    [JsonPropertyName("reqsn")]
    public string Reqsn { get; set; }
    /// <summary>
    /// 交易方式
    /// </summary>
    [JsonPropertyName("paytype")]
    public string PayType { get; set; }

    /// <summary>
    /// 随机字符串
    /// </summary>
    [JsonPropertyName("randomstr")]
    public string RandomStr { get; set; } = DateTime.Now.ToFileTime().ToString();
    /// <summary>
    /// 订单标题
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; }
    /// <summary>
    /// 有效时间 默认五分
    /// </summary>
    [JsonPropertyName("validtime")]
    public string ValidTime { get; set; }
    /// <summary>
    /// appid
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }
    /// <summary>
    /// 支付方法
    /// JS支付时使用
    /// 微信支付-用户的微信openid
    /// 支付宝支付-用户user_id
    /// 微信小程序-用户小程序的openid
    /// </summary>
    [JsonPropertyName("acct")]
    public string Acct { get; set; }
    /// <summary>
    /// 通知地址
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string NotifyUrl { get; set; }

    /// <summary>
    /// 支付限制 no_credit--指定不能使用信用卡支付
    /// </summary>
    [JsonPropertyName("limit_pay")]
    public string LimitPay { get; set; } = "no_credit";
    /// <summary>
    /// 微信子appid 微信小程序/微信公众号/APP的appid
    /// </summary>
    [JsonPropertyName("sub_appid")]
    public string SubAppid { get; set; }
    /// <summary>
    /// 订单优惠标记，用于区分订单是否可以享受优惠，字段内容在微信后台配置券时进行设置，说明详见代金券或立减优惠 只对微信支付有效
    /// </summary>
    [JsonPropertyName("goods_tag")]
    public string GoodsTag { get; set; }
    /// <summary>
    /// 优惠信息
    /// </summary>
    [JsonPropertyName("benefitdetail")]
    public string BenefitDetail { get; set; }
    /// <summary>
    /// chnlstoreid
    /// </summary>
    [JsonPropertyName("chnlstoreid")]
    public string ChnlstoreId { get; set; }
    /// <summary>
    /// 门店号
    /// </summary>
    [JsonPropertyName("subbranch")]
    public string SubBranch { get; set; }
    /// <summary>
    /// 拓展参数 json字符串，注意是String
    /// 一般用于渠道的活动参数填写
    /// </summary>
    [JsonPropertyName("extendparams")]
    public string ExtendParams { get; set; }
    /// <summary>
    /// 终端ip
    /// </summary>
    [JsonPropertyName("cusip")]
    public string Cusip { get; set; }
    /// <summary>
    /// 支付完成跳转
    /// </summary>
    [JsonPropertyName("front_url")]
    public string FrontUrl { get; set; }
    /// <summary>
    /// 证件号
    /// </summary>
    [JsonPropertyName("idno")]
    public string Idno { get; set; }
    /// <summary>
    /// 付款人真实姓名
    /// </summary>
    [JsonPropertyName("truename")]
    public string TrueName { get; set; }
    /// <summary>
    /// 分账信息
    /// </summary>
    [JsonPropertyName("asinfo")]
    public string AsInfo { get; set; }
    /// <summary>
    /// 花呗分期
    /// </summary>
    [JsonPropertyName("fqnum")]
    public string FqNum { get; set; }

    /// <summary>
    /// 签名方式
    /// </summary>
    [JsonPropertyName("signtype")]
    public string SignType { get; set; } = SignTypeValue.MD5.ToString();
    /// <summary>
    /// 门店号
    /// </summary>
    [JsonPropertyName("sign")]
    public string Sign { get; set; }
    /// <summary>
    /// 通联应用key
    /// </summary>
    [JsonPropertyName("app_key")]
    public string AppKey { get; set; }

    /// <summary>
    /// 获取公共参数
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetPublicParams()
    {
      Dictionary<string,string> dic = new Dictionary<string, string>();
      dic.Add("cusid",Cusid);
      dic.Add("appid",AppId);
      dic.Add("version",Version);
      dic.Add("trxamt", Trxamt.ToString());
      dic.Add("reqsn", Reqsn);
      dic.Add("paytype", PayType);
      dic.Add("randomstr", RandomStr);
      dic.Add("body", Body);
      dic.Add("remark", Remark);
      dic.Add("validtime", ValidTime);
      dic.Add("acct", Acct);
      dic.Add("notify_url",NotifyUrl);
      dic.Add("limit_pay", LimitPay);
      dic.Add("sub_appid", SubAppid);
      dic.Add("goods_tag", GoodsTag);
      dic.Add("benefitdetail", BenefitDetail);
      dic.Add("chnlstoreid", ChnlstoreId);
      dic.Add("subbranch", SubBranch);
      dic.Add("extendparams", ExtendParams);
      dic.Add("cusip", Cusip);
      dic.Add("front_url", FrontUrl);
      dic.Add("idno", Idno);
      dic.Add("truename", TrueName);
      dic.Add("asinfo", AsInfo);
      dic.Add("fqnum", FqNum);
      dic.Add("signtype", SignType);
      dic = dic.IgnoreNull<string>();
      Sign = GetSign(dic);
      // dic.Remove("key");
      dic.Add("sign", Sign.ToLower());
      return dic;
    }
    /// <summary>
    /// 获取签名
    /// </summary>
    /// <returns></returns>
    public virtual string GetSign(Dictionary<string,string> map)
    {
      return PayHelper.SignParam(map, AppKey,SignType);
    }
    /// <summary>
    /// 获取请求参数
    /// </summary>
    /// <returns></returns>
    public virtual Dictionary<string, string> GetParams()
    {
      return null;
    }
  }
}