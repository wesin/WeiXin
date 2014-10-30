using CommonMethod;
using Model;
using Rule;
using Rule.MessageConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Facade
{
    public class MessageStream
    {
        public string ReadStreamAndReply(HttpRequestBase request)
        {
            string txt = new WeiXinCommon().PostInput(request, Encoding.UTF8);
            FileMessageSave.MessageSave(txt);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(txt);
            XmlElement xe = xml.DocumentElement;
            WeixinMessageEntity entity = ModelCommon.ConsoleXmlToModel(xe);

            MessageFactory factory = new MessageFactory(entity);
            var message = factory.ConsoleMessage();
            FileMessageSave.MessageSave(message);
            return message;

        }



        
    }
}
