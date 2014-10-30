using CommonMethod;
using Model.JsonModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class WeiXinMenuFacade
    {
        public static string UpdateOwnMenu()
        {
            string json = "{\"button\":[{\"type\":\"click\",\"name\":\"会费\",\"key\":\"BtnMember\"}]}";
            string url = string.Format(WeiXinCommon.MenuCreate, WeiXinCommon.Access_token);
            WeixinMessagePost msgPost = new WeixinMessagePost(WeiXinCommon.MenuCreate);
            string result = msgPost.PostMessage(json);
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
