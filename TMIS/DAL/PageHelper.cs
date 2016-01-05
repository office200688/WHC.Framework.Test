using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace TMIS.DAL
{
	/// <summary> 
	/// 分页类PagerHelper 的摘要说明。 
	/// </summary> 
	public class PagerHelper
	{
		#region 成员变量

		private string tableName;//表名
		private bool isDoCount = false;//是否只返回总记录数
		private string fieldsToReturn = "*";//需要返回的列
		private string fieldNameToSort = string.Empty;//排序字段名称
		private int pageSize = 10;//页尺寸,就是一页显示多少条记录
		private int pageIndex = 1;//当前的页码
		private bool isDescending = false;//是否以降序排列
		private string strwhere = string.Empty;//检索条件(注意: 不要加 where)

		#endregion

		#region 属性对象

		/// <summary>
		/// 表名
		/// </summary>
		public string TableName
		{
			get { return tableName; }
			set { tableName = value; }
		}

		/// <summary>
		/// 需要返回的列
		/// </summary>
		public string FieldsToReturn
		{
			get { return fieldsToReturn; }
			set { fieldsToReturn = value; }
		}

		/// <summary>
		/// 排序字段名称
		/// </summary>
		public string FieldNameToSort
		{
			get { return fieldNameToSort; }
			set { fieldNameToSort = value; }
		}

		/// <summary>
		/// 页尺寸,就是一页显示多少条记录
		/// </summary>
		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value; }
		}

		/// <summary>
		/// 当前的页码
		/// </summary>
		public int PageIndex
		{
			get { return pageIndex; }
			set { pageIndex = value; }
		}

		/// <summary>
		/// 是否只返回总记录数
		/// </summary>
		public bool IsDoCount
		{
			get { return isDoCount; }
			set { isDoCount = value; }
		}

		/// <summary>
		/// 是否以降序排列结果
		/// </summary>
		public bool IsDescending
		{
			get { return isDescending; }
			set { isDescending = value; }
		}

		/// <summary>
		/// 检索条件(注意: 不要加 where)
		/// </summary>
		public string StrWhere
		{
			get { return strwhere; }
			set { strwhere = value; }
		}

		#endregion

		#region 构造函数

		
		/// <summary> 
		/// 得到记录总数的构造函数 
		/// </summary> 
		/// <param name="tableName">表名</param> 
		/// <param name="strwhere">检索条件</param> 
		public PagerHelper(string tableName, string strwhere)
		{
			this.tableName = tableName;
			this.isDoCount = true;

			this.strwhere = strwhere;
		}

		/// <summary>
		/// 用于返回所有记录数据或者所有记录总数的构造函数
		/// </summary>
		/// <param name="tableName">表名</param>
		/// <param name="isDoCount">是否只返回总记录数</param>
		/// <param name="fieldNameToSort">排序字段名称</param>
		/// <param name="connectionString">连接字符串</param>
		public PagerHelper(string tableName, bool isDoCount, string fieldNameToSort)
		{
			this.tableName = tableName;
			this.isDoCount = isDoCount;

			this.fieldNameToSort = fieldNameToSort;
		}

		/// <summary>
		/// 完整的构造函数,可以包含条件,返回记录字段等条件
		/// </summary>
		/// <param name="tableName">表名</param>
		/// <param name="isDoCount">是否只返回总记录数</param>
		/// <param name="fieldsToReturn">需要返回的列</param>
		/// <param name="fieldNameToSort">排序字段名称</param>
		/// <param name="pageSize">页尺寸</param>
		/// <param name="pageIndex">当前的页码</param>
		/// <param name="isDescending">是否以降序排列</param>
		/// <param name="strwhere">检索条件</param>
		/// <param name="connectionString">连接字符串</param>
		public PagerHelper(string tableName, bool isDoCount, string fieldsToReturn, string fieldNameToSort, 
			int pageSize, int pageIndex, bool isDescending, string strwhere)
		{
			this.tableName = tableName;
			this.isDoCount = isDoCount;

			this.fieldsToReturn = fieldsToReturn;
			this.fieldNameToSort = fieldNameToSort;
			this.pageSize = pageSize;
			this.pageIndex = pageIndex;
			this.isDescending = isDescending;

			this.strwhere = strwhere;
		}

		#endregion

		public IDataReader GetDataReader()
		{
			if (this.isDoCount)
			{
				throw new ArgumentException("要返回记录集，DoCount属性一定为false");
			}

            string sql = PrepareSql();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand comand = db.GetSqlStringCommand(sql);
            return db.ExecuteReader(comand);
		}

		public DataSet GetDataSet()
		{
			if (this.isDoCount)
			{
				throw new ArgumentException("要返回记录集，DoCount属性一定为false");
			}

            string sql = PrepareSql();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand comand = db.GetSqlStringCommand(sql);
            return db.ExecuteDataSet(comand);
		}

		public int GetCount()
		{
			if (!this.isDoCount)
			{
				throw new ArgumentException("要返回总数统计，DoCount属性一定为true");
			}

            string sql = PrepareSql();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand comand = db.GetSqlStringCommand(sql);
            return (int)db.ExecuteScalar(comand);
		}

        /// <summary>
        /// 不依赖于存储过程的分页
        /// </summary>
        /// <returns></returns>
        private string PrepareSql()
        {
            string sql = "";
            if (this.isDoCount)//执行总数统计
            {
                sql = string.Format("select count(*) as Total from [{0}] ", this.tableName);
                if (!string.IsNullOrEmpty(this.strwhere))
                {
                    sql += string.Format("Where {0} ", this.strwhere);
                }
            }
            else
            {
                string strTemp = string.Empty;
                string strOrder = string.Empty;
                if (this.isDescending)
                {
                    strTemp = "<(select min";
                    strOrder = string.Format(" order by [{0}] desc", this.fieldNameToSort);
                }
                else
                {
                    strTemp = ">(select max";
                    strOrder = string.Format(" order by [{0}] asc", this.fieldNameToSort);
                }

                sql = string.Format("select top {0} {1} from [{2}] ", this.pageSize, this.fieldsToReturn, this.tableName);
                
                //如果是第一页就执行以上代码，这样会加快执行速度
                if (this.pageIndex == 1)
                {
                    if (!string.IsNullOrEmpty(this.strwhere))
                    {
                        sql += string.Format(" Where {0} ", this.strwhere);
                    }
                    sql += strOrder;
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.strwhere))
                    {
                        sql += string.Format(" Where [{0}] {1} ([{0}]) from (select top {2} [{0}] from [{3}] where {5} {4} ) as tblTmp) and {5} {4}",
                            this.fieldNameToSort, strTemp, (this.pageIndex - 1) * this.pageSize, this.tableName, strOrder, this.strwhere);
                    }
                    else
                    {
                        sql += string.Format(" Where [{0}] {1} ([{0}]) from (select top {2} [{0}] from [{3}] {4} ) as tblTmp) {4}",
                            this.fieldNameToSort, strTemp, (this.pageIndex - 1) * this.pageSize, this.tableName, strOrder);
                    }
                }
            }

            return sql;
        }
	}
} 
