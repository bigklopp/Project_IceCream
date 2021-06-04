
namespace TrillionIce
{
    partial class FM_ChangePw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FM_ChangePw));
            this.txtNewPw = new System.Windows.Forms.TextBox();
            this.txtCurrentPw = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChangePw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewPw
            // 
            this.txtNewPw.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNewPw.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNewPw.Location = new System.Drawing.Point(63, 363);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.Size = new System.Drawing.Size(245, 27);
            this.txtNewPw.TabIndex = 12;
            this.txtNewPw.Text = " New Password";
            this.txtNewPw.Enter += new System.EventHandler(this.txtNewPw_Enter);
            this.txtNewPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPw_KeyDown);
            // 
            // txtCurrentPw
            // 
            this.txtCurrentPw.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCurrentPw.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCurrentPw.Location = new System.Drawing.Point(62, 313);
            this.txtCurrentPw.Name = "txtCurrentPw";
            this.txtCurrentPw.Size = new System.Drawing.Size(245, 27);
            this.txtCurrentPw.TabIndex = 11;
            this.txtCurrentPw.Text = " Current Password";
            this.txtCurrentPw.Enter += new System.EventHandler(this.txtCurrentPw_Enter);
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUserId.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUserId.Location = new System.Drawing.Point(63, 263);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(245, 27);
            this.txtUserId.TabIndex = 10;
            this.txtUserId.Text = " Userid";
            this.txtUserId.Enter += new System.EventHandler(this.txtUserId_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(233, 464);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChangePw
            // 
            this.btnChangePw.BackColor = System.Drawing.Color.MistyRose;
            this.btnChangePw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePw.Font = new System.Drawing.Font("휴먼편지체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChangePw.ForeColor = System.Drawing.Color.DimGray;
            this.btnChangePw.Location = new System.Drawing.Point(63, 413);
            this.btnChangePw.Name = "btnChangePw";
            this.btnChangePw.Size = new System.Drawing.Size(245, 35);
            this.btnChangePw.TabIndex = 8;
            this.btnChangePw.Text = "패스워드 변경";
            this.btnChangePw.UseVisualStyleBackColor = false;
            this.btnChangePw.Click += new System.EventHandler(this.btnChangePw_Click);
            this.btnChangePw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnChangePw_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label1.Location = new System.Drawing.Point(119, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "TrillionIce";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TrillionIce.Properties.Resources.icons8_fruit_ice_cream_cone_100;
            this.pictureBox1.Location = new System.Drawing.Point(132, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 107);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // FM_ChangePw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(383, 547);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewPw);
            this.Controls.Add(this.txtCurrentPw);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangePw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FM_ChangePw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrillionIce";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNewPw;
        private System.Windows.Forms.TextBox txtCurrentPw;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChangePw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}