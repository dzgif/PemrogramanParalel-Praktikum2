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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            SingleThread single = new SingleThread();
            single.Show();
            this.Close();
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            MultiThread multi = new MultiThread();
            multi.Show();
            this.Close();
        }


    }
}
