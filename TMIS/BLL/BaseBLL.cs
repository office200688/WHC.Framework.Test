using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using TMIS.Entity;
using TMIS.IDAL;
using WHC.Pager.Entity;
using WHC.Framework.Commons;

namespace TMIS.BLL
{
    public class BaseBLL<T> where T : BaseEntity, new()
    {
        private string dalName = "";
        protected IBaseDAL<T> baseDal = null;

        public BaseBLL() : this("")
        {
        }

        public BaseBLL(string dalName)
        {
#if false //原来的代码如下
            #region 根据不同的数据库类型，构造相应的DAL层
            AppConfig config = new AppConfig();
            string dbtype = config.AppConfigGet("ComponentDbType");
            if (string.IsNullOrEmpty(dbtype)) {
                dbtype = "sqlserver";
            }
            dbtype = dbtype.ToLower();

            string DALPrefix = "";
            if (dbtype == "sqlserver") {
                DALPrefix = "DALSQL.";
            }
            else if (dbtype == "access")
            {
                DALPrefix = "DALAccess.";
            }
            else if (dbtype == "oracle")
            {
                DALPrefix = "DALOracle.";
            }
                        
            #endregion
            if(string.IsNullOrEmpty(dalName))
            {
                this.dalName = GetType().FullName.Replace("BLL", DALPrefix);
            }else this.dalName = dalName;

            baseDal = Reflect<IBaseDAL<T>>.Create(this.dalName, "WHC.WareHouseMis");
#endif
            this.dalName = dalName;
            if(string.IsNullOrEmpty(dalName))
            {
                this.dalName = GetType().FullName.Replace("BLL", "DAL");
            }

            baseDal = Reflect<IBaseDAL<T>>.Create(this.dalName, "TMIS");
        }

        #region 对象添加、修改、查询接口

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="obj">指定的对象</param>
        /// <returns>执行成功返回新增记录的自增长ID。</returns>
        public virtual bool Insert(T obj)
        {
            return baseDal.Insert(obj);
        }

        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="obj">指定的对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(T obj, string primaryKeyValue)
        {
            return baseDal.Update(obj, primaryKeyValue);
        }

        /// <summary>
        /// 查询数据库,检查是否存在指定ID的对象(用于字符型主键)
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        public virtual T FindByID(string key)
        {
            return baseDal.FindByID(key);
        }


        #endregion

        #region 返回集合的接口

        /// <summary>
        /// 根据ID字符串(逗号分隔)获取对象列表
        /// </summary>
        /// <param name="idString">ID字符串(逗号分隔)</param>
        /// <returns>符合条件的对象列表</returns>
        public virtual List<T> FindByIDs(string idString)
        {
            return baseDal.FindByIDs(idString);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> Find(string condition)
        {
            return Find(condition);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> Find(string condition, PagerInfo info)
        {
            return baseDal.Find(condition, info);
        }

        /// <summary>
        /// 返回数据库所有的对象集合
        /// </summary>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> GetAll()
        {
            return baseDal.GetAll();
        }

        /// <summary>
        /// 返回数据库所有的对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="info">分页实体信息</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> GetAll(PagerInfo info)
        {
            return baseDal.GetAll(info);
        }

        public virtual DataSet GetAllToDataSet(PagerInfo info)
        {
            return baseDal.GetAllToDataSet(info);
        }

        public virtual DataTable GetAllToDataTable()
        {
            return baseDal.GetAllToDataTable();
        }

        public virtual DataTable FindToDataTable(string condition)
        {
            return baseDal.FindToDataTable(condition);
        }

        #endregion

        /// <summary>
        /// 查询数据库,检查是否存在指定键值的对象
        /// </summary>
        /// <param name="fieldName">指定的属性名</param>
        /// <param name="key">指定的值</param>
        /// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool IsExistKey(string fieldName, object key)
        {
            return baseDal.IsExistKey(fieldName, key);
        }

        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象(用于整型主键)
        /// </summary>
        /// <param name="key">指定对象的ID</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Delete(string key)
        {
            return baseDal.DeleteByKey(key);
        }

        /// <summary>
        /// 根据指定条件,从数据库中删除指定对象
        /// </summary>
        /// <param name="condition">删除记录的条件语句</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteByCondition(string condition)
        {
            return baseDal.DeleteByCondition(condition);
        }
    }
}
