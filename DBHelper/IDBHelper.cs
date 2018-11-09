using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public interface IDBHelper
    {
        /// <summary>
        /// 创建一个空数据库文件
        /// </summary>
        /// <param name="dbName">文件名称</param>
        /// <returns>创建结果</returns>
        bool CreateDataBase(string dbName, ref string message);

        /// <summary>
        /// 在指定数据库中创建数据表
        /// </summary>
        /// <param name="dbName">指定数据库</param>
        /// <param name="tbName">数据表名</param>
        /// <param name="columns">表中字段</param>
        /// <returns>创建结果</returns>
        bool CreateDataTable(string tbName, string columns, ref string message);

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataSet</returns>
        DataSet Query(string sql);

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>影响的记录数</returns>
        int ExcuteSQL(string sql);

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="sqls">多条SQL语句</param>
        /// <returns>是否执行成功</returns>
        bool DoTransaction(string[] sqls);
    }
}
