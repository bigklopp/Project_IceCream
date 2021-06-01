
namespace DevForm
{
    partial class FM_Item
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPicDelete = new System.Windows.Forms.Button();
            this.btnPicSave = new System.Windows.Forms.Button();
            this.btnLoadPic = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "품목명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "품목코드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(646, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "재고수량";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(770, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "~";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(91, 38);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(224, 28);
            this.txtItemName.TabIndex = 4;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(405, 38);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(219, 28);
            this.txtItemCode.TabIndex = 5;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(719, 38);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(45, 28);
            this.txtStart.TabIndex = 6;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(794, 38);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(49, 28);
            this.txtEnd.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MistyRose;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearch.Location = new System.Drawing.Point(893, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 29);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEnd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1611, 105);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "품목 검색";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Location = new System.Drawing.Point(36, 77);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.RowTemplate.Height = 27;
            this.dgvItem.Size = new System.Drawing.Size(794, 476);
            this.dgvItem.TabIndex = 10;
            this.dgvItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellClick);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(1212, 77);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(305, 238);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 11;
            this.picImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SeaShell;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.currentImage);
            this.groupBox2.Controls.Add(this.btnPicDelete);
            this.groupBox2.Controls.Add(this.btnPicSave);
            this.groupBox2.Controls.Add(this.btnLoadPic);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.picImage);
            this.groupBox2.Controls.Add(this.dgvItem);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(0, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1611, 582);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상품 상세";
            // 
            // btnPicDelete
            // 
            this.btnPicDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnPicDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPicDelete.ForeColor = System.Drawing.Color.DimGray;
            this.btnPicDelete.Location = new System.Drawing.Point(1456, 341);
            this.btnPicDelete.Name = "btnPicDelete";
            this.btnPicDelete.Size = new System.Drawing.Size(61, 30);
            this.btnPicDelete.TabIndex = 17;
            this.btnPicDelete.Text = "삭제";
            this.btnPicDelete.UseVisualStyleBackColor = false;
            this.btnPicDelete.Click += new System.EventHandler(this.btnPicDelete_Click);
            // 
            // btnPicSave
            // 
            this.btnPicSave.BackColor = System.Drawing.Color.MistyRose;
            this.btnPicSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPicSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnPicSave.Location = new System.Drawing.Point(1386, 341);
            this.btnPicSave.Name = "btnPicSave";
            this.btnPicSave.Size = new System.Drawing.Size(64, 30);
            this.btnPicSave.TabIndex = 16;
            this.btnPicSave.Text = "저장";
            this.btnPicSave.UseVisualStyleBackColor = false;
            this.btnPicSave.Click += new System.EventHandler(this.btnPicSave_Click);
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.BackColor = System.Drawing.Color.MistyRose;
            this.btnLoadPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadPic.ForeColor = System.Drawing.Color.DimGray;
            this.btnLoadPic.Location = new System.Drawing.Point(1212, 341);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(150, 30);
            this.btnLoadPic.TabIndex = 15;
            this.btnLoadPic.Text = "이미지 불러오기";
            this.btnLoadPic.UseVisualStyleBackColor = false;
            this.btnLoadPic.Click += new System.EventHandler(this.btnLoadPic_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MistyRose;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(174, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 29);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(313, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 29);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MistyRose;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(36, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 29);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(1212, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "이미지 추가";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(869, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 27);
            this.label6.TabIndex = 18;
            this.label6.Text = "상품 이미지";
            // 
            // currentImage
            // 
            this.currentImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.currentImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentImage.Location = new System.Drawing.Point(869, 77);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(305, 238);
            this.currentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentImage.TabIndex = 19;
            this.currentImage.TabStop = false;
            // 
            // FM_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1611, 687);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FM_Item";
            this.Text = "품목관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPicDelete;
        private System.Windows.Forms.Button btnPicSave;
        private System.Windows.Forms.Button btnLoadPic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox currentImage;
    }
}