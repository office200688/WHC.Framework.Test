using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TMIS.Entity
{
    [Serializable]
    public class TB_PurchaseDetailInfo : BaseEntity
    {
        #region Field Members

        private int m_ID = 0;
        private int m_PurchaseHead_ID = 0; //
        private string m_OperationType = ""; //
        private string m_ItemNo = ""; //
        private string m_ItemName = ""; //
        private string m_MapNo = ""; //
        private string m_Specification = ""; //
        private string m_Material = ""; //
        private string m_ItemBigType = ""; //ItemType
        private string m_c = ""; //
        private string m_Unit = ""; //
        private decimal m_Price = 0;
        private float m_Quantity = 0.0F;
        private decimal m_Amount = 0;
        private string m_Source = "";
        private string m_StoragePos = "";
        private string m_UsagePos = "";
        private string m_WareHouse = "";
        private string m_Dept = "";

        #endregion

        #region Property Members

        public virtual int ID
        {
            get
            {
                return this.m_ID;
            }
            set
            {
                this.m_ID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual int PurchaseHead_ID
        {
            get
            {
                return this.m_PurchaseHead_ID;
            }
            set
            {
                this.m_PurchaseHead_ID = value;
            }
        }
        public virtual string OperationType
        {
            get { return this.m_OperationType; }
            set { this.m_OperationType = value; }
        }
        public virtual string ItemNo
        {
            get { return this.m_ItemNo; }
            set { this.m_ItemNo = value; }
        }
        public virtual string ItemName
        {
            get { return this.m_ItemName; }
            set { this.m_ItemName = value; }
        }
        public virtual string MapNo
        {
            get { return this.m_MapNo; }
            set { this.m_MapNo = value; }
        }
        public virtual string Specification
        {
            get { return this.m_Specification; }
            set { this.m_Specification = value; }
        }
        public virtual string Material
        {
            get { return this.m_Material; }
            set { this.m_Material = value; }
        }
        public virtual string ItemBigType
        {
            get { return this.m_ItemBigType; }
            set { this.m_ItemBigType = value; }
        }
        public virtual string c
        {
            get { return this.m_c; }
            set { this.m_c = value; }
        }
        public virtual string Unit
        {
            get { return this.m_Unit; }
            set { this.m_Unit = value; }
        }
        public virtual decimal Price
        {
            get { return this.m_Price; }
            set { this.m_Price = value; }
        }
        public virtual float Quantity
        {
            get { return this.m_Quantity; }
            set { this.m_Quantity = value; }
        }
        public virtual decimal Amount
        {
            get { return this.m_Amount; }
            set { this.m_Amount = value; }
        }
        public virtual string Source
        {
            get { return this.m_Source; }
            set { this.m_Source = value; }
        }
        public virtual string StoragePos
        {
            get { return this.m_StoragePos; }
            set { this.m_StoragePos = value; }
        }
        public virtual string UsagePos
        {
            get { return this.m_UsagePos; }
            set { this.m_UsagePos = value; }
        }
        public virtual string WareHouse
        {
            get { return this.m_WareHouse; }
            set { this.m_WareHouse = value; }
        }
        public virtual string Dept
        {
            get { return this.m_Dept; }
            set { this.m_Dept = value; }
        }

        #endregion
    }
}
