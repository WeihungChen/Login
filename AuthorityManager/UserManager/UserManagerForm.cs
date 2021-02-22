using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManager
{
    public partial class UserManagerForm : Form
    {
        private LogInUC loginUC = new LogInUC();
        private MainUC mainUC = new MainUC();

        public UserManagerForm()
        {
            InitializeComponent();
            loginUC.LoginSuccessEvent += LoginSuccess;
            loginUC.TimeoutEvent += Logout;
            Controls.Add(loginUC);
            mainUC.LogoutEvent += Logout;
            Controls.Add(mainUC);
        }

        private void LoginSuccess(object sender, LoginSuccessEventArgs e)
        {
            mainUC.SetPages(e.Pages);
            mainUC.BringToFront();
        }

        private void Logout(object sender, EventArgs e)
        {
            loginUC.BringToFront();
        }
    }
}
