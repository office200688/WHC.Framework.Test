using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Reflection;

using WHC.Pager.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using TMIS.IDAL;
using TMIS.Entity;
using System.Data.OleDb;
//using TMIS.Commons;
using WHC.Framework.Commons;

namespace TMIS.DAL
{
	/// <summary>
	/// 数据访问层的基类
	/// </summary>
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : BaseEntity, new()
	{
		#region 构造函数

		protected string tableName;//需要初始化的对象表名
		protected string primaryKey;//数据库的主键字段名
        protected string sortField = "PurchaseHead_ID";//排序字段
        private bool isDescending = true;//
        
        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField
        {
            get 
            {
                return sortField; 
            }
            set 
            {
                sortField = value; 
            }
        }

        /// <summary>
        /// 是否为降序
        /// </summary>
        public bool IsDescending
        {
            get { return isDescending; }
            set { isDescending = value; }
        }       

		/// <summary>
		/// 数据库访问对象的表名
		/// </summary>
		public string TableName
		{
			get
			{
				return tableName;
			}
		}

		/// <summary>
		/// 数据库访问对象的外键约束
		/// </summary>
		public string PrimaryKey
		{
			get
			{
				return primaryKey;
			}
		}
		
		public BaseDAL()
		{}

		/// <summary>
		/// 指定表名以及主键,对基类进构造
		/// </summary>
		/// <param name="tableName">表名</param>
		/// <param name="primaryKey">表主键</param>
		public BaseDAL(string tableName, string primaryKey)
		{
			this.tableName = tableName;
			this.primaryKey = primaryKey;
		}

		#endregion

		#region 通用操作方法

		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="recordField">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <param name="trans">事务对象,如果使用事务,传入事务对象,否则为Null不使用事务</param>
		public bool Insert(Hashtable recordField, DbTransaction trans)
		{
			return this.Insert(recordField, tableName, trans);
		}

		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="recordField">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <param name="targetTable">需要操作的目标表名称</param>
		/// <param name="trans">事务对象,如果使用事务,传入事务对象,否则为Null不使用事务</param>
        public bool Insert(Hashtable recordField, string targetTable, DbTransaction trans)
		{
			bool result = false;
			string fields = ""; // 字段名
			string vals = ""; // 字段值
			if ( recordField == null || recordField.Count < 1 )
			{
				return result;
			}

            OleDbParameter[] param = new OleDbParameter[recordField.Count];
			IEnumerator eKeys = recordField.Keys.GetEnumerator();

			int i = 0;
			while ( eKeys.MoveNext() )
			{
				string field = eKeys.Current.ToString();
				fields += string.Format("[{0}],",field );//加[]为了去除别名引起的错误
				vals += string.Format("@{0},", field);

				object val = recordField[eKeys.Current.ToString()]; 
                param[i] = new OleDbParameter("@" + field, val);
                if (val is DateTime)
                {
                    param[i].OleDbType = OleDbType.Date;//日期类型特别处理，否则Access数据库访问出错
                }

				i++;
			}

			fields = fields.Trim(',');//除去前后的逗号
			vals = vals.Trim(',');//除去前后的逗号
			string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", targetTable, fields, vals);

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);
            command.Parameters.AddRange(param);

			if ( trans != null )
			{
                result = db.ExecuteNonQuery(command, trans) > 0;
			}
			else
			{
                result = db.ExecuteNonQuery(command) > 0;
			}

			return result;
		}
		
		/// <summary>
		/// 更新某个表一条记录(只适用于用单键,用int类型作键值的表)
		/// </summary>
		/// <param name="id">ID号</param>
		/// <param name="recordField">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <param name="trans">事务对象,如果使用事务,传入事务对象,否则为Null不使用事务</param>
        public bool Update(int id, Hashtable recordField, DbTransaction trans)
		{
			return this.Update(id, recordField, tableName, trans);
		}

		/// <summary>
		/// 更新某个表一条记录(只适用于用单键,用string类型作键值的表)
		/// </summary>
		/// <param name="id">ID号</param>
		/// <param name="recordField">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <param name="trans">事务对象,如果使用事务,传入事务对象,否则为Null不使用事务</param>
        public bool Update(string id, Hashtable recordField, DbTransaction trans)
		{
			return this.Update(id, recordField, tableName, trans);
		}

