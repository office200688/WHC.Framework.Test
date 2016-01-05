using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using TMIS.Entity;

namespace TMIS.IDAL
{
	/// <summary>
	/// ICustomer 的摘要说明。
	/// </summary>
	public interface ICustomer : IBaseDAL<CustomerInfo>
	{
        /// <summary>
        /// 获取所有的客户编号
        /// </summary>
        /// <returns></returns>
        List<string> GetAllCustomerNumber();

        /// <summary>
        /// 根据客户编号获取客户信息
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        CustomerInfo GetByCustomerNumber(string number);
    }
}