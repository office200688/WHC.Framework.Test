using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using TMIS.Entity;
using TMIS.IDAL;
using WHC.Pager.Entity;

namespace TMIS.BLL
{
	public class Customer : BaseBLL<CustomerInfo>
    {
        public Customer()
            : base()
        {
        }

        /// <summary>
        /// 删除用户的资料和财务信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Delete(string key)
        {
            baseDal.DeleteByKey(key);

            //ICustomerTrade tradeDAL = new DALDatabase.CustomerTrade();
            //string condition = string.Format("Customer_ID ='{0}'", key);
            //tradeDAL.DeleteByCondition(condition);

            return true;
        }

        /// <summary>
        /// 获取所有的客户编号
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllCustomerNumber()
        {
            ICustomer customerDAL = baseDal as ICustomer;
            return customerDAL.GetAllCustomerNumber();
        }

        /// <summary>
        /// 根据客户编号获取客户信息
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public CustomerInfo GetByCustomerNumber(string number)
        {
            ICustomer customerDAL = baseDal as ICustomer;
            return customerDAL.GetByCustomerNumber(number);
        }

        /// <summary>
        /// 获取没有订单的客户列表
        /// </summary>
        /// <param name="pagerInfo">如果pagerInfo为空，不返回分页数据，而是全部数据</param>
        /// <returns></returns>
        public List<CustomerInfo> GetNoOrderCustomers(PagerInfo pagerInfo)
        {
            List<CustomerInfo> customerList = new List<CustomerInfo>();

            //IOrder orderDAL = new DALDatabase.Order();
            //List<string> customerNumberList = orderDAL.GetCustomerNumbers();

            //string numberString = string.Empty;
            //foreach (string number in customerNumberList)
            //{
            //    numberString += string.Format("'{0}',", number);
            //}

            //if (!string.IsNullOrEmpty(numberString))
            //{
            //    string condition = string.Format("Number not in({0})", numberString.Trim(','));
            //    ICustomer customerDAL = baseDal as ICustomer;

            //    if (pagerInfo != null)
            //    {
            //        customerList = customerDAL.Find(condition, pagerInfo);
            //    }
            //    else
            //    {
            //        customerList = customerDAL.Find(condition);
            //    }
            //}

            return customerList;
        }

        /// <summary>
        /// 根据分店编码生成客户编号
        /// </summary>
        /// <param name="shopID">分店ID</param>
        /// <returns></returns>
        public string GenerateCustomerNumber(string shopID)
        {
            string shopCode = string.Empty;
            //string condition = string.Format("ID ='{0}'", shopID);
            //IShop shop = new DALDatabase.Shop();
            //List<ShopInfo> shopList = shop.Find(condition);
            //if (shopList.Count > 0)
            //{
            //    shopCode = shopList[0].ShopCode;
            //}

            //condition = string.Format("Shop_ID ='{0}'", shopID);
            //ICustomer dal = baseDal as ICustomer;
            int count = 1;// dal.GetRecordCount(condition) + 1;
                        
            string number = string.Format("{0}{1}", shopCode, count);
            while (true)
            {
                if (CheckCustomerNumberExist(number))
                {
                    number = string.Format("{0}{1}", shopCode, count++);
                }
                else
                {
                    break;
                }
            }

            return number;
        }

        private bool CheckCustomerNumberExist(string customerNumber)
        {
            return base.IsExistKey("Number", customerNumber);
        }
    }
}
