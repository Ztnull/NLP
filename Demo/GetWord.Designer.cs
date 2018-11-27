namespace Demo
{
    partial class frmGetWord
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtDictPath = new System.Windows.Forms.TextBox();
            this.btnImportDict = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSource.Location = new System.Drawing.Point(6, 262);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSource.Size = new System.Drawing.Size(1175, 260);
            this.txtSource.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(5, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始分词并返回JSON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(680, 572);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.LightBlue;
            this.txtResult.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResult.Location = new System.Drawing.Point(6, 5);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(1175, 251);
            this.txtResult.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(374, 572);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "清除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(663, 531);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 35);
            this.button4.TabIndex = 6;
            this.button4.Text = "选择外部词典";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtDictPath
            // 
            this.txtDictPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDictPath.Location = new System.Drawing.Point(6, 534);
            this.txtDictPath.Multiline = true;
            this.txtDictPath.Name = "txtDictPath";
            this.txtDictPath.Size = new System.Drawing.Size(651, 30);
            this.txtDictPath.TabIndex = 7;
            // 
            // btnImportDict
            // 
            this.btnImportDict.Location = new System.Drawing.Point(522, 572);
            this.btnImportDict.Name = "btnImportDict";
            this.btnImportDict.Size = new System.Drawing.Size(152, 38);
            this.btnImportDict.TabIndex = 14;
            this.btnImportDict.Text = "启动 词典导入程序";
            this.btnImportDict.UseVisualStyleBackColor = true;
            this.btnImportDict.Click += new System.EventHandler(this.btnImportDict_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.Color.Green;
            this.button5.Location = new System.Drawing.Point(190, 572);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(179, 38);
            this.button5.TabIndex = 15;
            this.button5.Text = "开始分词并返回词语列表";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.YellowGreen;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblInfo.Location = new System.Drawing.Point(773, 534);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(408, 76);
            this.lblInfo.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(-2, 639);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1190, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "四川新华电脑学院 新软同创高科技研发中心 2017-2018 版权所有";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmGetWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1189, 662);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnImportDict);
            this.Controls.Add(this.txtDictPath);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGetWord";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "逆向最大匹配分词算法测试";
            this.Load += new System.EventHandler(this.frmGetWord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtDictPath;
        private System.Windows.Forms.Button btnImportDict;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label2;
    }
}

