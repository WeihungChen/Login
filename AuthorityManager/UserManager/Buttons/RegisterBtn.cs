using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManager
{
    public class RegisterBtn : Button
    {
        public Control UserCtrl { get; set; }
        public Control PasswordCtrl { get; set; }

        protected override void OnClick(EventArgs e)
        {
            if (UserCtrl == null || PasswordCtrl == null)
                return;
            if (UserCtrl.Text == string.Empty || PasswordCtrl.Text == string.Empty)
            {
                MessageBox.Show("Please Enter UserName and Password!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Enabled = false;
            SynchronizationContext mainContext = SynchronizationContext.Current;
            Task.Run(() =>
            {
                var registerResult = HttpFunctions.Get<string>($"{GlobalAM.WebAPIAddr}//user//register", UserCtrl.Text, PasswordCtrl.Text);
                if (!registerResult.Success)
                    mainContext.Post(obj => { MessageBox.Show(registerResult.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }, null);
            }).ContinueWith(t =>
            {
                mainContext.Post(obj =>
                {
                    Enabled = true;
                    UserCtrl.Text = string.Empty;
                    PasswordCtrl.Text = string.Empty;
                }, null);
            });
        }
    }
}
