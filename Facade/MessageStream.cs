using CommonMethod;
using Model;
using Rule;
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
        int maxBytesCount = 4096;
        StreamWriter fs;
        int fileLenth;
        int nowFileLenth = 0;
        public bool ReadStream()
        {
            //fs = new StreamWriter("d://2.txt", true, Encoding.UTF8);
            Stream stream = HttpContext.Current.Request.InputStream;
            byte[] bt = new byte[2000000];
            nowFileLenth = stream.Read(bt, nowFileLenth, maxBytesCount);
            while ((fileLenth = stream.Read(bt, nowFileLenth, maxBytesCount)) > 0)
            {
                nowFileLenth += fileLenth;
            }
            string txt = System.Text.Encoding.UTF8.GetString(bt, 0, nowFileLenth);
            //File.AppendAllText("d://MessageFrom.txt", txt, Encoding.UTF8);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(txt);
            XmlElement xe = xml.DocumentElement;
            WeixinMessageEntity entity = ModelCommon.ConsoleXmlToModel(xe);

            MessageFactory factory = new MessageFactory(entity);
            var message = factory.ConsoleMessage();
            HttpContext.Current.Response.Write(message);
            return true;

        }

        
    }
}
