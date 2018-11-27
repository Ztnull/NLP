using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class frmImportDict : Form
    {
        private NLP.Word word = new NLP.Word();
        public string FileName;

        public frmImportDict()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSource.Text = "";
            txtResult.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDictPath = new OpenFileDialog();
            ofdDictPath.ShowDialog();
            word.DictPath = ofdDictPath.FileName;
            txtTxtPath.Text = word.DictPath;
        }

        private void btnGetWord_Click(object sender, EventArgs e)
        {
            frmGetWord frmGetWord = new frmGetWord();
            frmGetWord.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLoadTxt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofdTxtPath = new OpenFileDialog();
                ofdTxtPath.ShowDialog();
                FileName = ofdTxtPath.FileName;
                if (!string.IsNullOrEmpty(FileName))
                {
                    lblInfo.Text = "数据加载中，请稍等";
                    tmrProcessBar.Enabled = true;
                    Thread thread = new Thread(LoadtxtSource);
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "加载原始词典文件出错，" + ex.Message;
            }

        }

        public void LoadtxtSource()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            txtTxtPath.Text = FileName;
            FileStream fs = new FileStream(txtTxtPath.Text, FileMode.Open);
            byte[] bt = new byte[fs.Length];
            txtSource.Text = Encoding.Default.GetString(bt, 0, fs.Read(bt, 0, bt.Length));
            fs.Close();
            fs.Dispose();
            lblInfo.Text = "数据加载完毕，可以转换为JSON";
            tmrProcessBar.Enabled = false;
        }

        private void btnReadTxt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text))
            {
                lblInfo.Text = "没有可以转换的数据，请先加载原始词典文本";
                return;
            }
            lblInfo.Text = "转换中，请稍等";
            Thread thread = new Thread(GetDictJson);
            thread.IsBackground = true;
            thread.Start();
        }

        private void GetDictJson()
        {
            txtResult.Text = word.GetDictJson(txtSource.Text);
            lblInfo.Text = "转换完毕，请选择要保存的外部词典";
        }

        private void btnLoadDict_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdTxtPath = new OpenFileDialog();
            ofdTxtPath.ShowDialog();
            FileName = ofdTxtPath.FileName;
            if (!string.IsNullOrEmpty(FileName))
            {
                txtDictPath.Text = FileName;
            }
        }

        private void btnImportDict_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text) || string.IsNullOrEmpty(txtResult.Text) || string.IsNullOrEmpty(txtDictPath.Text) || string.IsNullOrEmpty(txtTxtPath.Text))
            {
                lblInfo.Text = "写入词典文件出错！请先完成前面所有操作";
                return;
            }
            if (word.UpdateDict(txtResult.Text, txtDictPath.Text))
            {
                lblInfo.Text = "写入词典文件成功！文件位置：" + txtDictPath.Text;
            }
            else
            {
                lblInfo.Text = "写入词典文件出错";
            }
        }

        private void frmImportDict_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            lblInfo.Text = "软件准备就绪，请发送指令";
            lblProcessBar.Width = 0;
        }

        private void tmrProcessBar_Tick(object sender, EventArgs e)
        {
            if (lblProcessBar.Width < lblInfo.Width - 2)
            {
                lblProcessBar.Width += 2;
            }
            else
            {
                tmrProcessBar.Enabled = false;
                tmrProcessBar.Dispose();
            }
        }

    }//class
}
