using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroYz.MVC.View;

namespace ZeroYz.MVC.Controller
{
    class ControllerLogin
    {
        public static string CheckLoginOdb(string loginCheck)
        {
            ViewLogin viewLogin = new ViewLogin();
            return viewLogin.GetLogin(loginCheck);
        }
    }
}
