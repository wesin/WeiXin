using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.JsonModel;

namespace Rule
{
    public enum ButtonList { 
        BtnMember = 0
    }
    public class WeiXinMenuRule
    {
        public MenuModel.button CreateMenu()
        {
            MenuModel.button btn = new MenuModel.button();
            btn.type = "click";
            btn.name = "会费";
            btn.key = ButtonList.BtnMember.ToString();
            return btn;
        }
    }
}
