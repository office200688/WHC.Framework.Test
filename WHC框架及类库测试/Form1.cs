using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WHC框架及类库测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showToolStripMenuItem_Click(sender, e);
        }

        private void Form1_Move(object sender, EventArgs e)
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
                    "图标已经缩小到托盘，打开窗口请双击图标即可。",
                    ToolTipIcon.Info);
            }
        }

        private void Form1_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// 缩小到托盘中，不退出
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //如果我们操作【×】按钮，那么不关闭程序而是缩小化到托盘，并提示用户.
            if (this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;//不关闭程序

                //最小化到托盘的时候显示图标提示信息，提示用户并未关闭程序
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示",
                     "图标已经缩小到托盘，打开窗口请双击图标即可。",
                     ToolTipIcon.Info);
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = false;
                //Portal.gc.Quit();
                this.Close();
            }
            catch
            {
                // Nothing to do.
            }
        }


        /// <summary>
        /// 弹出提示消息窗口
        /// </summary>
        public void Notify(string caption, string content)
        {
            Notify(caption, content, 270, 150, 5000);
        }

        /// <summary>
        /// 弹出提示消息窗口
        /// </summary>
        public void Notify(string caption, string content, int width, int height, int waitTime)
        {
            NotifyWindow notifyWindow = new NotifyWindow(caption, content);
            notifyWindow.TitleClicked += new System.EventHandler(notifyWindowClick);
            notifyWindow.TextClicked += new EventHandler(notifyWindowClick);
            notifyWindow.SetDimensions(width, height);
            notifyWindow.WaitTime = waitTime;
            notifyWindow.Notify();
        }

        private void notifyWindowClick(object sender, EventArgs e)
        {
            //SystemMessageInfo info = BLLFactory<SystemMessage>.Instance.FindLast();
            //if (info != null)
            //{
            //    //FrmEditMessage dlg = new FrmEditMessage();
            //    //dlg.ID = info.ID;
            //    //dlg.ShowDialog();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Notify("这是标题","我是内容");
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else if (e.Button == MouseButtons.Right)
            {
                //if (contextMenuStrip1.Visible == false) { contextMenuStrip1.Show(); } else { contextMenuStrip1.Hide(); }
                //contextMenuStrip1.
                contextMenuStrip1.Show(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(threadShow); th.Start();
        }


        public void threadShow()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (flag)
                {
                    this.Invoke(new startShowDelegate(startShow),"这是子线程显示的弹窗"); flag = false;
                }
                
            }
        }

        delegate void startShowDelegate(string str);
        void startShow(string str)
        {
            Notify("系统消息", str);
        }





        bool flag = false;
        private void button3_Click(object sender, EventArgs e)
        {
            flag = true;
        }

    }
}