		/// <summary>
		/// 更新某个表一条记录(只适用于用单键,用int类型作键值的表)
		/// </summary>
		/// <param name="id">ID号</param>
		/// <param name="recordField">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <param name="targetTable">需要操作的目标表名称</param>
		/// <param name="trans">事务对象,如果使用事务,传入事务对象,否则为Null不使用事务</param>
        public bool Update(int id, Hashtable recordField, string targetTable, DbTransaction trans)
		{
			return Update(id, recordField, targetTable, trans);
		}

		/// <summary>
		/// 更新某个表一条记录(只适用于用单键,用string类型作键值的表)
		/// </summary>
		/// <param name="id">ID号</param>
		/// <param name="recordField">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <param name="targetTable">需要操作的目标表名称</param>
		/// <param name="trans">事务对象,如果使用事务,传入事务对象,否则为Null不使用事务</param>
        public bool Update(string id, Hashtable recordField, string targetTable, DbTransaction trans)
		{
			string field = ""; // 字段名
			object val = null; // 值
			string setValue = ""; // 更新Set () 中的语句

			if ( recordField == null || recordField.Count < 1 )
			{
				return false;
			}

            OleDbParameter[] param = new OleDbParameter[recordField.Count];
			int i = 0;

			IEnumerator eKeys = recordField.Keys.GetEnumerator();
			while ( eKeys.MoveNext() )
			{
				field = eKeys.Current.ToString();
				val = recordField[eKeys.Current.ToString()];
				setValue += string.Format("[{0}] = @{0},", field);//加[ ]用来避免关键字错误
                param[i] = new OleDbParameter(string.Format("@{0}", field), val);
                
                if (val is DateTime)
                {
                    param[i].OleDbType = OleDbType.Date;//日期类型特别处理，否则Access数据库访问出错
                }                

				i++;
			}

			string sql = string.Format("UPDATE {0} SET {1} WHERE {2} = '{3}' ", targetTable, setValue.Substring(0, setValue.Length - 1), primaryKey, id);
            LogHelper.Debug(sql);
            
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);
            command.Parameters.AddRange(param);

            bool result = false;
			if (trans != null)
			{
                result = db.ExecuteNonQuery(command, trans) > 0;
			}
			else
			{
                result = db.ExecuteNonQuery(command) > 0;
			}

