using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMIS.Entity;

namespace TMIS.IDAL
{
    public interface ITB_PurchaseDetail : IBaseDAL<TB_PurchaseDetailInfo>
    {
        List<string> GetAllTB_PurchaseDetailItemNo();
        TB_PurchaseDetailInfo GetByTB_PurchaseDetailItemNo(string itemNum);
    }
}
