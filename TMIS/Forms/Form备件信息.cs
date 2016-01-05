using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WHC.Framework.Commons;
using WeifenLuo.WinFormsUI.Docking;
using TMIS.BLL;
using System.Data.SqlClient;


namespace TMIS.Forms
{
    public partial class Form备件信息 : DockContent
    {
        public Form备件信息()
        {
            InitializeComponent();
        }

        private void Form备件信息_Load(object sender, EventArgs e)
        {
            //InitArea();
            //InitType();

            //this.winGridViewPager1.ProgressBar = this.toolStripProgressBar1.ProgressBar;
            this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            //this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            //this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;//追加额外菜单项目
            this.winGridViewPager1.ShowLineNumber = true;//显示行号
            this.winGridViewPager1.PagerInfo.PageSize = 30;//页面大小
            this.winGridViewPager1.EventRowBackColor = Color.LightCyan;//间隔颜色
            
            BindData();
        }

        //private const string CONNECTION_STRING = "Server=(local);Database=WareHouse;uid=sa;pwd=Office200688";
#if false
        private void BindData()
        {

            //DataTable dt =new PurchaseDetail().GetPurchaseDetailReportByID(1);
            //winGridViewPager1.dataGridView1.DataSource = dt;
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string sql = "select * from TB_PurchaseDetail";
                SqlCommand command = new SqlCommand(sql, conn);
                //foreach (string key in this.SearchControl1.PagerParameters.Keys)
                //{
                //    command.Parameters.Add(new SqlParameter(key, this.SearchControl1.PagerParameters[key]));
                //}

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "TB_PurchaseDetail");

                this.winGridViewPager1.dataGridView1.DataSource = ds.Tables[0];
            }
        }
#endif
        //private void InitArea()
        //{
        //    this.cmbArea.Items.Clear();
        //    //List<CustomerAreaInfo> areaList = BLLFactory<CustomerArea>.Instance.GetAll();
        //    //foreach (CustomerAreaInfo info in areaList)
        //    //{
        //    //    this.cmbArea.Items.Add(info.Area);
        //    //}
        //}

        //private void InitType()
        //{
        //    this.cmbType.Items.Clear();
        //    //List<CustomerTypeInfo> typeList = BLLFactory<CustomerType>.Instance.GetAll();
        //    //foreach (CustomerTypeInfo info in typeList)
        //    //{
        //    //    this.cmbType.Items.Add(info.CustomerType);
        //    //}
        //}
#if true
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }

        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            DataGridView grid = this.winGridViewPager1.dataGridView1;
            if (grid != null)
            {
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    BLLFactory<TB_PurchaseDetail>.Instance.Delete(row.Cells[0].Value.ToString());
                }
                BindData();
            }
        }

        //private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        //{
        //    DataGridView grid = this.winGridViewPager1.dataGridView1;
        //    if (grid != null)
        //    {
        //        foreach (DataGridViewRow row in grid.SelectedRows)
        //        {
        //            FrmEditCustomer dlg = new FrmEditCustomer();
        //            dlg.ID = row.Cells[0].Value.ToString();
        //            if (DialogResult.OK == dlg.ShowDialog())
        //            {
        //                BindData();
        //            }

        //            break;
        //        }
        //    }
        //}

        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }

        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetSearchSql();
            this.winGridViewPager1.AllToExport = BLLFactory<TB_PurchaseDetail>.Instance.FindToDataTable(where);
        }

        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 根据查询条件构造查询语句
        /// </summary>
        /// <returns></returns>
        private string GetSearchSql()
        {
            SearchCondition condition = new SearchCondition();
            //condition.AddCondition("Number", this.txtNumber.Text, SqlOperator.Like)
            //    .AddCondition("Name", this.txtName.Text, SqlOperator.Like)
            //    .AddCondition("Type", this.cmbType.Text, SqlOperator.Like)
            //    .AddCondition("Area", this.cmbArea.Text, SqlOperator.Like)
            //    .AddCondition("Address", this.txtAddress.Text, SqlOperator.Like)
            //    .AddCondition("Company", this.txtCompany.Text, SqlOperator.Like)
            //    .AddCondition("Note", this.txtNote.Text, SqlOperator.Like)
            //    .AddCondition("Telephone1", this.txtTelephone.Text, SqlOperator.Like, true, "Telephone")
            //    .AddCondition("Telephone2", this.txtTelephone.Text, SqlOperator.Like, true, "Telephone")
            //    .AddCondition("Telephone3", this.txtTelephone.Text, SqlOperator.Like, true, "Telephone")
            //    .AddCondition("Telephone4", this.txtTelephone.Text, SqlOperator.Like, true, "Telephone")
            //    .AddCondition("Telephone5", this.txtTelephone.Text, SqlOperator.Like, true, "Telephone");

            //if (chkUseDate.Checked)
            //{
            //    condition.AddCondition("CreateDate", dateTimePicker1.Value.ToString("yyyy-MM-dd"), SqlOperator.MoreThanOrEqual, true)
            //        .AddCondition("CreateDate", dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd"), SqlOperator.LessThanOrEqual, true);

            //}
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        private void BindData()
        {
            #region 添加别名解析
            //DisplayColumns与显示的字段名或者实体属性一致，大小写不敏感，顺序代表显示顺序，用逗号或者|分开
            this.winGridViewPager1.DisplayColumns = "PurchaseHead_ID,OperationType,ItemNo,ItemName,MapNo,Specification,Material,ItemBigType,c,Unit,Price,Quantity,Amount,Source,StoragePos,UsagePos,WareHouse,Dept";
            this.winGridViewPager1.AddColumnAlias("ID", "编号");
            this.winGridViewPager1.AddColumnAlias("PurchaseHead_ID", "备件编码");
            this.winGridViewPager1.AddColumnAlias("OperationType", "操作类型");
            this.winGridViewPager1.AddColumnAlias("ItemNo", "项目编号");
            this.winGridViewPager1.AddColumnAlias("ItemName", "备件名称");
            this.winGridViewPager1.AddColumnAlias("MapNo", "备件属类");
            this.winGridViewPager1.AddColumnAlias("Specification", "备件类别");
            this.winGridViewPager1.AddColumnAlias("Material", "材质");
            this.winGridViewPager1.AddColumnAlias("ItemBigType", "规格型号");
            this.winGridViewPager1.AddColumnAlias("c", "备注信息");
            this.winGridViewPager1.AddColumnAlias("Unit", "单位");
            this.winGridViewPager1.AddColumnAlias("Price", "单价");
            this.winGridViewPager1.AddColumnAlias("Quantity", "供货商");
            this.winGridViewPager1.AddColumnAlias("Amount", "当前库存");
            this.winGridViewPager1.AddColumnAlias("Source", "来源");
            this.winGridViewPager1.AddColumnAlias("StoragePos", "库位");
            this.winGridViewPager1.AddColumnAlias("UsagePos", "使用位置");
            this.winGridViewPager1.AddColumnAlias("WareHouse", "所属库房");
            this.winGridViewPager1.AddColumnAlias("Dept", "所属部门");

            #endregion

            string where = GetSearchSql();
            this.winGridViewPager1.DataSource = BLLFactory<TB_PurchaseDetail>.Instance.Find(where, this.winGridViewPager1.PagerInfo);
        }
#endif
        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
