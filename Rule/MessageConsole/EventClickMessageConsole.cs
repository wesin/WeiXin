using CommonMethod;
using Model;
using Model.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule.MessageConsole
{
    public class EventClickMessageConsole : IConsoleMessage
    {
        private WeixinMessageEntity entity;
        public EventClickMessageConsole(WeixinMessageEntity entity)
        {
            this.entity = entity;
        }

        public string ConsoleMessage()
        {
            return PostMessageNIMEI();
        }

        private string PostMessageNIMEI()
        {
            ContentModel content = new ContentModel()
            {
                content = "感谢您的支持!"
            };
            TextMessageModel textModel = new TextMessageModel()
            {
                text = content,
                touser = entity.FromUser,
                msgtype = MsgType.text.ToString()
            };
            string json = JsonHelper.JsonSerializer(textModel);
            FileMessageSave.MessageSave(json);

            WeixinMessagePost msgPost = new WeixinMessagePost();
            msgPost.MsgUrl = string.Format(WeiXinCommon.MessageSend, WeiXinCommon.Access_token);
            string result = msgPost.PostMessage(json);
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
