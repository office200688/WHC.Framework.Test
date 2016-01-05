using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using TMIS.Forms;
using System.IO;
using WHC.Framework.Commons;

namespace TMIS.Forms
{
    public partial class MainForm : Form
    {
        private ToolWindow tools;
        private Form备件入库 beiJian = new Form备件入库();
        private Form备件出库 chuku = new Form备件出库();
        private Form备件信息 BeiJianXinXi = new Form备件信息();
        private Form库存查询 KuCunChaXun = new Form库存查询();

        

        public MainForm()
        {
            InitializeComponent();

            Splasher.Status = "正在展示相关的内容";
            System.Threading.Thread.Sleep(100);
            //加载布局（必须在使用dockpanel1之前调用）
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (File.Exists(configFile))
            {
                DeserializeDockContent m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
                dockPanel1.LoadFromXml(configFile, m_deserializeDockContent);
            }
            tools = new ToolWindow(this);
            tools.Show(dockPanel1, DockState.DockLeft);
            beiJian.Show(dockPanel1);

            Splasher.Status = "初始化完毕";
            System.Threading.Thread.Sleep(50);

            Splasher.Close();

            this.toolStripStatusLabel日历.Text = cal.GetDateInfo(System.DateTime.Now).Fullinfo;
            timer1.Start();
            //设置热键
            SetHotKey();
        }
        private int _globalDayCount = 0;
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(ToolWindow).ToString())
                return tools;
            else if (persistString == typeof(Form备件入库).ToString())
                return beiJian;
            else if (persistString == typeof(Form备件出库).ToString())
                return chuku;
            else if (persistString == typeof(Form备件信息).ToString())
                return BeiJianXinXi;
            else if (persistString == typeof(Form库存查询).ToString())
                return KuCunChaXun;
            else
                return null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        //缩小到托盘中，不退出
        bool m_bSaveLayout=true;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dock位置保存
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (m_bSaveLayout)
                dockPanel1.SaveAsXml(configFile);
            else if (File.Exists(configFile))
                File.Delete(configFile);
            //
            //如果我们操作【×】按钮，那么不关闭程序而是缩小化到托盘，并提示用户.
            if (this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;//不关闭程序

                //最小化到托盘的时候显示图标提示信息，提示用户并未关闭程序
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示",
                     "图标已经缩小到托盘，打开窗口请双击图标即可。也可以\n使用Alt+S键来显示/隐藏窗体。",
                     ToolTipIcon.Info);
            }
        }
        
        CCalendar cal = new CCalendar();  
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel当前时间.Text = DateTime.Now.ToLongTimeString();
            if (_globalDayCount >= 1) //7200
            { _globalDayCount = 0; this.toolStripStatusLabel日历.Text = cal.GetDateInfo(System.DateTime.Now).Fullinfo; } else { _globalDayCount++; }
        }

        #region 窗口操作
        private DockContent FindDocument(string text)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    if (form.Text == text)
                    {
                        return form as DockContent;
                    }
                }

                return null;
            }
            else
            {
                foreach (DockContent content in dockPanel1.Documents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        return content;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 工具栏调用接口-显示窗口
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="formType"></param>
        /// <returns></returns>
        public DockContent ShowContent(string caption, Type formType)
        {
            DockContent frm = FindDocument(caption);
            if (frm == null)
            {
                frm = Activator.CreateInstance(formType) as DockContent;
                //frm = ChildWinManagement.LoadMdiForm(Portal.gc.MainDialog, formType) as DockContent;
                if (frm == null)
                {
                    LogHelper.Error(string.Format("业务窗体需要继承WeifenLuo.WinFormsUI.Docking.DockContent窗体，窗体信息：{0} {1}"
                            , caption, formType.ToString()));
                    return null;
                }
                frm.DockHandler.TabText = caption;
                frm.Show(this.dockPanel1);
                //frm.BringToFront();
            }
            else {
                frm.Show(this.dockPanel1);
                frm.BringToFront();
            }
            return frm;
        }

        public void CloseCurrentDocument()
        {
            dockPanel1.ActiveContent.DockHandler.Close();
        }
        public void CloseAllDocuments()
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
            }
            else
            {
                IDockContent[] documents = dockPanel1.DocumentsToArray();
                foreach (IDockContent content in documents)
                {
                    content.DockHandler.Close();
                }
            }
        }
        public void CloseOtherDocuments()
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    //if (dockPanel1.)
                    if (form == form.ActiveMdiChild) continue;
                    else form.Close();
                }
            }
            else
            {
                IDockContent[] documents = dockPanel1.DocumentsToArray();
                foreach (IDockContent content in documents)
                {
                    if (content == dockPanel1.ActiveContent) continue;
                    else content.DockHandler.Close();
                }
            }
        }
        #endregion



        #region 工具栏按钮事件

        private void toolStripButton导航条_Click(object sender, EventArgs e)
        {
            if (tools.Visible) tools.Hide();
            else tools.Show();
        }

        private void toolStripButton备件入库_Click(object sender, EventArgs e)
        {
            if (beiJian == null || beiJian.IsDisposed == true) { beiJian = new Form备件入库(); beiJian.Show(dockPanel1); }
            else beiJian.Show(dockPanel1);
        }

        private void toolStripButton备件出库_Click(object sender, EventArgs e)
        {
            if (chuku == null || chuku.IsDisposed == true) { chuku = new Form备件出库(); chuku.Show(dockPanel1); }
            else chuku.Show(dockPanel1);
        }

        private void toolStripButton库存查询_Click(object sender, EventArgs e)
        {
            if (KuCunChaXun == null || KuCunChaXun.IsDisposed == true) { KuCunChaXun = new Form库存查询(); KuCunChaXun.Show(dockPanel1); }
            else KuCunChaXun.Show(dockPanel1);
        }

        private void toolStripButton数据字典_Click(object sender, EventArgs e)
        {
            Form数据字典 ZiDianGuanLi = new Form数据字典(); 
            FormAnimator animator = new FormAnimator(ZiDianGuanLi, FormAnimator.AnimationMethod.Centre,
            FormAnimator.AnimationDirection.Left, 500);   
            ZiDianGuanLi.ShowDialog();
        }

        private void toolStripButton业务报表_Click(object sender, EventArgs e)
        {
            Form业务报表 fm = new Form业务报表();
            fm.ShowDialog();
        }

        private void toolStripButton备件信息_Click(object sender, EventArgs e)
        {
            if (BeiJianXinXi == null || BeiJianXinXi.IsDisposed == true) { BeiJianXinXi = new Form备件信息(); BeiJianXinXi.Show(dockPanel1); }
            else BeiJianXinXi.Show(dockPanel1);
        }

        private void toolStripButton退出系统_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageUtil.ShowYesNoAndTips("确定退出本系统?");
            if (res == DialogResult.Yes)
            {
                this.ShowInTaskbar = false;
                Application.Exit();
            }
        }
        #endregion
        #region 主菜单操作
        private void 关闭所有窗口AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }


        private void 除此之外全部关闭OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                    {
                        form.Close();
                    }
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel1.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                    {
                        document.DockHandler.Close();
                    }
                }
            }
        }

        private void 刷新所有窗口RToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 数据字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton数据字典_Click(sender, e);
        }

        #endregion

        #region 右键菜单事件
        private void toolStripMenuItem关闭当前窗口_Click(object sender, EventArgs e)
        {
            CloseCurrentDocument();
        }

        private void toolStripMenuItem关闭其它窗口_Click(object sender, EventArgs e)
        {
            CloseOtherDocuments();
        }

        private void toolStripMenuItem关闭所有窗口_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }
        #endregion


        private RegisterHotKeyHelper hotKey_ShowOrHideForm = new RegisterHotKeyHelper();
        private void SetHotKey()
        {
            hotKey_ShowOrHideForm.Keys = Keys.W;
            hotKey_ShowOrHideForm.ModKey = RegisterHotKeyHelper.MODKEY.MOD_ALT;
            hotKey_ShowOrHideForm.WindowHandle = this.Handle;
            hotKey_ShowOrHideForm.WParam = 10001;
            hotKey_ShowOrHideForm.HotKey += new RegisterHotKeyHelper.HotKeyPass(hotKey_ShowOrHideForm_HotKey);
            hotKey_ShowOrHideForm.StarHotKey();
        }
        void hotKey_ShowOrHideForm_HotKey()
        {
            显示隐藏主界面ToolStripMenuItem_Click(null,null);
        }  


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            显示隐藏主界面ToolStripMenuItem_Click(sender, e);
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (this == null)
            {
                return;
            }

            //最小化到托盘的时候显示图标提示信息
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示",
                    "图标已经缩小到托盘，打开窗口请双击图标即可。也可以\n使用Alt+S键来显示/隐藏窗体。",
                    ToolTipIcon.Info);
            }
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox(); ab.ShowDialog();
        }

        private void 显示隐藏主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                this.BringToFront();
                this.Activate();
                this.Focus();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = false;
                //Portal.gc.Quit();
                Application.Exit();
            }
            catch
            {
                // Nothing to do.
            }
        }

        private void MainForm_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox(); ab.ShowDialog(); 
        }








    }
}
