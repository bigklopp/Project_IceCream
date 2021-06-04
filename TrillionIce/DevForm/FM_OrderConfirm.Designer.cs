
namespace DevForm
{
    partial class FM_OrderConfirm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.btnOrderConfirm = new System.Windows.Forms.Button();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.Location = new System.Drawing.Point(3, 23);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowHeadersWidth = 51;
            this.dgvGrid.RowTemplate.Height = 27;
            this.dgvGrid.Size = new System.Drawing.Size(1130, 513);
            this.dgvGrid.TabIndex = 0;
            // 
            // btnOrderConfirm
            // 
            this.btnOrderConfirm.BackColor = System.Drawing.Color.MistyRose;
            this.btnOrderConfirm.Font = new System.Drawing.Font("휴먼편지체", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderConfirm.ForeColor = System.Drawing.Color.DimGray;
            this.btnOrderConfirm.Location = new System.Drawing.Point(535, 78);
            this.btnOrderConfirm.Name = "btnOrderConfirm";
            this.btnOrderConfirm.Size = new System.Drawing.Size(220, 91);
            this.btnOrderConfirm.TabIndex = 1;
            this.btnOrderConfirm.Text = "주문 확정 : )";
            this.btnOrderConfirm.UseVisualStyleBackColor = false;
            this.btnOrderConfirm.Click += new System.EventHandler(this.btnOrderConfirm_Click);
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnOrderCancel.Font = new System.Drawing.Font("휴먼편지체", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderCancel.Location = new System.Drawing.Point(807, 78);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(214, 91);
            this.btnOrderCancel.TabIndex = 2;
            this.btnOrderCancel.Text = "주문 취소 : <";
            this.btnOrderCancel.UseVisualStyleBackColor = false;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOrderConfirm);
            this.groupBox1.Controls.Add(this.btnOrderCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(0, 539);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 239);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("휴먼편지체", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1136, 539);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // FM_OrderConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FM_OrderConfirm";
            this.Text = "주문 내역";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FM_OrderConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.Button btnOrderConfirm;
        private System.Windows.Forms.Button btnOrderCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

