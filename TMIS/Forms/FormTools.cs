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
    public partial class FormTools : Form
    {
        public FormTools()
        {
            InitializeComponent();
        }
        #region NavigationBar代码实现

        private void InitNaviBar()
        {
            TreeView treeview1 = new TreeView();
            treeview1.ShowLines = false;
            treeview1.ImageList = this.imageList;

            //if (Portal.gc.HasFunction("Purchase"))
            {
                treeview1.Nodes.Add(new TreeNode("备件入库", 0, 0));
            }
            //if (Portal.gc.HasFunction("TakeOut"))
            {
                treeview1.Nodes.Add(new TreeNode("备件出库", 1, 1));
            }
            //if (Portal.gc.HasFunction("StockSearch"))
            {
                treeview1.Nodes.Add(new TreeNode("库存查询", 2, 2));
            }
            //if (Portal.gc.HasFunction("ItemDetail"))
            {
                treeview1.Nodes.Add(new TreeNode("备件信息", 3, 3));
            }
            //if (Portal.gc.HasFunction("Report"))
            {
                treeview1.Nodes.Add(new TreeNode("业务报表", 5, 5));
            }

            TreeView treeview2 = new TreeView();
            treeview2.ShowLines = false;
            treeview2.ImageList = this.imageList;
            //if (Portal.gc.HasFunction("Dictionary"))
            {
                treeview2.Nodes.Add(new TreeNode("数据字典", 4, 4));
            }
            //if (Portal.gc.HasFunction("WareHouse"))
            {
                treeview2.Nodes.Add(new TreeNode("库房管理", 6, 6));
            }

            treeview1.Dock = DockStyle.Fill;
            this.naviBand1.ClientArea.Controls.AddRange(new Control[] { treeview1 });

            treeview2.Dock = DockStyle.Fill;
            this.naviBand2.ClientArea.Controls.AddRange(new Control[] { treeview2 });
        }
        #endregion
    }
}
