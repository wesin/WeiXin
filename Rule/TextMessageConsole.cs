using CommonMethod;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule
{
    class TextMessageConsole:IConsoleMessage
    {
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
            var postEntity = ModelCommon.CreateSendModel(entity);
                postEntity.MsgType = MsgType.Text;
            var zhArray = new List<string>(){"你妹","卧槽","fuck","二彩","二采"};
            if (zhArray.IndexOf(entity.Content) >= 0)
            {
                postEntity.Content = "请做文明人，请温文尔雅！";
            }
            else
            {
                postEntity.Content = "我什么都不知道啊！";
            }
            return WeixinMessagePost.GetPostMessage(postEntity);
        }

        
    }
}
