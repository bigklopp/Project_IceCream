using System;
using System.Data;
using System.Data.Common;

namespace DevForm
{
    public class DBHelper
    {
        private DbProviderFactory dataFactory = null;   // 데이터 를 수집 하기 위한 DB 타입 모음 함수.
        private DbConnection _Conn = null;
        private DbTransaction _Txn = null;
        private DbCommand _Cmd = null;

        public DBHelper(bool includeTxn)
        {
            Init(includeTxn);
        }

        public bool Init(bool includeTxn)
        {
            try
            {
                string conStr = Common.db;
                // DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);  
                // 하위 버전에서는 활성화 : System.Data.SqlClient 형식의 Factory 사용 등록
                dataFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");   // 데이터 베이스 내용을 담아올 그릇의 DB 종류 선언   
                _Conn = dataFactory.CreateConnection();                                  // 데이터베이스 연결 함수 DbConnection 과 FACTORY 연동
                _Conn.ConnectionString = conStr;                                         // 연결 함수에 데이터베이스 주소 입력
                _Conn.Open();
                if (includeTxn) _Txn = _Conn.BeginTransaction();
            }
            catch
            {
                return true;
            }
            return false;
        }

        public DataTable FillTable(string query, CommandType commandType, params Object[] parameters)
        {
            return FillTable_Detail(query, commandType, parameters);   // 프로시저 명, 실행 타입(프로시저), 파라매터
        }
        public DataTable FillTable_Detail(string query, CommandType commandType, params Object[] parameters)
        {
            _Cmd = _Conn.CreateCommand();    // 데이터 베이스 명령 함수 선언 
            _Cmd.Connection = _Conn;         // 명령 함수에 연결 주소 입력
            _Cmd.CommandText = query;        // 명령 SP 입력
            _Cmd.CommandType = commandType;  // 명령 종류(프로시저) 입력.


            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    _Cmd.Parameters.Add(parameters[i]);
                }
            }

            DbDataAdapter oAdap = dataFactory.CreateDataAdapter();  // DB 에 명령문 실행 및 반환 데이터를 리턴 받는 ADAPTER 선언.
            oAdap.SelectCommand = _Cmd;                             // 어댑터에 명령어 입력.

            DataTable dt = new DataTable();
            oAdap.Fill(dt);                                         // 어뎁터 실행 하여 반환 값 리턴받음.

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToUpper();
            }
            return dt;
        }

        public int ExecuteNoneQuery(string query, CommandType commandType, params Object[] parameters)
        {
            return ExecuteNoneQuery_Detail(query, commandType, true, true, parameters);
        }
        public int ExecuteNoneQuery_Detail(string query, CommandType commandType, bool baddLang, bool baddOut, params Object[] parameters)
        {
            _Cmd = _Conn.CreateCommand();
            _Cmd.Connection = _Conn;
            _Cmd.CommandText = query;
            _Cmd.CommandType = commandType;

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    _Cmd.Parameters.Add(parameters[i]);
                }
            }

            _Cmd.Transaction = _Txn;
            int rtn = _Cmd.ExecuteNonQuery();
            return rtn;
        }

        public void Commit()
        {
            if (_Txn != null)
            {
                _Txn.Commit();
                _Txn = null;
            }
        }
        public void Rollback()
        {
            if (_Txn != null)
            {
                _Txn.Rollback();
                _Txn = null;
            }
        }

        public DbParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            DbParameter param = dataFactory.CreateParameter();
            param.ParameterName = name.ToUpper();
            param.Value = value;
            param.Direction = direction;

            return param;
        }

        public void Close()
        {
            Close(true);
        }
        public void Close(bool bCommit)
        {
            try
            {
                if (_Txn != null)
                {
                    if (bCommit)
                        _Txn.Commit();
                    else
                        _Txn.Rollback();
                }
                _Conn.Close();
            }
            catch { }
        }
    }
}
