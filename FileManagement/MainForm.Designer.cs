namespace FileManagement
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.tb_DbName = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(54, 103);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.Size = new System.Drawing.Size(199, 106);
            this.dgvMain.TabIndex = 0;
            // 
            // tb_DbName
            // 
            this.tb_DbName.Location = new System.Drawing.Point(28, 33);
            this.tb_DbName.Name = "tb_DbName";
            this.tb_DbName.Size = new System.Drawing.Size(239, 20);
            this.tb_DbName.TabIndex = 1;
            this.tb_DbName.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxDragDrop);
            this.tb_DbName.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxDragEnter);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(386, 117);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 2;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 286);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.tb_DbName);
            this.Controls.Add(this.dgvMain);
            this.Name = "MainForm";
            this.Text = "FileManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.TextBox tb_DbName;
        private System.Windows.Forms.Button btn_Connect;
    }
}

