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
	/// 一些基本的，作为辅助函数的接口
	/// </summary>
    public interface IBaseDAL<T> where T : BaseEntity
	{
		/// <summary>
		/// 查询数据库,检查是否存在指定键值的对象
		/// </summary>
		/// <param name="recordTable">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
		/// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
		bool IsExistKey(Hashtable recordTable);

		/// <summary>
		/// 查询数据库,检查是否存在指定键值的对象
		/// </summary>
		/// <param name="fieldName">指定的属性名</param>
		/// <param name="key">指定的值</param>
		/// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
		bool IsExistKey(string fieldName, object key);

		/// <summary>
		/// 获取数据库中该对象的最大ID值
		/// </summary>
		/// <returns>最大ID值</returns>
		int GetMaxID();

		/// <summary>
		/// 根据指定对象的ID,从数据库中删除指定对象
		/// </summary>
		/// <param name="key">指定对象的ID</param>
		/// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
		bool DeleteByKey(string key);
		
		/// <summary>
		/// 根据条件,从数据库中删除指定对象
		/// </summary>
		/// <param name="condition">删除记录的条件语句</param>
		/// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
		bool DeleteByCondition(string condition);


        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="obj">指定的对象</param>
        /// <returns>执行成功返回True</returns>
        bool Insert(T obj);

        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="obj">指定的对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool Update(T obj, string primaryKeyValue);

        /// <summary>
        /// 查询数据库,检查是否存在指定ID的对象(用于整型主键)
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        T FindByID(int key);

        /// <summary>
        /// 查询数据库,检查是否存在指定ID的对象(用于字符型主键)
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        T FindByID(string key);

        #region 返回集合的接口

        /// <summary>
        /// 根据ID字符串(逗号分隔)获取对象列表
        /// </summary>
        /// <param name="idString">ID字符串(逗号分隔)</param>
        /// <returns>符合条件的对象列表</returns>
        List<T> FindByIDs(string idString);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        List<T> Find(string condition);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <returns>指定对象的集合</returns>
        List<T> Find(string condition, PagerInfo info);

        /// <summary>
        /// 返回数据库所有的对象集合
        /// </summary>
        /// <returns>指定对象的集合</returns>
        List<T> GetAll();

        /// <summary>
        /// 返回数据库所有的对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="info">分页实体信息</param>
        /// <returns>指定对象的集合</returns>				
        List<T> GetAll(PagerInfo info);

        DataSet GetAllToDataSet(PagerInfo info);

        DataTable GetAllToDataTable();

        DataTable FindToDataTable(string condition);

        #endregion
	}
}