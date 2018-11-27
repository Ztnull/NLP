namespace Demo
{
    partial class frmImportDict
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnReadTxt = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoadTxt = new System.Windows.Forms.Button();
            this.txtTxtPath = new System.Windows.Forms.TextBox();
            this.btnLoadDict = new System.Windows.Forms.Button();
            this.btnImportDict = new System.Windows.Forms.Button();
            this.txtDictPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tmrProcessBar = new System.Windows.Forms.Timer(this.components);
            this.lblProcessBar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSource.Location = new System.Drawing.Point(6, 197);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSource.Size = new System.Drawing.Size(835, 197);
            this.txtSource.TabIndex = 1;
            // 
            // btnReadTxt
            // 
            this.btnReadTxt.Location = new System.Drawing.Point(335, 395);
            this.btnReadTxt.Name = "btnReadTxt";
            this.btnReadTxt.Size = new System.Drawing.Size(87, 38);
            this.btnReadTxt.TabIndex = 2;
            this.btnReadTxt.Text = "转换为JSON";
            this.btnReadTxt.UseVisualStyleBackColor = true;
            this.btnReadTxt.Click += new System.EventHandler(this.btnReadTxt_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(105, 478);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 38);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.Khaki;
            this.txtResult.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResult.Location = new System.Drawing.Point(6, 5);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(835, 188);
            this.txtResult.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 478);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 38);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLoadTxt
            // 
            this.btnLoadTxt.Location = new System.Drawing.Point(167, 398);
            this.btnLoadTxt.Name = "btnLoadTxt";
            this.btnLoadTxt.Size = new System.Drawing.Size(140, 35);
            this.btnLoadTxt.TabIndex = 6;
            this.btnLoadTxt.Text = "选择原始词典文本文件";
            this.btnLoadTxt.UseVisualStyleBackColor = true;
            this.btnLoadTxt.Click += new System.EventHandler(this.btnLoadTxt_Click);
            // 
            // txtTxtPath
            // 
            this.txtTxtPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTxtPath.Location = new System.Drawing.Point(6, 400);
            this.txtTxtPath.Multiline = true;
            this.txtTxtPath.Name = "txtTxtPath";
            this.txtTxtPath.Size = new System.Drawing.Size(155, 30);
            this.txtTxtPath.TabIndex = 7;
            // 
            // btnLoadDict
            // 
            this.btnLoadDict.Location = new System.Drawing.Point(617, 398);
            this.btnLoadDict.Name = "btnLoadDict";
            this.btnLoadDict.Size = new System.Drawing.Size(102, 35);
            this.btnLoadDict.TabIndex = 8;
            this.btnLoadDict.Text = "选择外部词典";
            this.btnLoadDict.UseVisualStyleBackColor = true;
            this.btnLoadDict.Click += new System.EventHandler(this.btnLoadDict_Click);
            // 
            // btnImportDict
            // 
            this.btnImportDict.Location = new System.Drawing.Point(754, 396);
            this.btnImportDict.Name = "btnImportDict";
            this.btnImportDict.Size = new System.Drawing.Size(87, 38);
            this.btnImportDict.TabIndex = 2;
            this.btnImportDict.Text = "写入词典";
            this.btnImportDict.UseVisualStyleBackColor = true;
            this.btnImportDict.Click += new System.EventHandler(this.btnImportDict_Click);
            // 
            // txtDictPath
            // 
            this.txtDictPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDictPath.Location = new System.Drawing.Point(456, 400);
            this.txtDictPath.Multiline = true;
            this.txtDictPath.Name = "txtDictPath";
            this.txtDictPath.Size = new System.Drawing.Size(155, 30);
            this.txtDictPath.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(311, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "▶";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(429, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "▶";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(725, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "▶";
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.YellowGreen;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblInfo.Location = new System.Drawing.Point(433, 444);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(408, 76);
            this.lblInfo.TabIndex = 17;
            // 
            // tmrProcessBar
            // 
            this.tmrProcessBar.Interval = 10;
            this.tmrProcessBar.Tick += new System.EventHandler(this.tmrProcessBar_Tick);
            // 
            // lblProcessBar
            // 
            this.lblProcessBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblProcessBar.Location = new System.Drawing.Point(434, 509);
            this.lblProcessBar.Name = "lblProcessBar";
            this.lblProcessBar.Size = new System.Drawing.Size(0, 10);
            this.lblProcessBar.TabIndex = 18;
            // 
            // frmImportDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(845, 528);
            this.Controls.Add(this.lblProcessBar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDictPath);
            this.Controls.Add(this.btnLoadDict);
            this.Controls.Add(this.txtTxtPath);
            this.Controls.Add(this.btnLoadTxt);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImportDict);
            this.Controls.Add(this.btnReadTxt);
            this.Controls.Add(this.txtSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmImportDict";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入自定义词典";
            this.Load += new System.EventHandler(this.frmImportDict_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnReadTxt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLoadTxt;
        private System.Windows.Forms.TextBox txtTxtPath;
        private System.Windows.Forms.Button btnLoadDict;
        private System.Windows.Forms.Button btnImportDict;
        private System.Windows.Forms.TextBox txtDictPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer tmrProcessBar;
        private System.Windows.Forms.Label lblProcessBar;
    }
}

