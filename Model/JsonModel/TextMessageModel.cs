using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Model.JsonModel
{
    [DataContract]
    public class TextMessageModel
    {
        [DataMember(Order = 0)]
        public string touser{get;set;}

        [DataMember(Order = 1)]
        public string msgtype{get;set;}

        [DataMember(Order= 2)]
        public ContentModel text { get; set; }
    }

    [DataContract]
    public class ContentModel
    {
        [DataMember(Order=0)]
        public string content;
    }


}
