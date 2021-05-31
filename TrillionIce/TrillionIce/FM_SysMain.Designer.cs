
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
            this.myTabControl1 = new TrillionIce.MyTabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
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
            this.mSystem.Name = "mSystem";
            this.mSystem.Size = new System.Drawing.Size(103, 24);
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
            // myTabControl1
            // 
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl1.Location = new System.Drawing.Point(0, 28);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(1030, 523);
            this.myTabControl1.TabIndex = 1;
            // 
            // FM_SysMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 551);
            this.Controls.Add(this.myTabControl1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mSystem;
        private System.Windows.Forms.ToolStripMenuItem FM_Item;
        private System.Windows.Forms.ToolStripMenuItem FM_OrderConfirm;
        private MyTabControl myTabControl1;
    }
}