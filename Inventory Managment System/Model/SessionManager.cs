using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public static class SessionManager
    {
        public static User LoggedInUser { get; private set; }

        public static void SetUser (User user)
        {
            LoggedInUser = user;
        }

        public static void Logout()
        {
            LoggedInUser = null;
        }
    }
}
