﻿using Model;
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
                    model.MsgType = MsgType.Text;
                    model.Content = xe.SelectSingleNode("Content").InnerText;
                    model.MessageID = xe.SelectSingleNode("MsgId").InnerText;
                    break;
                case "event":
                    model.MsgType = MsgType.Event;
                    model.Event = xe.SelectSingleNode("Event").InnerText;
                    model.EventKey = xe.SelectSingleNode("EventKey").InnerText;
                    break;
                default:
                    model.MsgType = MsgType.Text;
                    break;
            }
            return model;
        }

        public static WeixinMessageEntity CreateSendModel(WeixinMessageEntity sourceEntity)
        {
            var model = new WeixinMessageEntity
            {
                CreateTime = DateTime.Now.ToLongDateString(),
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
                CreateTime = DateTime.Now.ToLongDateString(),
                FromUser = sourceEntity.ToUser,
                ToUser = sourceEntity.FromUser,
                MessageID = sourceEntity.MessageID
            };
            return model;
        }
    }
}
