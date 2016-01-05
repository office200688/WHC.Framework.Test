using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using TMIS.Entity;
using TMIS.IDAL;

namespace TMIS.DAL
{
	/// <summary>
	/// Customer 的摘要说明。
	/// </summary>
	public class Customer : BaseDAL<CustomerInfo>, ICustomer
	{
		#region 对象实例及构造函数

		public static Customer Instance
		{
			get
			{
				return new Customer();
			}
		}
		public Customer() : base("All_Customer","ID")
		{
		}

		#endregion
		
		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override CustomerInfo DataReaderToEntity(IDataReader dataReader)
		{
			CustomerInfo customerInfo = new CustomerInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			customerInfo.ID = reader.GetString("ID");
			customerInfo.Number = reader.GetString("Number");
			customerInfo.Name = reader.GetString("Name");
			customerInfo.Type = reader.GetString("Type");
			customerInfo.Area = reader.GetString("Area");
			customerInfo.Company = reader.GetString("Company");
			customerInfo.Address = reader.GetString("Address");
			customerInfo.Telephone1 = reader.GetString("Telephone1");
			customerInfo.Telephone2 = reader.GetString("Telephone2");
			customerInfo.Telephone3 = reader.GetString("Telephone3");
			customerInfo.Telephone4 = reader.GetString("Telephone4");
			customerInfo.Telephone5 = reader.GetString("Telephone5");
			customerInfo.CreateDate = reader.GetDateTime("CreateDate");
			customerInfo.Shop_ID = reader.GetString("Shop_ID");
			customerInfo.Note = reader.GetString("Note");
			customerInfo.LastUpdated = reader.GetDateTime("LastUpdated");
			
			return customerInfo;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(CustomerInfo obj)
		{
		    CustomerInfo info = obj as CustomerInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
			hash.Add("Number", info.Number);
			hash.Add("Name", info.Name);
			hash.Add("Type", info.Type);
			hash.Add("Area", info.Area);
			hash.Add("Company", info.Company);
			hash.Add("Address", info.Address);
			hash.Add("Telephone1", info.Telephone1);
			hash.Add("Telephone2", info.Telephone2);
			hash.Add("Telephone3", info.Telephone3);
			hash.Add("Telephone4", info.Telephone4);
			hash.Add("Telephone5", info.Telephone5);
			hash.Add("CreateDate", info.CreateDate);
			hash.Add("Shop_ID", info.Shop_ID);
			hash.Add("Note", info.Note);
			hash.Add("LastUpdated", info.LastUpdated);
				
			return hash;
		}


        #region ICustomer 成员

        public List<string> GetAllCustomerNumber()
        {
            string sql = string.Format("Select Number From dbo.{0}", tableName);

            List<string> list = new List<string>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);

            string number = string.Empty;
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    number = dr["Number"].ToString();
                    if (!string.IsNullOrEmpty(number))
                    {
                        list.Add(number);
                    }
                }
            }
            return list;
        }

        public CustomerInfo GetByCustomerNumber(string number)
        {
            string condition = string.Format("Number = '{0}'", number);
            List<CustomerInfo> list = base.Find(condition);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}