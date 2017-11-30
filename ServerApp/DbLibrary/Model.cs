using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DbLibrary
{
    public class User
    {
        public int UserID { set; get; }

        public string Username { set; get; }

        public string Password { set; get; }

        public bool IsOniline { set; get; }
    }

    public class DbMessage
    {
        public int MessageID { set; get; }

        public string JSonObject { set; get; }
    }
}
