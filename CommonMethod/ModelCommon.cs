using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommonMethod
{
    public static class ModelCommon
    {
        /// <summary>
        /// 将内容转化为实体
        /// </summary>
        /// <param name="xe"></param>
        /// <returns></returns>
        public static WeixinMessageEntity ConsoleXmlToModel(XmlElement xe)
        {
            var model = new WeixinMessageEntity();
            model.FromUser = xe.SelectSingleNode("FromUserName").InnerText;
            switch (xe.SelectSingleNode("MsgType").InnerText)
            {
                case "text":
                    model.MsgType = MsgType.text;
                    model.Content = xe.SelectSingleNode("Content").InnerText;
                    model.MessageID = xe.SelectSingleNode("MsgId").InnerText;
                    model.ToUser = xe.SelectSingleNode("ToUserName").InnerText;
                    model.CreateTime = xe.SelectSingleNode("CreateTime").InnerText;
                    break;
                case "event":
                    model.MsgType = MsgType.Event;
                    model.Event = xe.SelectSingleNode("Event").InnerText;
                    model.EventKey = xe.SelectSingleNode("EventKey").InnerText;
                    break;
                default:
                    model.MsgType = MsgType.text;
                    break;
            }
            return model;
        }

        public static WeixinMessageEntity CreateSendModel(WeixinMessageEntity sourceEntity)
        {
            var model = new WeixinMessageEntity
            {
                CreateTime = CommonMethod.DateTimeToUnixInt(DateTime.Now).ToString(),
                FromUser = sourceEntity.ToUser,
                ToUser = sourceEntity.FromUser,
                MessageID = sourceEntity.MessageID
            };
            return model;
        }

        public static WeixinMessageEntity CreateToSendModel(WeixinMessageEntity sourceEntity)
        {
            var model = new WeixinMessageEntity
            {
                CreateTime = CommonMethod.DateTimeToUnixInt(DateTime.Now).ToString(),
                FromUser = sourceEntity.ToUser,
                ToUser = sourceEntity.FromUser,
                MessageID = sourceEntity.MessageID
            };
            return model;
        }


        public static string Send_Msg<T>(T t, ref string msg)
        {
            if (t == null)
                return "";
            StringBuilder strB = new StringBuilder();
            strB.Append("<xml>");
            foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
            {
                strB.Append(string.Format("<{0}>{1}</{0}>", p.Name, p.GetValue(t, null).ToString()));
            }
            strB.Append("</xml>");
            return strB.ToString();
        }
    }
}
