using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using TMIS.Entity;
using TMIS.IDAL;
using WHC.Pager.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace TMIS.DAL
{
    public class TB_PurchaseDetail : BaseDAL<TB_PurchaseDetailInfo>, ITB_PurchaseDetail
    {
        #region 对象实例及构造函数

        public static TB_PurchaseDetail Instance
		{
			get
			{
                return new TB_PurchaseDetail();
			}
		}
        public TB_PurchaseDetail()
            : base("TB_PurchaseDetail", "ID")
		{
		}

		#endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override TB_PurchaseDetailInfo DataReaderToEntity(IDataReader dataReader)
        {
            TB_PurchaseDetailInfo purchaseDetailInfo = new TB_PurchaseDetailInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            purchaseDetailInfo.ID = reader.GetInt32("ID");
            purchaseDetailInfo.PurchaseHead_ID = reader.GetInt32("PurchaseHead_ID");
            purchaseDetailInfo.OperationType = reader.GetString("OperationType");
            purchaseDetailInfo.ItemNo = reader.GetString("ItemNo");
            purchaseDetailInfo.ItemName = reader.GetString("ItemName");
            purchaseDetailInfo.MapNo = reader.GetString("MapNo");
            purchaseDetailInfo.Specification = reader.GetString("Specification");
            purchaseDetailInfo.Material = reader.GetString("Material");
            purchaseDetailInfo.ItemBigType = reader.GetString("ItemBigType");
            purchaseDetailInfo.c = reader.GetString("c");
            purchaseDetailInfo.Unit = reader.GetString("Unit");
            purchaseDetailInfo.Price = reader.GetDecimal("Price");
            purchaseDetailInfo.Quantity = reader.GetFloat("Quantity");
            purchaseDetailInfo.Amount = reader.GetDecimal("Amount");
            purchaseDetailInfo.Source = reader.GetString("Source");
            purchaseDetailInfo.StoragePos = reader.GetString("StoragePos");
            purchaseDetailInfo.UsagePos = reader.GetString("UsagePos");
            purchaseDetailInfo.WareHouse = reader.GetString("WareHouse");
            purchaseDetailInfo.Dept = reader.GetString("Dept");

            return purchaseDetailInfo;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(TB_PurchaseDetailInfo obj)
        {
            TB_PurchaseDetailInfo info = obj as TB_PurchaseDetailInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("PurchaseHead_ID", info.PurchaseHead_ID);
            hash.Add("OperationType", info.OperationType);
            hash.Add("ItemNo", info.ItemNo);
            hash.Add("ItemName", info.ItemName);
            hash.Add("MapNo", info.MapNo);
            hash.Add("Specification", info.Specification);
            hash.Add("Material", info.Material);
            hash.Add("ItemBigType", info.ItemBigType);
            hash.Add("c", info.c);
            hash.Add("Unit", info.Unit);
            hash.Add("Price", info.Price);
            hash.Add("Quantity", info.Quantity);
            hash.Add("Amount", info.Amount);
            hash.Add("Source", info.Source);
            hash.Add("StoragePos", info.StoragePos);
            hash.Add("UsagePos", info.UsagePos);
            hash.Add("WareHouse", info.WareHouse);
            hash.Add("Dept", info.Dept);
            return hash;
        }


        #region ITB_PurchaseDetail 成员

        public List<string> GetAllTB_PurchaseDetailItemNo()
        {
            string sql = string.Format("Select ItemNo From dbo.{0}", tableName);

            List<string> list = new List<string>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);

            string itemNum = string.Empty;
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    itemNum = dr["ItemNo"].ToString();
                    if (!string.IsNullOrEmpty(itemNum))
                    {
                        list.Add(itemNum);
                    }
                }
            }
            return list;
        }

        public TB_PurchaseDetailInfo GetByTB_PurchaseDetailItemNo(string itemNum)
        {
            string condition = string.Format("ItemNo = '{0}'", itemNum);
            List<TB_PurchaseDetailInfo> list = base.Find(condition);
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
