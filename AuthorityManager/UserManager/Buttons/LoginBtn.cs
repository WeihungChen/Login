using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UserManager
{
    public class LoginBtn : Button
    {
        public EventHandler<LoginSuccessEventArgs> LoginSuccessEvent { get; set; }
        public EventHandler<EventArgs> TimeoutEvent { get; set; }
        public Control UserCtrl { get; set; }
        public Control PasswordCtrl { get; set; }

        protected override void OnClick(EventArgs e)
        {
            if (UserCtrl == null || PasswordCtrl == null)
                return;
            if(UserCtrl.Text == string.Empty || PasswordCtrl.Text == string.Empty)
            {
                MessageBox.Show("Please Enter UserName and Password!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BtnEnable(false);
            SynchronizationContext mainContext = SynchronizationContext.Current;
            Task.Run(() =>
            {
                var loginResult = HttpFunctions.Get<string>($"{GlobalAM.WebAPIAddr}//user//login", UserCtrl.Text, PasswordCtrl.Text);
                if (!loginResult.Success)
                {
                    if (loginResult.Message != null)
                        MessageBox.Show(loginResult.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordCtrl.Text = string.Empty;
                    throw new Exception();
                }
                if (LoginSuccessEvent != null)
                {
                    // Get pages which are allowed to use
                    var getPageResult = HttpFunctions.Post<List<string>>($"{GlobalAM.WebAPIAddr}//user//pageauthority");
                    if(getPageResult.Success)
                    {
                        mainContext.Post(obj =>
                        {
                            LoginSuccessEvent(this, new LoginSuccessEventArgs
                            {
                                Pages = getPageResult.Data
                            });
                        }, null);
                    }
                }
            }).ContinueWith(t =>
            {
                mainContext.Post(obj =>
                {
                    BtnEnable(true);
                    if (t.Status == TaskStatus.RanToCompletion)
                        UserCtrl.Text = string.Empty;
                    PasswordCtrl.Text = string.Empty;
                }, null);
                CheckTimeout(mainContext);
            });
        }

        private void BtnEnable(bool enabled)
        {
            Enabled = enabled;
            //if (enabled)
            //    BackColor = _backColor;
            //else
            //    BackColor = Color.Gray;
        }

        private void CheckTimeout(SynchronizationContext mainContext)
        {
            if(TimeoutEvent != null)
            {
                Task.Run(() =>
                {
                    bool expired = false;
                    while (!expired)
                    {
                        expired = HttpFunctions.Post<bool>($"{GlobalAM.WebAPIAddr}//user//isexpired").Data;
                        Task.Delay(100);
                    }
                    mainContext.Post(obj => 
                    {
                        TimeoutEvent(this, new EventArgs());
                    }, null);
                });
            }
        }
    }
}
