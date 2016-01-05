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
    public partial class Form数据字典 : Form
    {
        public Form数据字典()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (treeView1.SelectedNode.Parent == null)
            //    label字典大类.Text = treeView1.SelectedNode.Text;
            //else
            //    label字典大类.Text = treeView1.SelectedNode.Parent.Text;
            label字典大类.Text = treeView1.SelectedNode.Text;
        }
    }
}
