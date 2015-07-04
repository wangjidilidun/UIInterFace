using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Data.OleDb;

namespace Utility
{
/// <summary>
/// DbHelper 的摘要说明
/// </summary>
    public class OleDbHelper
    {
        private static string _connstr;
        public static string GetConnectionString
        {
            get { return _connstr; }
            set { _connstr = value; }
        }
        private static OleDbConnection _conn;
        public static OleDbConnection Conn
        {
            get
            {
                string connectionString = GetConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                    connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = .\Comuni.accdb";
                    //connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
       
                if (_conn == null)
                {
                    _conn = new OleDbConnection(connectionString);
                    _conn.Open();
                }
                else if (_conn.State == System.Data.ConnectionState.Closed)
                {
                    _conn.Open();
                }
                else if (_conn.State == System.Data.ConnectionState.Broken)
                {
                    _conn.Close();
                    _conn.Open();
                }
                return _conn;
            }
        }
        private static void Colseconnection()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
        /// <summary>
        /// 记录错误日记
        /// </summary>
        /// <param name="remark"></param>
        private static void CmsLogBLL(string remark)
        {
            try
            {

                string strSql = " Insert Into cms_log(remark) values('" + remark + "') ";

                OleDbHelper.ExecuteErrorSql(strSql);
            }
            catch { }
        }
        #region Insert, Update, Delete 方法
        /// <summary>
        /// 执行单个SQL语句  后台跟着错误SQL语句使用
        /// </summary>
        /// <param name="inSQL">SQL语句</param>
        /// <returns> bool </returns>
        private static bool ExecuteErrorSql(string inSQL)
        {
            bool rtn = false;


            try
            {

                OleDbCommand cmd = new OleDbCommand(inSQL, Conn);
                try
                {
                    if (cmd.ExecuteNonQuery() > -1)
                        rtn = true;
                }
                catch
                {
                    rtn = false;
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                }

            }
            catch 
            {
               
                rtn = false;
            }
            finally
            {
                Colseconnection();
            }
            return rtn;
        }

        /// <summary>
        /// 执行单个SQL语句
        /// </summary>
        /// <param name="inSQL">SQL语句</param>
        /// <returns> bool </returns>
        public static bool ExecuteNonQuery(string inSQL)
        {
            bool rtn = false;


            try
            {

                OleDbCommand cmd = new OleDbCommand(inSQL, Conn);
                try
                {
                    if (cmd.ExecuteNonQuery() > -1)
                        rtn = true;
                }
                catch (Exception ex)
                {
                    CmsLogBLL(ex.Message + "<br/>" + inSQL);
                    rtn = false;
                }
                finally
                {
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                CmsLogBLL(ex.Message + "<br/>" + inSQL);
                rtn = false;
            }
            finally
            {
                //Conn.Dispose();
                //Conn.Close();
            }
            return rtn;
        }

        /// <summary>
        /// 执行多个SQL语句
        /// </summary>
        /// <param name="inSQL">SQL数组</param>
        /// <returns>bool</returns>
        public static bool ExecuteNonQuery(string[] inSQL)
        {
            bool rtn = true;


            try
            {

                OleDbCommand cmd = new OleDbCommand();
                for (int i = 0; i < inSQL.Length; i++)
                {
                    if (inSQL[i].Trim().CompareTo("") == 0)
                        continue;

                    cmd = new OleDbCommand(inSQL[i], Conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        CmsLogBLL(ex.Message + "<br/>" + inSQL[i]);
                        rtn = false;
                    }
                }
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                CmsLogBLL(ex.Message);

                rtn = false;
            }
            finally
            {
                // _conn.Close();
                // _conn.Dispose();
            }
            return rtn;
        }
        #endregion Insert, Update, Delete 方法

        #region 执行单个SQL语句 return DataSet 方法
        /// <summary>
        /// 执行单个SQL语句
        /// </summary>
        /// <param name="inSelectSQL">SQL语句</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string inSelectSQL)
        {


           
            try
            {
                DataSet ds = new DataSet();

                OleDbDataAdapter da = new OleDbDataAdapter(inSelectSQL, Conn);
                da.Fill(ds, "51program");
                return ds;
            }
            catch (Exception ex)
            {
                CmsLogBLL(ex.Message + "<br/>" + inSelectSQL);
                return null;
            }
            finally
            {
                //_conn.Close();
                //_conn.Dispose();
                
            }
            
        }
        #endregion return DataSet 方法

        #region 执行单个Sql return DataTable 方法
        /// <summary>
        /// 执行Sql 返回DataTable
        /// </summary>
        /// <param name="inSQL">Sql语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string inSQL)
        {
            DataTable dt = new DataTable();
            dt = ExecuteDataSet(inSQL).Tables[0];
            return dt;
        }

        #endregion

        #region ExecuteReader

        public static OleDbDataReader ExecuteReader(string inSql)
        {
            OleDbCommand cmd = new OleDbCommand();

            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = Conn;
                cmd.CommandText = inSql;

                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 30;
                OleDbDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                CmsLogBLL(ex.Message + "<br/>" + inSql);
                return null;
            }
            finally
            {
                // _conn.Close();
                // _conn.Dispose();
            }
        }

        #endregion

        #region 获取第一行第一列 方法
        /// <summary>
        /// 获取第一行第一列 方法
        /// </summary>
        /// <param name="inSQL">Sql语句</param>
        /// <returns>第一行第一列值</returns>
        public static string ExecuteScalarToStr(string inSQL)
        {
            string strValue = "";
            OleDbCommand cmd = new OleDbCommand();

            try
            {

                cmd.Connection = Conn;
                cmd.CommandText = inSQL;

                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 30;
                object obj = cmd.ExecuteScalar();
                strValue = obj == null ? "" : obj.ToString();

            }
            catch (Exception ex)
            {
                CmsLogBLL(ex.Message + "<br/>" + inSQL);

            }
            finally
            {
                // _conn.Close();
                // _conn.Dispose();
            }
            return strValue;
        }
        #endregion 获取第一行第一列 方法

    }   
}
