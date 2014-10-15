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
            string json = "{\"touser\":\""+ entity.FromUser +"\",\"msgtype\":\"text\",\"text\":{\"content\":\"感谢您的支持\"}}";
            string url = string.Format(WeiXinCommon.MessageSend, WeiXinCommon.Access_token);
            string result = WeixinMessagePost.PostMessage(url, json);
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
