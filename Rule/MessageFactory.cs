using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule
{
    public class MessageFactory
    {
        private WeixinMessageEntity entity;
        public MessageFactory(WeixinMessageEntity entity)
        {
            this.entity = entity;
        }

        public string ConsoleMessage()
        {
            IConsoleMessage icm;
            switch (entity.MsgType)
            { 
                case MsgType.Text:
                    icm = new TextMessageConsole(entity);
                    break;
                default :
                    icm = new TextMessageConsole(entity);
                    break;
            }
            return icm.ConsoleMessage();
        }
    }
}
