using CommonMethod;
using Model;
using Model.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rule.MessageConsole
{
    class TextMessageConsole:IConsoleMessage
    {
        private static string TextReplyJson = "{\"touser\":{0},\"msgtype\":\"text\",\"text\":{\"content\":{1}}}";
        private WeixinMessageEntity entity;
        public TextMessageConsole(WeixinMessageEntity entity)
        {
            this.entity = entity;
        }

        public string ConsoleMessage()
        {
            return PostMessageNIMEI();
        }

        private string PostMessageNIMEI()
        {
            var zhArray = new List<string>() { "你妹", "卧槽", "fuck", "二彩", "二采" };
            var wmArray = new List<string>(){"谢谢","你好"};
            string content = string.Empty;
            if (zhArray.IndexOf(entity.Content) >= 0)
            {
                content = "请做文明人，请温文尔雅！";
            }
            else if(wmArray.IndexOf(entity.Content) >= 0)
            {
                content = "你好我好大家好！";
            }
            else
            {
                content = "我什么都不知道啊！";
            }
            ContentModel contentModel = new ContentModel() { content = content };
            TextMessageModel textModel = new TextMessageModel()
            {
                text = contentModel,
                touser = entity.FromUser,
                msgtype = MsgType.text.ToString()
            };

            string message = JsonHelper.JsonSerializer(textModel);
            FileMessageSave.MessageSave(message);

            WeixinMessagePost msgPost = new WeixinMessagePost();
            msgPost.MsgUrl = string.Format(WeiXinCommon.MessageSend, WeiXinCommon.Access_token);
            string result = msgPost.PostMessage(message);

            ResultModel model = JsonHelper.JsonDeserialize<ResultModel>(result);
            if (model.errcode == "0")
            {
                return "success";
            }
            else
            {
                return model.errmsg;
            }
            
        }

        
    }
}
