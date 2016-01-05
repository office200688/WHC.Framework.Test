using System;
using System.Xml.Serialization;

namespace TMIS.Entity
{
    [Serializable]
    public class CustomerInfo : BaseEntity
    {    
        #region Field Members

        private string m_ID = "";         
        private string m_Number = ""; //客户编号          
        private string m_Name = ""; //客户名称          
        private string m_Type = ""; //客户类型          
        private string m_Area = ""; //客户地区          
        private string m_Company = ""; //客户单位          
        private string m_Address = ""; //客户地址          
        private string m_Telephone1 = ""; //电话1          
        private string m_Telephone2 = ""; //电话2          
        private string m_Telephone3 = ""; //电话3          
        private string m_Telephone4 = ""; //电话4          
        private string m_Telephone5 = ""; //电话5          
        private DateTime m_CreateDate = System.DateTime.Now; //开户日期          
        private string m_Shop_ID = ""; //分店ID          
        private string m_Note = ""; //备注          
        private DateTime m_LastUpdated = System.DateTime.Now; //最后更新          

        #endregion

        #region Property Members
        
        public virtual string ID
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
        /// 客户编号
        /// </summary>
        public virtual string Number
        {
            get
            {
                return this.m_Number;
            }
            set
            {
                this.m_Number = value;
            }
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        public virtual string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        /// <summary>
        /// 客户类型
        /// </summary>
        public virtual string Type
        {
            get
            {
                return this.m_Type;
            }
            set
            {
                this.m_Type = value;
            }
        }

        /// <summary>
        /// 客户地区
        /// </summary>
        public virtual string Area
        {
            get
            {
                return this.m_Area;
            }
            set
            {
                this.m_Area = value;
            }
        }

        /// <summary>
        /// 客户单位
        /// </summary>
        public virtual string Company
        {
            get
            {
                return this.m_Company;
            }
            set
            {
                this.m_Company = value;
            }
        }

        /// <summary>
        /// 客户地址
        /// </summary>
        public virtual string Address
        {
            get
            {
                return this.m_Address;
            }
            set
            {
                this.m_Address = value;
            }
        }

        /// <summary>
        /// 电话1
        /// </summary>
        public virtual string Telephone1
        {
            get
            {
                return this.m_Telephone1;
            }
            set
            {
                this.m_Telephone1 = value;
            }
        }

        /// <summary>
        /// 电话2
        /// </summary>
        public virtual string Telephone2
        {
            get
            {
                return this.m_Telephone2;
            }
            set
            {
                this.m_Telephone2 = value;
            }
        }

        /// <summary>
        /// 电话3
        /// </summary>
        public virtual string Telephone3
        {
            get
            {
                return this.m_Telephone3;
            }
            set
            {
                this.m_Telephone3 = value;
            }
        }

        /// <summary>
        /// 电话4
        /// </summary>
        public virtual string Telephone4
        {
            get
            {
                return this.m_Telephone4;
            }
            set
            {
                this.m_Telephone4 = value;
            }
        }

        /// <summary>
        /// 电话5
        /// </summary>
        public virtual string Telephone5
        {
            get
            {
                return this.m_Telephone5;
            }
            set
            {
                this.m_Telephone5 = value;
            }
        }

        /// <summary>
        /// 开户日期
        /// </summary>
        public virtual DateTime CreateDate
        {
            get
            {
                return this.m_CreateDate;
            }
            set
            {
                this.m_CreateDate = value;
            }
        }

        /// <summary>
        /// 分店ID
        /// </summary>
        public virtual string Shop_ID
        {
            get
            {
                return this.m_Shop_ID;
            }
            set
            {
                this.m_Shop_ID = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note
        {
            get
            {
                return this.m_Note;
            }
            set
            {
                this.m_Note = value;
            }
        }

        /// <summary>
        /// 最后更新
        /// </summary>
        public virtual DateTime LastUpdated
        {
            get
            {
                return this.m_LastUpdated;
            }
            set
            {
                this.m_LastUpdated = value;
            }
        }


        #endregion

    }
}