using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MsgType
    {
        Text = 0,
        Event = 1

    }

    public class WeixinMessageEntity
    {
        /// <summary>
        /// 消息对象
        /// </summary>
        public string ToUser { get; set; }

        /// <summary>
        /// 来源用户
        /// </summary>
        public string FromUser { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType MsgType { get; set; }

        /// <summary>
        /// 信息记录标识
        /// </summary>
        public string MessageID { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 按钮唯一码
        /// </summary>
        public string EventKey { get; set; }
    }
}
