using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP_BackgroundWorker
{
    public partial class SingleThread : Form
    {
        public SingleThread()
        {
            InitializeComponent();

        }

        private int DoWork(int i)
        {
            System.Threading.Thread.Sleep(250);
            return i * 1000;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            int numericValue = (int)numericUpDownMax.Value;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < numericValue; i++)
            {
                sb.Append(string.Format("Menghitung angka : {0}{1}", DoWork(i), Environment.NewLine));
            }

            String result = sb.ToString();
            txtResult.Text = result;
            lblStatus.Text = "Selesai";
            btnStart.Enabled = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            txtResult.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtResult.Visible = true;
        }
    }
}
