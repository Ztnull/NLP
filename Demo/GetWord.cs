using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class frmGetWord : Form
    {
        private NLP.Word word = new NLP.Word();

        public frmGetWord()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            word.Content = txtSource.Text;
            string TempResult = word.GetWord(true);
            if (TempResult.IndexOf("外部词典读取出错") >= 0)
            {
                lblInfo.Text = TempResult;
                txtResult.Text = "";
            }
            else
            {
                txtResult.Text = TempResult;
                lblInfo.Text = "词语数量（含重复）：" + word.GetWordCount(true) + "\r";
                lblInfo.Text += "词语数量（不含重复）：" + word.GetWordCount(false);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            word.Content = txtSource.Text;
            string TempResult = word.GetWord(false);
            if (TempResult.IndexOf("外部词典读取出错") >= 0)
            {
                lblInfo.Text = TempResult;
                txtResult.Text = "";
            }
            else
            {
                txtResult.Text = TempResult;
                lblInfo.Text = "词语数量（含重复）：" + word.GetWordCount(true) + "\r";
                lblInfo.Text += "词语数量（不含重复）：" + word.GetWordCount(false);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            frmGetWord_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofdDictPath = new OpenFileDialog();
                ofdDictPath.ShowDialog();
                word.DictPath = ofdDictPath.FileName;
                txtDictPath.Text = word.DictPath;
                if (!string.IsNullOrEmpty(txtDictPath.Text))
                {
                    lblInfo.Text = "外部词典加载成功，请启动分词程序并返回结果";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "加载外部词典出错，" + ex.Message;
            }
        }

        private void btnImportDict_Click(object sender, EventArgs e)
        {
            frmImportDict frmImportDict = new frmImportDict();
            frmImportDict.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmGetWord_Load(object sender, EventArgs e)
        {
            txtResult.Text = "";
            txtSource.Text = "";
            lblInfo.Text = "软件准备就绪，请发送指令";
        }

    }//class
}
