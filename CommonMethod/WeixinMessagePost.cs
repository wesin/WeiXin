using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethod
{
    public class WeixinMessagePost
    {
        private static readonly string textTemplateStr = @"<xml><ToUserName>
<![CDATA[{0}]]></ToUserName><FromUserName>
<![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
<Content><![CDATA[{4}]]></Content>
</xml>";


        public static string GetPostMessage(WeixinMessageEntity entity)
        {
            return string.Format(textTemplateStr, entity.ToUser, entity.FromUser, entity.CreateTime, entity.MsgType.ToString(), entity.Content);
        }

        public static string PostMessage(string url, string message)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            byte[] data = Encoding.UTF8.GetBytes(message);
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            FileMessageSave.MessageSave("\r\n获取信息返回：" + result);
            return result;
        }
    }
}
