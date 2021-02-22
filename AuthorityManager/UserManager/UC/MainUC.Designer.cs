namespace UserManager
{
    partial class MainUC
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.logoutBtn1 = new UserManager.LogoutBtn();
            this.pageManagerBtn = new UserManager.PageManagerBtn();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.logoutBtn1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.MainPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pageManagerBtn, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 362);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(589, 321);
            this.MainTabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(581, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.MainPanel, 3);
            this.MainPanel.Controls.Add(this.MainTabControl);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(3, 38);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(589, 321);
            this.MainPanel.TabIndex = 3;
            // 
            // logoutBtn1
            // 
            this.logoutBtn1.BackColor = System.Drawing.Color.SkyBlue;
            this.logoutBtn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoutBtn1.Location = new System.Drawing.Point(520, 0);
            this.logoutBtn1.LogoutEvent = null;
            this.logoutBtn1.Margin = new System.Windows.Forms.Padding(0);
            this.logoutBtn1.Name = "logoutBtn1";
            this.logoutBtn1.Size = new System.Drawing.Size(75, 35);
            this.logoutBtn1.TabIndex = 1;
            this.logoutBtn1.Text = "登出";
            this.logoutBtn1.UseVisualStyleBackColor = false;
            // 
            // pageManagerBtn
            // 
            this.pageManagerBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pageManagerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageManagerBtn.Location = new System.Drawing.Point(0, 0);
            this.pageManagerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.pageManagerBtn.Name = "pageManagerBtn";
            this.pageManagerBtn.Size = new System.Drawing.Size(75, 35);
            this.pageManagerBtn.TabIndex = 4;
            this.pageManagerBtn.Text = "功能";
            this.pageManagerBtn.UseVisualStyleBackColor = false;
            // 
            // MainUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainUC";
            this.Size = new System.Drawing.Size(595, 362);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UserManager.LogoutBtn logoutBtn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel MainPanel;
        private PageManagerBtn pageManagerBtn;
    }
}
