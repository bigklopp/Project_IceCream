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
        
        public FM_SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            /*SqlCommand Cmd = new SqlCommand();
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
            this.Close();*/

            DBHelper helper1 = new DBHelper(false);

            DBHelper helper2 = new DBHelper(true);



            try
            {

                string userName = txtUserName.Text;
                string userId = txtUserId.Text;
                string password = txtPassword.Text;

                if (userName == "" || userId == "" || password == "" || userName == "이름을 입력하세요" 
                    || userId == " 사용할 아이디를 입력하세요" || password == " 사용할 패스워드를 입력하세요") 
                { MessageBox.Show("모든 항목을 입력해주세요."); return; }
                

                DataTable dtTemp = new DataTable();
                dtTemp = helper1.FillTable("SP_T1_SIGNUP_S1", CommandType.StoredProcedure
                               , helper1.CreateParameter("USERID", userId));

                if (dtTemp.Rows.Count != 0) { MessageBox.Show("등록된 아이디입니다 새로운 아이디를 입력하세요."); return; }

                helper2.ExecuteNoneQuery("SP_T1_SIGNUP_I1", CommandType.StoredProcedure
                    , helper2.CreateParameter("USERNAME", userName)
                    , helper2.CreateParameter("USERID", userId)
                    , helper2.CreateParameter("PW", password));
                
                helper2.Commit();
                MessageBox.Show("회원가입을 축하합니다. 가입한 계정으로 로그인해주세요");
                this.Close();


            }
            catch (Exception ex)
            {
                
                helper2.Rollback();

                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
            finally
            {
                
                helper2.Close();

            }
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
