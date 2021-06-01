
namespace TrillionIce
{
    partial class FM_SysMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FM_SysMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.FM_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.FM_OrderConfirm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stbItem = new System.Windows.Forms.ToolStripButton();
            this.stbOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stbClose = new System.Windows.Forms.ToolStripButton();
            this.stbExit = new System.Windows.Forms.ToolStripButton();
            this.myTabControl1 = new TrillionIce.MyTabControl();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MistyRose;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSystem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mSystem
            // 
            this.mSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FM_Item,
            this.FM_OrderConfirm});
            this.mSystem.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mSystem.ForeColor = System.Drawing.Color.Black;
            this.mSystem.Name = "mSystem";
            this.mSystem.Size = new System.Drawing.Size(101, 24);
            this.mSystem.Text = "시스템 관리";
            this.mSystem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mSystem_DropDownItemClicked);
            // 
            // FM_Item
            // 
            this.FM_Item.Name = "FM_Item";
            this.FM_Item.Size = new System.Drawing.Size(224, 26);
            this.FM_Item.Text = "품목관리";
            // 
            // FM_OrderConfirm
            // 
            this.FM_OrderConfirm.Name = "FM_OrderConfirm";
            this.FM_OrderConfirm.Size = new System.Drawing.Size(224, 26);
            this.FM_OrderConfirm.Text = "주문접수";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.MistyRose;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbItem,
            this.stbOrder,
            this.toolStripSeparator1,
            this.stbClose,
            this.stbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1030, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stbItem
            // 
            this.stbItem.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stbItem.Image = global::TrillionIce.Properties.Resources.icons8_search_50;
            this.stbItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbItem.Name = "stbItem";
            this.stbItem.Size = new System.Drawing.Size(85, 24);
            this.stbItem.Text = "품목관리";
            this.stbItem.Click += new System.EventHandler(this.stbItem_Click);
            // 
            // stbOrder
            // 
            this.stbOrder.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stbOrder.Image = global::TrillionIce.Properties.Resources.icons8_plus_50;
            this.stbOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbOrder.Name = "stbOrder";
            this.stbOrder.Size = new System.Drawing.Size(81, 24);
            this.stbOrder.Text = "주문접수";
            this.stbOrder.Click += new System.EventHandler(this.stbOrder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // stbClose
            // 
            this.stbClose.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stbClose.Image = global::TrillionIce.Properties.Resources.icons8_delete_document_50;
            this.stbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbClose.Name = "stbClose";
            this.stbClose.Size = new System.Drawing.Size(63, 24);
            this.stbClose.Text = "닫기";
            this.stbClose.Click += new System.EventHandler(this.stbClose_Click);
            // 
            // stbExit
            // 
            this.stbExit.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stbExit.Image = global::TrillionIce.Properties.Resources.icons8_delete_50;
            this.stbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbExit.Name = "stbExit";
            this.stbExit.Size = new System.Drawing.Size(55, 24);
            this.stbExit.Text = "종료";
            this.stbExit.Click += new System.EventHandler(this.stbExit_Click);
            // 
            // myTabControl1
            // 
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl1.Location = new System.Drawing.Point(0, 55);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(1030, 496);
            this.myTabControl1.TabIndex = 1;
            // 
            // FM_SysMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(1030, 551);
            this.Controls.Add(this.myTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FM_SysMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrillionIce (관리자)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mSystem;
        private System.Windows.Forms.ToolStripMenuItem FM_Item;
        private System.Windows.Forms.ToolStripMenuItem FM_OrderConfirm;
        private MyTabControl myTabControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton stbItem;
        private System.Windows.Forms.ToolStripButton stbOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton stbClose;
        private System.Windows.Forms.ToolStripButton stbExit;
    }
}