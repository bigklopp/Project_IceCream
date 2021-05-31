
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowHeadersWidth = 51;
            this.dgvGrid.RowTemplate.Height = 27;
            this.dgvGrid.Size = new System.Drawing.Size(800, 361);
            this.dgvGrid.TabIndex = 0;
            // 
            // btnOrderConfirm
            // 
            this.btnOrderConfirm.Location = new System.Drawing.Point(451, 367);
            this.btnOrderConfirm.Name = "btnOrderConfirm";
            this.btnOrderConfirm.Size = new System.Drawing.Size(155, 54);
            this.btnOrderConfirm.TabIndex = 1;
            this.btnOrderConfirm.Text = "주문 확정";
            this.btnOrderConfirm.UseVisualStyleBackColor = true;
            this.btnOrderConfirm.Click += new System.EventHandler(this.btnOrderConfirm_Click);
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.Location = new System.Drawing.Point(622, 367);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(151, 54);
            this.btnOrderCancel.TabIndex = 2;
            this.btnOrderCancel.Text = "주문 취소";
            this.btnOrderCancel.UseVisualStyleBackColor = true;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // FM_OrderConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOrderCancel);
            this.Controls.Add(this.btnOrderConfirm);
            this.Controls.Add(this.dgvGrid);
            this.Name = "FM_OrderConfirm";
            this.Text = "주문 내역";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FM_OrderConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.Button btnOrderConfirm;
        private System.Windows.Forms.Button btnOrderCancel;
    }
}

