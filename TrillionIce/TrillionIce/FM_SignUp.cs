using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevForm;

namespace TrillionIce
{
    public partial class FM_SignUp : Form
    {
        private SqlConnection Conn = null;
        string ConnInfo = Common.db;
        public FM_SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            SqlTransaction Txn;
            Conn = new SqlConnection(ConnInfo);
            Conn.Open();
            if (Conn.State != ConnectionState.Open)
            {
                MessageBox.Show("DB 연결에 실패하였습니다.");
                return;
            }

            string userName = txtUserName.Text;
            string userId = txtUserId.Text;
            string password = txtPassword.Text;

            if (userName == "" || userId == "" || password == "") {MessageBox.Show("모든 항목을 입력해주세요."); return;}
            SqlDataAdapter Adapter = new SqlDataAdapter(
                $"SELECT USERNAME, PW, AUTH FROM TB_1_USER WHERE USERID = '{userId}'", Conn);
            DataTable DtTemp = new DataTable();
            Adapter.Fill(DtTemp);
            if (DtTemp.Rows.Count != 0) {MessageBox.Show("등록된 아이디입니다 새로운 아이디를 입력하세요."); return;}

            Txn = Conn.BeginTransaction("Sign Up");
            Cmd.Transaction = Txn;
            Cmd.Connection = Conn;
            Cmd.CommandText = $"INSERT INTO TB_1_USER ( USERID,   USERNAME,   PW,         AUTH,  MAKEDATE,   MAKER) " +
                                             $"VALUES ('{userId}', '{userName}', '{password}', 'CUST', GETDATE(), 'ADMIN')";
            Cmd.ExecuteNonQuery();
            Txn.Commit();

            MessageBox.Show("회원가입을 축하합니다. 가입한 계정으로 로그인해주세요");
            Conn.Close();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtUserName.ForeColor = Color.Black;
        }

        private void txtUserId_Enter(object sender, EventArgs e)
        {
            txtUserId.Clear();
            txtUserId.ForeColor = Color.Black;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.ForeColor = Color.Black;
            txtPassword.PasswordChar = '*';
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }
    }
}
