using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroYz.MVC.HelpController;

namespace ZeroYz.MVC.View
{
    class ViewLogin
    {
        public string GetLogin (string loginCheckOdb)
        {
            return DateBaseControllerHelp.GetLoginMain(loginCheckOdb);
        }
    }
}
