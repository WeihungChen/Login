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
    public partial class PageManagerUC : UserControl
    {
        private bool _preparing = false;

        public EventHandler<PageChangedEventArg> PageChangedEvent { get; set; }

        public PageManagerUC()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            UpdatePages();
        }

        public void UpdatePages()
        {
            _preparing = true;
            var pageList = HttpFunctions.Get<string[]>($"{GlobalAM.WebAPIAddr}//user//getallpages");
            PageCheckedListBox.Items.Clear();
            if(pageList.Success)
            {
                foreach (string page in pageList.Data)
                    PageCheckedListBox.Items.Add(page);
            }
            var allowedpageList = HttpFunctions.Get<string[]>($"{GlobalAM.WebAPIAddr}//user//getallowedpages");
            if(allowedpageList.Success)
            {
                foreach (string page in allowedpageList.Data)
                    PageCheckedListBox.SetItemChecked(PageCheckedListBox.Items.IndexOf(page), true);
            }
            _preparing = false;
        }

        private void PageCheckedListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(!_preparing)
            {
                string selectedPage = PageCheckedListBox.SelectedItem.ToString();
                bool changedValue = PageCheckedListBox.GetItemChecked(PageCheckedListBox.Items.IndexOf(selectedPage));
                var result = HttpFunctions.Get<bool>($"{GlobalAM.WebAPIAddr}//user//changepageauthority", selectedPage, changedValue);
                if (result.Success && result.Data && PageChangedEvent != null)
                    PageChangedEvent(this, new PageChangedEventArg
                    {
                        IsOpen = changedValue,
                        PageName = selectedPage
                    });
            }
        }
    }
}
