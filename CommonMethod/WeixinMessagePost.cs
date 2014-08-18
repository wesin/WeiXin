using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
