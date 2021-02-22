using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManager
{
    public class PageManagerBtn : Button
    {
        private Control _mainUC;
        private PageManagerUC _pageManagerUC = null;

        public EventHandler<PageChangedEventArg> PageChangedEvent { get; set; }

        public void SetMainUC(Control mainUC)
        {
            _mainUC = mainUC;
        }

        protected override void OnClick(EventArgs e)
        {
            if (_mainUC != null)
            {
                if (_mainUC.Controls.Contains(_pageManagerUC))
                {
                    _mainUC.Controls.Remove(_pageManagerUC);
                    _pageManagerUC = null;
                }
                else
                {
                    _pageManagerUC = new PageManagerUC();
                    _pageManagerUC.PageChangedEvent = PageChangedEvent;
                    _mainUC.Controls.Add(_pageManagerUC);
                    _pageManagerUC.Dock = DockStyle.Fill;
                    _pageManagerUC.BringToFront();
                }
            }
        }
    }
}
