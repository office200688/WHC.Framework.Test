using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using UtilityLibrary.WinControls;
using TMIS.Properties;

namespace TMIS.Forms
{
    public partial class ToolWindow : DockContent
    {
        public ToolWindow()
        {
            InitializeComponent();
            //初始化工具条
            InitializeOutlookbar();
        }

        private MainForm mainForm;
        public ToolWindow(MainForm m)
        {
            InitializeComponent();
            this.mainForm = m;
            //初始化工具条
            InitializeOutlookbar();
        }

        private OutlookBar outlookBar1 = null;
        private void InitializeOutlookbar()
        {
            outlookBar1 = new OutlookBar();
            
            #region 仓库管理
            OutlookBarBand outlookShortcutsBand = new OutlookBarBand("仓库管理");
            outlookShortcutsBand.SmallImageList = this.imageList;
            outlookShortcutsBand.LargeImageList = this.imageList;
            outlookShortcutsBand.Items.Add(new OutlookBarItem("备件入库", 0));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("备件出库", 1));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("备件信息", 2));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("库存查询", 3));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("业务报表", 5));

            //outlookShortcutsBand.Background = SystemColors.AppWorkspace;
            outlookShortcutsBand.TextColor = Color.DarkSlateGray;//
            outlookBar1.Bands.Add(outlookShortcutsBand);

            #endregion

            #region 产品库存管理
            OutlookBarBand mystorageBand = new OutlookBarBand("产品库存管理");
            mystorageBand.SmallImageList = this.imageList;
            mystorageBand.LargeImageList = this.imageList;
            mystorageBand.Items.Add(new OutlookBarItem("产品管理", 6));
            mystorageBand.Items.Add(new OutlookBarItem("库存管理", 7));
            //mystorageBand.Background = SystemColors.AppWorkspace;
            mystorageBand.TextColor = Color.DarkSlateGray;
            outlookBar1.Bands.Add(mystorageBand);
            #endregion
            outlookBar1.Dock = DockStyle.Fill;
            outlookBar1.SetCurrentBand(0);
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);
            outlookBar1.ItemDropped += new OutlookBarItemDroppedHandler(OnOutlookBarItemDropped);

            //outlookBar1.FlatArrowButtons = true;
            //outlookBar1.BackgroundBitmap = Resources.BmpToolWindow;
            this.panel1.Controls.AddRange(new Control[] { outlookBar1 });//
        }

        private void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            switch (item.Text)
            {
                #region 销售管理

                case "备件入库":
                    mainForm.ShowContent("备件入库", typeof(Form备件入库));
                    break;
                case "备件出库":
                    mainForm.ShowContent("客户管理", typeof(Form备件出库));
                    break;
                case "库存查询":
                    mainForm.ShowContent("库存查询", typeof(Form库存查询));
                    break;
                case "备件信息":
                    mainForm.ShowContent("备件信息", typeof(Form备件信息));
                    break;
                case "套餐管理":
                    //FrmYouhui dlg = new FrmYouhui();
                    // dlg.ShowDialog();
                    break;
                case "来电记录":
                    //Portal.gc.MainDialog.ShowContent("来电记录", typeof(FrmComingCall));
                    break;
                case "送货记录":
                    //Portal.gc.MainDialog.ShowContent("送货记录", typeof(FrmDeliving));
                    break;

                #endregion

                #region 产品库存管理
                case "产品管理":
                    //Portal.gc.MainDialog.ShowContent("产品管理", typeof(FrmProduct));
                    break;
                case "库存管理":
                    //Portal.gc.MainDialog.ShowContent("库存管理", typeof(FrmStock));
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void OnOutlookBarItemDropped(OutlookBarBand band, OutlookBarItem item)
        {
            //            string message = "Item : " + item.Text + " was dropped";
            //            MessageBox.Show(message);            
        }
    }
}
