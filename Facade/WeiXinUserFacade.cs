using CommonMethod;
using Model.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class WeiXinUserFacade
    {
        public string UpdateOwnMenu()
        {
            WeixinMessagePost msgPost = new WeixinMessagePost();
            msgPost.MsgUrl = string.Format(WeiXinCommon.UserGet, WeiXinCommon.Access_token, "");
            string result = msgPost.PostMessage("");
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
