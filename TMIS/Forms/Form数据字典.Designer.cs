namespace TMIS.Forms
{
    partial class Form数据字典
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("客户状态");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("市场分区");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("客户类型");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("客户级别");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("客户行业");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("客户来源");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("客户阶段");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("信用等级");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("重要级别");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("对公司任何程度");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("客户关系管理", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("产品类型");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("产品型号");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("产品规格");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("产品颜色");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("产品尺寸");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("产品标准单位");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("产品及销售管理", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("备件属类");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("备件类别");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("使用位置");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("仓库管理字典", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("政治面貌");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("民族");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("职务");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("学历");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("职称");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("科研情况分类");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("人员信息字典", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("赞助商");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("论坛数据字典", new System.Windows.Forms.TreeNode[] {
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("选择处理人");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("增加流程环节");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("表单状态");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("处理人信息");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("通知方式");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("处理类型");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("工作流字典管理", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form数据字典));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label字典大类 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.winGridViewPager1 = new WHC.Pager.WinControl.WinGridViewPager();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点8";
            treeNode1.Text = "客户状态";
            treeNode2.Name = "节点11";
            treeNode2.Text = "市场分区";
            treeNode3.Name = "节点13";
            treeNode3.Text = "客户类型";
            treeNode4.Name = "节点14";
            treeNode4.Text = "客户级别";
            treeNode5.Name = "节点15";
            treeNode5.Text = "客户行业";
            treeNode6.Name = "节点16";
            treeNode6.Text = "客户来源";
            treeNode7.Name = "节点17";
            treeNode7.Text = "客户阶段";
            treeNode8.Name = "节点18";
            treeNode8.Text = "信用等级";
            treeNode9.Name = "节点19";
            treeNode9.Text = "重要级别";
            treeNode10.Name = "节点20";
            treeNode10.Text = "对公司任何程度";
            treeNode11.Name = "节点0";
            treeNode11.Text = "客户关系管理";
            treeNode12.Name = "节点0";
            treeNode12.Text = "产品类型";
            treeNode13.Name = "节点1";
            treeNode13.Text = "产品型号";
            treeNode14.Name = "节点2";
            treeNode14.Text = "产品规格";
            treeNode15.Name = "节点3";
            treeNode15.Text = "产品颜色";
            treeNode16.Name = "节点4";
            treeNode16.Text = "产品尺寸";
            treeNode17.Name = "节点5";
            treeNode17.Text = "产品标准单位";
            treeNode18.Name = "节点1";
            treeNode18.Text = "产品及销售管理";
            treeNode19.Name = "节点6";
            treeNode19.Text = "备件属类";
            treeNode20.Name = "节点7";
            treeNode20.Text = "备件类别";
            treeNode21.Name = "节点8";
            treeNode21.Text = "使用位置";
            treeNode22.Name = "节点2";
            treeNode22.Text = "仓库管理字典";
            treeNode23.Name = "节点10";
            treeNode23.Text = "政治面貌";
            treeNode24.Name = "节点17";
            treeNode24.Text = "民族";
            treeNode25.Name = "节点18";
            treeNode25.Text = "职务";
            treeNode26.Name = "节点19";
            treeNode26.Text = "学历";
            treeNode27.Name = "节点20";
            treeNode27.Text = "职称";
            treeNode28.Name = "节点21";
            treeNode28.Text = "科研情况分类";
            treeNode29.Name = "节点4";
            treeNode29.Text = "人员信息字典";
            treeNode30.Name = "节点9";
            treeNode30.Text = "赞助商";
            treeNode31.Name = "节点3";
            treeNode31.Text = "论坛数据字典";
            treeNode32.Name = "节点11";
            treeNode32.Text = "选择处理人";
            treeNode33.Name = "节点12";
            treeNode33.Text = "增加流程环节";
            treeNode34.Name = "节点13";
            treeNode34.Text = "表单状态";
            treeNode35.Name = "节点14";
            treeNode35.Text = "处理人信息";
            treeNode36.Name = "节点15";
            treeNode36.Text = "通知方式";
            treeNode37.Name = "节点16";
            treeNode37.Text = "处理类型";
            treeNode38.Name = "节点5";
            treeNode38.Text = "工作流字典管理";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode18,
            treeNode22,
            treeNode29,
            treeNode31,
            treeNode38});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(231, 500);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "diamond.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label字典大类);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(237, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(591, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(510, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "编辑";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "添加";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "批量添加";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label字典大类
            // 
            this.label字典大类.AutoSize = true;
            this.label字典大类.Location = new System.Drawing.Point(154, 30);
            this.label字典大类.Name = "label字典大类";
            this.label字典大类.Size = new System.Drawing.Size(35, 12);
            this.label字典大类.TabIndex = 1;
            this.label字典大类.Text = "-----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "您选择的字典大类：";
            // 
            // winGridViewPager1
            // 
            this.winGridViewPager1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGridViewPager1.AppendedMenu = null;
            this.winGridViewPager1.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("winGridViewPager1.ColumnNameAlias")));
            this.winGridViewPager1.DataSource = null;
            this.winGridViewPager1.DisplayColumns = "";
            this.winGridViewPager1.Location = new System.Drawing.Point(237, 90);
            this.winGridViewPager1.MinimumSize = new System.Drawing.Size(540, 0);
            this.winGridViewPager1.Name = "winGridViewPager1";
            this.winGridViewPager1.PrintTitle = "";
            this.winGridViewPager1.ShowAddMenu = true;
            this.winGridViewPager1.ShowCheckBox = false;
            this.winGridViewPager1.ShowDeleteMenu = true;
            this.winGridViewPager1.ShowEditMenu = true;
            this.winGridViewPager1.ShowExportButton = true;
            this.winGridViewPager1.Size = new System.Drawing.Size(685, 398);
            this.winGridViewPager1.TabIndex = 2;
            // 
            // Form数据字典
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 500);
            this.Controls.Add(this.winGridViewPager1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form数据字典";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据字典";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label字典大类;
        private System.Windows.Forms.Label label1;
        private WHC.Pager.WinControl.WinGridViewPager winGridViewPager1;
        private System.Windows.Forms.ImageList imageList1;
    }
}