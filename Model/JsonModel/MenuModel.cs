using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.JsonModel
{
    /********************************
     *
1、click：点击推事件
用户点击click类型按钮后，微信服务器会通过消息接口推送消息类型为event	的结构给开发者（参考消息接口指南），并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互；
2、view：跳转URL
用户点击view类型按钮后，微信客户端将会打开开发者在按钮中填写的网页URL，可与网页授权获取用户基本信息接口结合，获得用户基本信息。
3、scancode_push：扫码推事件
用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后显示扫描结果（如果是URL，将进入URL），且会将扫码的结果传给开发者，开发者可以下发消息。
4、scancode_waitmsg：扫码推事件且弹出“消息接收中”提示框
用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后，将扫码的结果传给开发者，同时收起扫一扫工具，然后弹出“消息接收中”提示框，随后可能会收到开发者下发的消息。
5、pic_sysphoto：弹出系统拍照发图
用户点击按钮后，微信客户端将调起系统相机，完成拍照操作后，会将拍摄的相片发送给开发者，并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。
6、pic_photo_or_album：弹出拍照或者相册发图
用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。用户选择后即走其他两种流程。
7、pic_weixin：弹出微信相册发图器
用户点击按钮后，微信客户端将调起微信相册，完成选择操作后，将选择的相片发送给开发者的服务器，并推送事件给开发者，同时收起相册，随后可能会收到开发者下发的消息。
8、location_select：弹出地理位置选择器
用户点击按钮后，微信客户端将调起地理位置选择工具，完成选择操作后，将选择的地理位置发送给开发者的服务器，同时收起位置选择工具，随后可能会收到开发者下发的消息。
     *********************************/

    public enum MenuButtonType
    {
        /// <summary>
        /// 点击推事件
        /// </summary>
        click = 0,
        /// <summary>
        /// 跳转URL
        /// </summary>
        view = 1,
        /// <summary>
        /// 扫码推事件
        /// </summary>
        scancode_push = 2,
        /// <summary>
        /// 扫码推事件且弹出“消息接收中”提示框
        /// </summary>
        scancode_waitmsg = 3,
        /// <summary>
        /// 弹出系统拍照发图
        /// </summary>
        pic_sysphoto=4,
        /// <summary>
        /// 弹出拍照或者相册发图
        /// </summary>
        pic_photo_or_album=5,
        /// <summary>
        /// 弹出微信相册发图器
        /// </summary>
        pic_weixin=6,
        /// <summary>
        /// 弹出地理位置选择器
        /// </summary>
        location_select = 7
    }

    public enum MenuButtonKey
    {
        sub_button1 = 0,
        sub_button2 = 1,
        buttonMessage = 2,
        buttonMemberFee = 3
    }


    [DataContract]
    public class MenuModel
    {
        [DataMember(Order = 0)]
        public Button[] button;

    }

    [DataContract]
    public class Sub_button:Button
    {
        
    }

    [DataContract]
    public class Button
    {
        [DataMember(Order = 0)]
        public string type { get; set; }
        [DataMember(Order = 1)]
        public string name { get; set; }
        [DataMember(Order = 2)]
        public string key { get; set; }
        [DataMember(Order = 3)]
        public string url { get; set; }
        [DataMember(Order = 4)]
        public Sub_button sub_button { get; set; }
    }

}
