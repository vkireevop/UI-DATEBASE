using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kp
{
    static class Variables
    {
       public static string GlobalLogin;
       public static int GlobalCount;
       
        public static string TypeUser;
        public static int idStuff;
        public static bool Vip;
        public static int iduser;
       static public void Panel(TextBlock login , TextBlock type)
        {
            login.Text = Variables.GlobalLogin;
            type.Text = Variables.TypeUser;
        }
    }
}
