using System;

namespace UserManager
{
    public class PageChangedEventArg : EventArgs
    {
        public bool IsOpen { get; set; }
        public string PageName { get; set; }
    }
}
