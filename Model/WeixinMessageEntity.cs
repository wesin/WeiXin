using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum MsgType{
        Text=0
    }
    public class WeixinMessageEntity
    {
        private string toUser;
        /// <summary>
        /// 消息对象
        /// </summary>
        public string ToUser
        {
            get { return toUser; }
            set { toUser = value; }
        }

        private string fromUser;
        /// <summary>
        /// 来源用户
        /// </summary>
        public string FromUser
        {
            get { return fromUser; }
            set { fromUser = value; }
        }

        private string content;
        /// <summary>
        /// 信息内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private MsgType msgType;
        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }

        private string messageID;
        /// <summary>
        /// 信息记录标识
        /// </summary>
        public string MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }
    }
}
