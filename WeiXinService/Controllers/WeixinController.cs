using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WeiXinService.Controllers
{
    public class WeixinController : Controller
    {
        //
        // GET: /Weixin/
        public ActionResult Index()
        {
            //string hha = Request.Url.ToString();// Request["wesin"];
            if (CommonMethod.WeixinCheck.CheckSignature())
            {
                Response.Write(Request.QueryString["echostr"]);
                Response.End();
            }
            if (Request.HttpMethod.ToLower() == "post")
            {
                MessageStream stream = new MessageStream();
                stream.ReadStreamAndReply(HttpContext.Request);
            }
            @ViewBag.WesinTitle = "Wesin";
            return View("Weixin");
        }

        public ActionResult GetToken()
        {
            return Content(CommonMethod.WeixinCheck.GetToken());    
        }

        public ActionResult UpdateOwnMenu()
        {
            return Content(new WeiXinMenuFacade().UpdateOwnMenu());
        }

        public ActionResult UserList()
        {
            return View("UserList");
        }

        
	}
}