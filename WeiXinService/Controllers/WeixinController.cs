using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WeiXinService.Controllers
{
    public class WeixinController : Controller
    {
        //
        // GET: /Weixin/
        public ActionResult Index()
        {
            //string hha = Request.Url.ToString();// Request["wesin"];
            if (CommonMethod.WeixinCheck.CheckSignature())
            {
                Response.Write(Request.QueryString["echostr"]);
                Response.End();
            }
            if (Request.HttpMethod.ToLower() == "post")
            {
                MessageStream stream = new MessageStream();
                stream.ReadStreamAndReply(HttpContext.Request);
            }
            @ViewBag.WesinTitle = "Wesin";
            return View("Weixin");
        }

        //private Models.Send_Msg GetSendMsg(string msgType)
        //{
        //    //回复内容
        //    Weixin.Models.Send_Text model = new Weixin.Models.Send_Text();
        //    switch (msgType)
        //    {
        //        case Core.MsgType.text:
        //            model.Content = "reply text";
        //            break;
        //        case Core.MsgType.image:
        //            model.Content = "reply image";
        //            break;
        //        case Core.MsgType.events:
        //            model.Content = "reply 事件";
        //            break;
        //    }
        //    model.CreateTime = Weixin.Core.DateTimeHelper.DateTimeToUnixInt(DateTime.Now).ToString();
        //    model.MsgType = "text";
        //    return model;
        //}

        //private void ReceiveHandler(Models.Receive_Msg receiveModel, ref string msg)
        //{
        //    try
        //    {
        //        using (System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath("Files//" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt"), System.IO.FileMode.OpenOrCreate))
        //        {
        //            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
        //            {
        //                sw.Write(receiveModel.Xml);
        //            }
        //        }
        //    }
        //    catch
        //    { }
        //}

        public ActionResult GetToken()
        {
            return Content(CommonMethod.WeixinCheck.GetToken());    
        }

        public ActionResult UpdateOwnMenu()
        {
            return Content(WeiXinMenuFacade.UpdateOwnMenu());
        }

        ///// <summary>
        ///// 获取post返回来的数据
        ///// </summary>
        ///// <returns></returns>
        //private string PostInput()
        //{
        //    Stream s = System.Web.HttpContext.Current.Request.InputStream;
        //    byte[] b = new byte[s.Length];
        //    s.Read(b, 0, (int)s.Length);
        //    return Encoding.UTF8.GetString(b);
        //}

        ///// <summary>
        /////返回微信信息结果
        ///// </summary>
        ///// <param name="weixinXML"></param>
        //private void ResponseMsg(string weixinXML)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.LoadXml(weixinXML);//读取XML字符串
        //        XmlElement rootElement = doc.DocumentElement;

        //        XmlNode MsgType = rootElement.SelectSingleNode("MsgType");//获取字符串中的消息类型

        //        string resxml = "";
        //        if (MsgType.InnerText == "text")//如果消息类型为文本消息
        //        {
        //            var model = new
        //            {
        //                ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText,
        //                FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText,
        //                CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText,
        //                MsgType = MsgType.InnerText,
        //                Content = rootElement.SelectSingleNode("Content").InnerText,
        //                MsgId = rootElement.SelectSingleNode("MsgId").InnerText
        //            };
        //            resxml += "<xml><ToUserName><![CDATA[" + model.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + model.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
        //            if (!string.IsNullOrEmpty(model.Content))//如果接收到消息
        //            {
        //                if (model.Content.Contains(" 你好") || model.Content.Contains(" 好") || model.Content.Contains("hi") || model.Content.Contains("hello"))// 你好
        //                {
        //                    resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[你好，有事请留言，偶会及时回复你的。]]></Content><FuncFlag>0</FuncFlag></xml>";
        //                }

        //            }

        //            else//没有接收到消息
        //            {
        //                resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[亲，感谢您对我的关注，有事请留言。]]></Content><FuncFlag>0</FuncFlag></xml>";
        //            }

        //            Response.Write(resxml);
        //        }
        //        if (MsgType.InnerText == "image")//如果消息类型为图片消息
        //        {
        //            var model = new
        //            {
        //                ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText,
        //                FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText,
        //                CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText,
        //                MsgType = MsgType.InnerText,
        //                PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText,
        //                MsgId = rootElement.SelectSingleNode("MsgId").InnerText
        //            };
        //            resxml += "<xml><ToUserName><![CDATA[" + model.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + model.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>1</ArticleCount><Articles><item><Title><![CDATA[欢迎您的光临！]]></Title><Description><![CDATA[非常感谢您的关注！]]></Description><PicUrl><![CDATA[http://...jpg]]></PicUrl><Url><![CDATA[http://www.baidu.com/]]></Url></item></Articles><FuncFlag>0</FuncFlag></xml>";
        //            Response.Write(resxml);
        //        }
        //        else//如果是其余的消息类型
        //        {
        //            var model = new
        //            {
        //                ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText,
        //                FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText,
        //                CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText,
        //            };
        //            resxml += "<xml><ToUserName><![CDATA[" + model.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + model.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[亲，感谢您对我的关注，有事请留言，我会及时回复你的哦。]]></Content><FuncFlag>0</FuncFlag></xml>";
        //            Response.Write(resxml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    Response.End();

        //}
        ///// <summary>
        ///// datetime转换成unixtime
        ///// </summary>
        ///// <param name="time"></param>
        ///// <returns></returns>
        //private int ConvertDateTimeInt(System.DateTime time)
        //{
        //    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        //    return (int)(time - startTime).TotalSeconds;
        //}
        ///// <summary>
        ///// 写日志(用于跟踪)，可以将想打印出的内容计入一个文本文件里面，便于测试
        ///// </summary>
        //public static void WriteLog(string strMemo, HttpServerUtility server)
        //{
        //    string filename = server.MapPath("/logs/log.txt");//在网站项目中建立一个文件夹命名logs（然后在文件夹中随便建立一个web页面文件，避免网站在发布到服务器之后看不到预定文件）
        //    if (!Directory.Exists(server.MapPath("//logs//")))
        //        Directory.CreateDirectory("//logs//");
        //    StreamWriter sr = null;
        //    try
        //    {
        //        if (!File.Exists(filename))
        //        {
        //            sr = File.CreateText(filename);
        //        }
        //        else
        //        {
        //            sr = File.AppendText(filename);
        //        }
        //        sr.WriteLine(strMemo);
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        if (sr != null)
        //            sr.Close();
        //    }
        //}

        
	}
}