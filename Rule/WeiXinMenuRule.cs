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
        public MenuModel CreateMenu()
        {
            Sub_button sb = new Sub_button()
            {
                key = MenuButtonKey.sub_button1.ToString(),
                name = "子菜单1",
                type = MenuButtonType.pic_sysphoto.ToString()
            };
            Button button = new Button()
            {
                name = "菜单",
                sub_button = sb
            };
            Button button2 = new Button()
            {
                name = "消息",
                key = MenuButtonKey.buttonMessage.ToString(),
                type = MenuButtonType.location_select.ToString()
            };
            Button button3 = new Button()
            {
                name = "会费",
                key = MenuButtonKey.buttonMemberFee.ToString(),
                type = MenuButtonType.click.ToString()
            };
            MenuModel menuModel = new MenuModel();
            menuModel.button = new Button[] { button, button2, button3 };
            return menuModel;
        }
    }
}
