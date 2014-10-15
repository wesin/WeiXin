using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule.MessageConsole
{
    public class MessageConsole
    {
        public WeixinMessageEntity entity;
        public MessageConsole(WeixinMessageEntity entity)
        {
            this.entity = entity;
        }
    }
}
