using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevForm;

namespace TrillionIce
{
    public partial class FM_LogIn : Form
    {
        public static string auth = "";
        int pwFailCount = 0;

        public FM_LogIn()
        {
            InitializeComponent();
            Tag = "FAIL";
        }

        private void btnSignIn_Click(object sender, EventArgs e) // SP_T1_USER_HYT_S1
        {
            string userId = txtUserId.Text;
            string password = txtPassword.Text;

            if (userId == "" || password == "" || userId == " Userid"
                    || password == " Password")
            { MessageBox.Show("모든 항목을 입력해주세요."); return; }

            DBHelper helper = new DBHelper(false);
            DataTable dtTemp = helper.FillTable("SP_T1_USER_HYT_S1", CommandType.StoredProcedure
                            , helper.CreateParameter("USERID", userId));

            if (dtTemp.Rows.Count == 0)
            {
                MessageBox.Show("등록되지 않은 아이디입니다.");
                return;
            }
            else if (dtTemp.Rows[0]["PW"].ToString() != password)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                pwFailCount++;
                if (pwFailCount == 3)
                {
                    MessageBox.Show("실패 가능 횟수를 초과하였습니다.");
                    pwFailCount = 0;
                    Close();
                }
                return;
            }
            else
            {
                Common.signInId = txtUserId.Text;
                Common.signInName = dtTemp.Rows[0]["USERNAME"].ToString();
                Tag = dtTemp.Rows[0]["USERNAME"].ToString();
                auth = dtTemp.Rows[0]["AUTH"].ToString();
                Close();
            }
            helper.Close();
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {
            Visible = false;
            FM_ChangePw ChangePw = new FM_ChangePw();
            ChangePw.ShowDialog();
            Visible = true;
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
                btnSignIn_Click(sender, e);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Visible = false;
            FM_SignUp SignUp = new FM_SignUp();
            SignUp.ShowDialog();
            Visible = true;
        }
    }
}
