using System;
using System.Windows.Forms;

namespace UserManager
{
    public partial class LogInUC : UserControl
    {
        public EventHandler<LoginSuccessEventArgs> LoginSuccessEvent { get { return loginBtn1.LoginSuccessEvent; } set { loginBtn1.LoginSuccessEvent = value; } }
        public EventHandler<EventArgs> TimeoutEvent { get { return loginBtn1.TimeoutEvent; } set { loginBtn1.TimeoutEvent = value; } }

        public LogInUC()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            Dock = DockStyle.Fill;
            loginBtn1.UserCtrl = UserTB;
            loginBtn1.PasswordCtrl = PasswordTB;
            registerBtn1.UserCtrl = UserTB;
            registerBtn1.PasswordCtrl = PasswordTB;
        }
    }
}
