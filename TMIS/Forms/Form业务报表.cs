using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TMIS.Forms
{
    public partial class Form业务报表 : Form
    {
        public Form业务报表()
        {
            InitializeComponent();
        }

        private void glassButton各车间报表_Click(object sender, EventArgs e)
        {
            Form各车间报表 fm = new Form各车间报表();
            fm.ShowDialog();
        }
    }
}
