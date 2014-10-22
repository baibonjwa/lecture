// ===============================================================================
// Microsoft Data Access Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//
// SQLHelper.cs
//
// This file contains the implementations of the SqlHelper and SqlHelperParameterCache
// classes.
//
// For more information see the Data Access Application Block Implementation Overview. 
// ===============================================================================
// Release history
// VERSION	DESCRIPTION
//   2.0	Added support for FillDataset, UpdateDataset and "Param" helper methods
//
// ===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// ==============================================================================

using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace lecture.Model.Concrete
{
    public class SqlHelper
    {
        #region ͨ�÷���
        // �������ӳ�  
        private SqlConnection con;
        /// <summary>  
        /// �������ݿ������ַ���  
        /// </summary>  
        /// <returns></returns>  
        public static String GetConnection()
        {
            String conn = System.Configuration.ConfigurationManager.ConnectionStrings["db_lecture"].ConnectionString;
            return conn;
        }
        #endregion
        public static int ExecuteNonQuery(String conn, CommandType commandType, string Sqlstr, params SqlParameter[] para)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand(Sqlstr, con);
                con.Open();
                for (int i = 0; i < para.Length; i++)
                {
                    cmd.Parameters.Add(para[i]);
                }
                return cmd.ExecuteNonQuery();//�رչ�����Connection  
            }
            catch //(Exception ex)  
            {
                return 0;
            }
        }
        public static object ExecuteScalar(String conn, CommandType commandType, string Sqlstr, params SqlParameter[] para)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand(Sqlstr, con);
            try
            {
                con.Open();
                for (int i = 0; i < para.Length; i++)
                {
                    cmd.Parameters.Add(para[i]);
                }
                return cmd.ExecuteScalar();//�رչ�����Connection  
            }
            catch //(Exception ex)  
            {
                return 0;
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }
        #region ִ��sql�ַ���
        /// <summary>  
        /// ִ�в���������SQL���  
        /// </summary>  
        /// <param name="Sqlstr"></param>  
        /// <returns></returns>  
        public static int ExecuteSql(String Sqlstr)
        {
            String ConnStr = GetConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }
        /// <summary>  
        /// ִ�д�������SQL���  
        /// </summary>  
        /// <param name="Sqlstr">SQL���</param>  
        /// <param name="param">������������</param>  
        /// <returns></returns>  
        public static int ExecuteSql(String Sqlstr, SqlParameter[] param)
        {
            String ConnStr = GetConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                cmd.Parameters.AddRange(param);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }
        /// <summary>  
        /// ����DataReader  
        /// </summary>  
        /// <param name="Sqlstr"></param>  
        /// <returns></returns>  
        public static SqlDataReader ExecuteReader(String conn, CommandType type, String Sqlstr, params SqlParameter[] para)
        {
            //����DataReaderʱ,�ǲ�������using()��  
            try
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand(Sqlstr, con);
                con.Open();
                for (int i = 0; i < para.Length; i++)
                {
                    cmd.Parameters.Add(para[i]);
                }
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);//�رչ�����Connection  
            }
            catch //(Exception ex)  
            {
                return null;
            }
        }
        /// <summary>  
        /// ִ��SQL��䲢�������ݱ�  
        /// </summary>  
        /// <param name="Sqlstr">SQL���</param>  
        /// <returns></returns>  
        public static DataTable ExecuteDt(String Sqlstr)
        {
            String ConnStr = GetConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        /// <summary>  
        /// ִ��SQL��䲢����DataSet  
        /// </summary>  
        /// <param name="Sqlstr">SQL���</param>  
        /// <returns></returns>  
        public static DataSet ExecuteDs(String Sqlstr)
        {
            String ConnStr = GetConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }
        #endregion
        #region �����洢����
        /// <summary>  
        /// ���д洢����(������)  
        /// </summary>  
        /// <param name="procName">�洢���̵�����</param>  
        /// <returns>�洢���̵ķ���ֵ</returns>  
        public int RunProc(string procName)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>  
        /// ���д洢����(������)  
        /// </summary>  
        /// <param name="procName">�洢���̵�����</param>  
        /// <param name="prams">�洢���̵���������б�</param>  
        /// <returns>�洢���̵ķ���ֵ</returns>  
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters[0].Value;
        }
        /// <summary>  
        /// ���д洢����(������)  
        /// </summary>  
        /// <param name="procName">�洢���̵�����</param>  
        /// <param name="dataReader">�����</param>  
        public void RunProc(string procName, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        /// <summary>  
        /// ���д洢����(������)  
        /// </summary>  
        /// <param name="procName">�洢���̵�����</param>  
        /// <param name="prams">�洢���̵���������б�</param>  
        /// <param name="dataReader">�����</param>  
        public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        /// <summary>  
        /// ����Command�������ڷ��ʴ洢����  
        /// </summary>  
        /// <param name="procName">�洢���̵�����</param>  
        /// <param name="prams">�洢���̵���������б�</param>  
        /// <returns>Command����</returns>  
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // ȷ�������Ǵ򿪵�  
            Open();
            //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) );  
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            // ��Ӵ洢���̵���������б�  
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            // ����Command����  
            return cmd;
        }
        /// <summary>  
        /// �����������  
        /// </summary>  
        /// <param name="ParamName">������</param>  
        /// <param name="DbType">��������</param>  
        /// <param name="Size">������С</param>  
        /// <param name="Value">����ֵ</param>  
        /// <returns>�²�������</returns>  
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        /// <summary>  
        /// �����������  
        /// </summary>  
        /// <param name="ParamName">������</param>  
        /// <param name="DbType">��������</param>  
        /// <param name="Size">������С</param>  
        /// <returns>�²�������</returns>  
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }
        /// <summary>  
        /// �����洢���̲���  
        /// </summary>  
        /// <param name="ParamName">������</param>  
        /// <param name="DbType">��������</param>  
        /// <param name="Size">������С</param>  
        /// <param name="Direction">�����ķ���(����/���)</param>  
        /// <param name="Value">����ֵ</param>  
        /// <returns>�²�������</returns>  
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;
            if (Size > 0)
            {
                param = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                param = new SqlParameter(ParamName, DbType);
            }
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }
            return param;
        }
        #endregion
        #region ���ݿ����Ӻ͹ر�
        /// <summary>  
        /// �����ӳ�  
        /// </summary>  
        private void Open()
        {
            // �����ӳ�  
            if (con == null)
            {
                //���ﲻ����Ҫusing System.Configuration;��Ҫ������Ŀ¼�����  
                con = new SqlConnection(GetConnection());
                con.Open();
            }
        }
        /// <summary>  
        /// �ر����ӳ�  
        /// </summary>  
        public void Close()
        {
            if (con != null)
                con.Close();
        }
        /// <summary>  
        /// �ͷ����ӳ�  
        /// </summary>  
        public void Dispose()
        {
            // ȷ�������ѹر�  
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
        #endregion
    }
}