            return result;
		}

		#endregion

		#region 对象添加、修改、查询接口

		/// <summary>
		/// 插入指定对象到数据库中
		/// </summary>
		/// <param name="obj">指定的对象</param>
		/// <returns>执行成功返回新增记录的自增长ID。</returns>
        public bool Insert(T obj)
		{
			ArgumentValidation.CheckForNullReference(obj, "传入的对象obj为空");
		    
			Hashtable hash = GetHashByEntity(obj);
			return Insert(hash, null);
		}
		
		/// <summary>
		/// 更新对象属性到数据库中
		/// </summary>
		/// <param name="obj">指定的对象</param>
		/// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public bool Update(T obj, string primaryKeyValue)
		{
			ArgumentValidation.CheckForNullReference(obj, "传入的对象obj为空");
		
			Hashtable hash = GetHashByEntity(obj);
            return Update(primaryKeyValue, hash, null);
		}
		
		/// <summary>
		/// 查询数据库,检查是否存在指定ID的对象(用于整型主键)
		/// </summary>
		/// <param name="key">对象的ID值</param>
		/// <returns>存在则返回指定的对象,否则返回Null</returns>
        public T FindByID(int key)
		{			
			return FindByID(key.ToString());
		}		
		
		/// <summary>
		/// 查询数据库,检查是否存在指定ID的对象(用于字符型主键)
		/// </summary>
		/// <param name="key">对象的ID值</param>
		/// <returns>存在则返回指定的对象,否则返回Null</returns>
        public T FindByID(string key)
		{
			string sql = string.Format("Select * From {0} Where ({1} = @ID)", tableName, primaryKey);

            OleDbParameter param = new OleDbParameter("@ID", key);

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);
            command.Parameters.Add(param);

			T entity = null;
			using (IDataReader dr = db.ExecuteReader(command))
			{
				if (dr.Read())
				{
					entity = DataReaderToEntity(dr);
				}
			}
			return entity;
		}


		#endregion

		#region 返回集合的接口
		
		/// <summary>
		/// 根据ID字符串(逗号分隔)获取对象列表
		/// </summary>
		/// <param name="idString">ID字符串(逗号分隔)</param>
		/// <returns>符合条件的对象列表</returns>
        public List<T> FindByIDs(string idString)
		{
			string condition = string.Format("{0} in({1})", primaryKey, idString);
			return this.Find(condition);
		}		
		
		/// <summary>
		/// 根据条件查询数据库,并返回对象集合
		/// </summary>
		/// <param name="condition">查询的条件</param>
		/// <returns>指定对象的集合</returns>
        public List<T> Find(string condition)
		{
			//串连条件语句为一个完整的Sql语句
			string sql = string.Format("Select * From {0} Where ", tableName);
			sql +=  condition;
            sql += string.Format(" Order by {0} {1}", sortField, isDescending ? "DESC" : "ASC"); 

			T entity = null;
            List<T> list = new List<T>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);

			using (IDataReader dr = db.ExecuteReader(command))
			{
				while (dr.Read())
				{
					entity = DataReaderToEntity(dr);

					list.Add(entity);
				}
			}
			return list;
		}
		
		/// <summary>
		/// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
		/// </summary>
		/// <param name="condition">查询的条件</param>
		/// <param name="info">分页实体</param>
		/// <returns>指定对象的集合</returns>
        public List<T> Find(string condition, PagerInfo info)
		{
            List<T> list = new List<T>();

            Database db = DatabaseFactory.CreateDatabase();

			PagerHelper helper = new PagerHelper(tableName, condition);
			info.RecordCount = helper.GetCount();

			PagerHelper helper2 = new PagerHelper(tableName, false, " * ", sortField,
				info.PageSize, info.CurrenetPageIndex, true, condition);

			using (IDataReader dr = helper2.GetDataReader())
			{
				while (dr.Read())
				{
					list.Add(this.DataReaderToEntity(dr));
				}
			}
			return list;
		}

		/// <summary>
		/// 返回数据库所有的对象集合
		/// </summary>
		/// <returns>指定对象的集合</returns>
        public List<T> GetAll()
		{
			string sql = string.Format("Select * From {0}", tableName);
            sql += string.Format(" Order by {0} {1}", sortField, isDescending ? "DESC" : "ASC"); 

			T entity = null;
            List<T> list = new List<T>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);

			using (IDataReader dr = db.ExecuteReader(command))
			{
				while (dr.Read())
				{
					entity = DataReaderToEntity(dr);

					list.Add(entity);
				}
			}
			return list;
		}
		
		/// <summary>
		/// 返回数据库所有的对象集合(用于分页数据显示)
		/// </summary>
		/// <param name="info">分页实体信息</param>
		/// <returns>指定对象的集合</returns>
        public List<T> GetAll(PagerInfo info)
		{
            List<T> list = new  List<T>();
			string condition = "";

            Database db = DatabaseFactory.CreateDatabase();

			PagerHelper helper = new PagerHelper(tableName, condition);
			info.RecordCount = helper.GetCount();

			PagerHelper helper2 = new PagerHelper(tableName, false, " * ", sortField,
				info.PageSize, info.CurrenetPageIndex, true, condition);

			using (IDataReader dr = helper2.GetDataReader())
			{
				while (dr.Read())
				{
					list.Add(this.DataReaderToEntity(dr));
				}
			}
			return list;
		}

        public DataSet GetAllToDataSet(PagerInfo info)
        {
            DataSet ds = new DataSet();
            string condition = "";

            PagerHelper helper = new PagerHelper(tableName, condition);
            info.RecordCount = helper.GetCount();

            PagerHelper helper2 = new PagerHelper(tableName, false, " * ", sortField,
                info.PageSize, info.CurrenetPageIndex, true, condition);

            return helper2.GetDataSet();
        }

        public DataTable GetAllToDataTable()
        {
            string sql = string.Format("Select {0} From {1} ", "*", tableName);
            sql += string.Format(" Order by {0} {1}", sortField, isDescending ? "DESC" : "ASC");
            return GetDataTableBySql(sql);
        }

        public DataTable FindToDataTable(string condition)
        {
            //串连条件语句为一个完整的Sql语句
            string sql = string.Format("Select {0} From {1} Where ", "*", tableName);
            sql += condition;
            sql += string.Format(" Order by {0} {1}", sortField, isDescending ? "DESC" : "ASC");

            return GetDataTableBySql(sql);
        }

        protected DataTable GetDataTableBySql(string sql)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);
            return db.ExecuteDataSet(command).Tables[0];
        }

		#endregion
		
		#region 子类必须实现的函数(用于更新或者插入)

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
        protected virtual T DataReaderToEntity(IDataReader dr)
        {
            T obj = new T();
            PropertyInfo[] pis = obj.GetType().GetProperties();

            foreach (PropertyInfo pi in pis)
            {
                try
                {
                    if (dr[pi.Name].ToString() != "")
                    {
                        pi.SetValue(obj, dr[pi.Name] ?? "", null);
                    }
                }
                catch { }
            }
            return obj;
        }

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected virtual Hashtable GetHashByEntity(T obj)
        {
            Hashtable ht = new Hashtable();
            PropertyInfo[] pis = obj.GetType().GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                //if (pis[i].Name != PrimaryKey)
                {
                    object objValue = pis[i].GetValue(obj, null);
                    objValue = (objValue == null) ? DBNull.Value : objValue;

                    if (!ht.ContainsKey(pis[i].Name))
                    {
                        ht.Add(pis[i].Name, objValue);
                    }
                }
            }
            return ht;
        }

		#endregion
		
		#region IBaseDAL接口

		/// <summary>
		/// 查询数据库,检查是否存在指定键值的对象
		/// </summary>
		/// <param name="recordTable">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        public bool IsExistKey(Hashtable recordTable)
		{
            OleDbParameter[] param = new OleDbParameter[recordTable.Count];
			IEnumerator eKeys = recordTable.Keys.GetEnumerator();

			string fields = "";// 字段名
			int i = 0;

			while (eKeys.MoveNext())
			{
				string field = eKeys.Current.ToString();
				fields += string.Format(" {0} = @{1} AND", field, field);

				string val = recordTable[eKeys.Current.ToString()].ToString();
                param[i] = new OleDbParameter(string.Format("@{0}", field), val); 

				i++;
			}

			fields = fields.Substring(0, fields.Length - 3);//除去最后的AND
			string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}", tableName, fields);

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);
            command.Parameters.AddRange(param);

			return (int)db.ExecuteScalar(command) > 0;
		}
		
		/// <summary>
		/// 查询数据库,检查是否存在指定键值的对象
		/// </summary>
		/// <param name="fieldName">指定的属性名</param>
		/// <param name="key">指定的值</param>
		/// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        public bool IsExistKey(string fieldName, object key)
		{
			Hashtable table = new Hashtable();
			table.Add(fieldName, key);

			return IsExistKey(table);
		}						
		
		/// <summary>
		/// 获取数据库中该对象的最大ID值
		/// </summary>
		/// <returns>最大ID值</returns>
        public int GetMaxID()
		{
			string sql = string.Format("SELECT MAX({0}) AS MaxID FROM {1}", primaryKey, tableName);

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);

			object obj = db.ExecuteScalar(command);
			if(Convert.IsDBNull(obj))
			{
				return 0;//没有记录的时候为0
			}
			return Convert.ToInt32(obj);
		}
		
		/// <summary>
		/// 根据指定对象的ID,从数据库中删除指定对象(用于整型主键)
		/// </summary>
		/// <param name="key">指定对象的ID</param>
		/// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public bool DeleteByKey(string key)
		{
			string condition = string.Format("{0} = '{1}'", primaryKey, key);
			return DeleteByCondition(condition);
		}				
		
		/// <summary>
		/// 根据指定条件,从数据库中删除指定对象
		/// </summary>
		/// <param name="condition">删除记录的条件语句</param>
		/// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public bool DeleteByCondition(string condition)
		{
			string sql = string.Format("DELETE FROM {0} WHERE {1} ", tableName, condition);

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);

            return db.ExecuteNonQuery(command) > 0;
		}
        		
		#endregion
	}
}