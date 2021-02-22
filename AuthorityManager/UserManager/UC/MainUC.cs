using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManager
{
    public partial class MainUC : UserControl
    {
        public EventHandler<EventArgs> LogoutEvent { get { return logoutBtn1.LogoutEvent; } set { logoutBtn1.LogoutEvent = value; } }

        public MainUC()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            Dock = DockStyle.Fill;
            pageManagerBtn.SetMainUC(MainPanel);
            pageManagerBtn.PageChangedEvent += PageChanged;
        }

        public void SetPages(List<string> pages)
        {
            MainTabControl.TabPages.Clear();
            foreach (var page in pages)
                MainTabControl.TabPages.Add(page, page);
        }

        private void PageChanged(object sender, PageChangedEventArg e)
        {
            if (e.IsOpen)
                MainTabControl.TabPages.Add(e.PageName, e.PageName);
            else
                MainTabControl.TabPages.RemoveByKey(e.PageName);
        }
    }
}
