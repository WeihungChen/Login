using System;
using System.Windows.Forms;

namespace UserManager
{
    public class LogoutBtn : Button
    {
        public EventHandler<EventArgs> LogoutEvent { get; set; }

        protected override void OnClick(EventArgs e)
        {
            var result = HttpFunctions.Get<string>($"{GlobalAM.WebAPIAddr}//user//logout");
            if (LogoutEvent != null && result.Success)
                LogoutEvent(this, new EventArgs());
        }
    }
}
