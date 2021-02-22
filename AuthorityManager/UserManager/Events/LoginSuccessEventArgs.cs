using System;
using System.Collections.Generic;

namespace UserManager
{
    public class LoginSuccessEventArgs : EventArgs
    {
        public List<string> Pages { get; set; }
    }
}
