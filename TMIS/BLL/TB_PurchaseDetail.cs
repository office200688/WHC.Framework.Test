using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMIS.Entity;
using TMIS.IDAL;
using WHC.Pager.Entity;

namespace TMIS.BLL
{
    public class TB_PurchaseDetail : BaseBLL<TB_PurchaseDetailInfo>
    {
        public TB_PurchaseDetail()
            : base()
        {
        }
        /// <summary>
        /// 获取所有的P ID
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllItemNo()
        {
            ITB_PurchaseDetail tb_purchasedetailDAL = baseDal as ITB_PurchaseDetail;
            return tb_purchasedetailDAL.GetAllTB_PurchaseDetailItemNo();
        }


        public TB_PurchaseDetailInfo GetByItemNo(string itemNumber)
        {
            ITB_PurchaseDetail tb_purchasedetailDAL = baseDal as ITB_PurchaseDetail;
            return tb_purchasedetailDAL.GetByTB_PurchaseDetailItemNo(itemNumber);
        }
    }
}
