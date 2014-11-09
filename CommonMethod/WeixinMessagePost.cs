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
        private string msgUrl = string.Empty;

        /// <summary>
        /// 设置对应的url地址
        /// </summary>
        public string MsgUrl
        {
            get { return msgUrl; }
            set { msgUrl = value; }
        }

        public WeixinMessagePost()
        {
            if (string.IsNullOrEmpty(WeiXinCommon.Access_token))
            {
                WeixinCheck.GetToken();
            }
        }

        public string PostMessage(string message)
        {
            if (string.IsNullOrEmpty(msgUrl))
            {
                return "Unknow Url Address!";
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(msgUrl);
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
