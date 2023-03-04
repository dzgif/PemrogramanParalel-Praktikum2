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
    public partial class MultiThread : Form
    {

        BackgroundWorker bw = new BackgroundWorker();

        public MultiThread()
        {
            InitializeComponent();

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);

            bw.WorkerReportsProgress = true;

            bw.WorkerSupportsCancellation = true;
        }

        protected void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            object[] arrObj = (object[])e.Argument;
            int maxValue = (int)arrObj[0];

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < maxValue; i++)
            {
                if (!sendingWorker.CancellationPending)
                {
                    sb.Append(string.Format("Menghitung angka : {0}{1}", DoTask(i), Environment.NewLine));
                    sendingWorker.ReportProgress(i);
                }
                else
                {
                    e.Cancel = true;
                    break;
                }
            }

            e.Result = sb.ToString();

        }

        protected void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                String result = (string)e.Result;
                txtResult.Text = result;
                lblStatus.Text = "Selesai";

            }
            else if (!e.Cancelled)
            {
                lblStatus.Text = "User Canceled!";
            }
            else
            {
                lblStatus.Text = "Something Error!";
            }

            btnStart.Enabled = true;

        }

        protected void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = string.Format("Menghitung angka : {0}..", e.ProgressPercentage);
        }

        private int DoTask(int i)
        {
            System.Threading.Thread.Sleep(250);
            return i * 1000;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            txtResult.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int numericValue = (int)numericUpDownMax.Value;
            object[] arrObj = new object[] { numericValue };
            if (!bw.IsBusy)
            {
                btnStart.Enabled = false;
                bw.RunWorkerAsync(arrObj);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtResult.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
        }
    }
}
