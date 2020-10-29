using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Pay.Allinpay.Dto;

namespace Pay.Allinpay.Extension.Helper
{
  public static class PayHelper
  {
    /// <summary>
    /// 签名参数
    /// </summary>
    /// <param name="param"></param>
    /// <param name="appKey"></param>
    /// <param name="signType"></param>
    /// <returns></returns>
    public static string SignParam(Dictionary<string, string> param, string appKey, string signType)
    {
      if (param == null || param.Count == 0)
      {
        return "";
      }
      if (signType.Equals(SignTypeValue.MD5.ToString()))
      {
        param.Add("key", appKey);
        // 去除空值并排序之后组装
        var blankStr = param.Sort<string>().BuildUrlQuery<string>();
        return Md5Encrypt(blankStr);
      } else if (signType.Equals(SignTypeValue.RSA.ToString()))
      {
        var str = param.BuildUrlQuery<string>();
        return Encrypt(str,appKey, RSAEncryptionPadding.Pkcs1);
      }
      else
      {
        return "";
      }
    }
    /// <summary>
    /// 验签
    /// </summary>
    /// <param name="param"></param>
    /// <param name="appKey"></param>
    /// <param name="signType"></param>
    /// <returns></returns>
    public static bool ValidSign(Dictionary<string, string> param, string appKey,string signType)
    {
      var signRsp = param["sign"];
      param.Remove("sign");
      if (param.ContainsKey("key"))
        param.Remove("key");
      var sign = SignParam(param, appKey,signType);
      return sign.ToLower().Equals(signRsp.ToLower());

    }
    /// <summary>
    /// md5加签
    /// </summary>
    /// <param name="strText"></param>
    /// <returns></returns>
    public static string Md5Encrypt(string strText)
    {
      MD5 md5 = new MD5CryptoServiceProvider();
      var result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strText));
      return BitConverter.ToString(result).Replace("-", "");
    }
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="text">签名之前字符串</param>
    /// <param name="publicKey">公钥</param>
    /// <param name="padding">RSA加密填充方式</param>
    /// <param name="encoding">编码方式；默认UTF-8</param>
    /// <returns></returns>
    public static string Encrypt(string text, string publicKey, RSAEncryptionPadding padding, Encoding encoding = null)
    {
      using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
      {
        rsa.ExportParameters(true);
        rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out int bytesRead1);
        encoding = encoding == null ? Encoding.UTF8 : encoding;
        var signbytes = rsa.Encrypt(encoding.GetBytes(text), padding);
        return Convert.ToBase64String(signbytes);
      }
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="ciphertex">加密之后字符串</param>
    /// <param name="privateKey">私钥</param>
    /// <param name="version">Pkcs 证书格式</param>
    /// <param name="padding">RSA加密填充方式</param>
    /// <param name="encoding">编码方式；默认UTF-8</param>
    /// <returns></returns>
    public static string Decrypt(string ciphertex, string privateKey, RSAEncryptionPadding padding, Encoding encoding = null)
    {
      using var rsa = RSA.Create();
      rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out int bytesRead);
      
      var plaintextbytes = rsa.Decrypt(Convert.FromBase64String(ciphertex), padding);
      encoding = encoding == null ? Encoding.UTF8 : encoding;
      return encoding.GetString(plaintextbytes);
    }
  }
}