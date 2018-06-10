using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Niunan.CaiPiao.Util
{
    /// <summary>牛腩公用类库
    /// 
    /// </summary>
    public static partial class Tool
    {


        ///   <summary>去除HTML标记    
        ///      
        ///   </summary>   
        ///   <param    name="NoHTML">包括HTML的源码</param>   
        ///   <returns>已经去除后的文字</returns>   
        public static string GetNoHTMLString(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", ""); 

            return Htmlstring;
        }

        /// <summary>获取显示的字符串，可显示HTML标签，但把危险的HTML标签过滤，如iframe,script等。  
        ///   
        /// </summary>  
        /// <param name="str">未处理的字符串</param>  
        /// <returns></returns>  
        public static string GetSafeHTMLString(string str)
        {
            str = Regex.Replace(str, @"<applet[^>]*?>.*?</applet>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<embed[^>]*?>.*?</embed>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frame[^>]*?>.*?</frame>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frameset[^>]*?>.*?</frameset>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<layer[^>]*?>.*?</layer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<link[^>]*?>.*?</link>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<ilayer[^>]*?>.*?</ilayer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<meta[^>]*?>.*?</meta>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<object[^>]*?>.*?</object>", "", RegexOptions.IgnoreCase);
            return str;
        }

        /// <summary>过滤SQL非法字符串
        /// 字符串长度不能超过20个,把前后空格都去除
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetSafeSQL(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            value = value.Trim();
            value = Tool.StringTruncat(value, 40, "");
            value = Regex.Replace(value, @";", string.Empty);
            value = Regex.Replace(value, @"'", string.Empty);
            value = Regex.Replace(value, @"&", string.Empty);
            value = Regex.Replace(value, @"%20", string.Empty);
            value = Regex.Replace(value, @"--", string.Empty);
            value = Regex.Replace(value, @"==", string.Empty);
            value = Regex.Replace(value, @"<", string.Empty);
            value = Regex.Replace(value, @">", string.Empty);
            value = Regex.Replace(value, @"%", string.Empty);
            value = Regex.Replace(value, @"\+", string.Empty);
            return value;
        }

        ///   <summary>将指定字符串按指定长度进行剪切  
        ///   
        ///   </summary> 
        ///   <param   name= "oldStr "> 需要截断的字符串 </param> 
        ///   <param   name= "maxLength "> 字符串的最大长度 </param> 
        ///   <param   name= "endWith "> 超过长度的后缀 </param> 
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns> 
        public static string StringTruncat(string oldStr, int maxLength, string endWith)
        {
            if (string.IsNullOrEmpty(oldStr))
                //   throw   new   NullReferenceException( "原字符串不能为空 "); 
                return oldStr + endWith;
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");
            if (oldStr.Length > maxLength)
            {
                string strTmp = oldStr.Substring(0, maxLength);
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
        }

        /// <summary>
        /// netcore下的实现MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }

        }

        /// <summary>
        /// * 功能：使用SendCloud发送邮件
        ///* 返回值：string，JSON格式的返回值，或者异常
        /// </summary>
        /// <param name="from">显示的发件人邮箱</param>
        /// <param name="to">收件人邮箱</param>
        /// <param name="title">邮件标题</param>
        /// <param name="content">邮件内容</param>
        /// <param name="api_user"></param>
        /// <param name="api_key"></param>
        /// <returns></returns>
        public static string SendMailBySendCloud(String from, String to, String title, String content, string api_user = "niunan", string api_key = "wY7TRIGa3Fb1wdWe")
        {
            String url = "http://api.sendcloud.net/apiv2/mail/send";
            HttpClient client = null;
            HttpResponseMessage response = null;
            string result;

            try
            {

                client = new HttpClient();

                List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();

                paramList.Add(new KeyValuePair<string, string>("apiUser", api_user));
                paramList.Add(new KeyValuePair<string, string>("apiKey", api_key));
                paramList.Add(new KeyValuePair<string, string>("from", from));
                paramList.Add(new KeyValuePair<string, string>("fromName", from));
                paramList.Add(new KeyValuePair<string, string>("to", to));
                paramList.Add(new KeyValuePair<string, string>("subject", title));
                paramList.Add(new KeyValuePair<string, string>("html", content));

                response = client.PostAsync(url, new FormUrlEncodedContent(paramList)).Result;
                result = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                //result = e.Message;
                //Console.WriteLine("\nException Caught!");
                //Console.WriteLine("Message :{0} ", e.Message);
                throw e;
            }
            finally
            {
                if (null != client)
                {
                    client.Dispose();
                }
            }

            return result;
        }

        /// <summary>发送email,默认是25端口
        /// 
        /// </summary>
        /// <param name="title">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="toAdress">收件人</param>
        /// <param name="fromAdress">发件人</param>
        /// <param name="userName">发件用户名</param>
        /// <param name="userPwd">发件密码</param>
        /// <param name="smtpHost">smtp地址</param>
        public static void SendMail(string title, string body, string toAdress, string fromAdress,
                              string userName, string userPwd, string smtpHost)
        {
            try
            {
                MailAddress to = new MailAddress(toAdress);
                MailAddress from = new MailAddress(fromAdress);
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);
                message.IsBodyHtml = true; // 如果不加上这句那发送的邮件内容中有HTML会原样输出 
                message.Subject = title; message.Body = body;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = true;
                smtp.Port = 25;
                smtp.Credentials = new NetworkCredential(userName, userPwd);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Host = smtpHost;
                message.To.Add(toAdress);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据值得到中文备注
        /// </summary>
        /// <param name="e"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String GetEnumDesc(this Type e, int? value)
        {
            FieldInfo[] fields = e.GetFields();
            for (int i = 1, count = fields.Length; i < count; i++)
            {
                if ((int)System.Enum.Parse(e, fields[i].Name) == value)
                {
                    DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])fields[i].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (EnumAttributes.Length > 0)
                    {
                        return EnumAttributes[0].Description;
                    }
                }
            }
            return "";
        }


    }
}



