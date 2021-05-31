using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevForm;

namespace TrillionIce
{
    public partial class FM_LogIn : Form
    {
        #region Connection Init
        private SqlConnection Conn = null;
        string ConnInfo = Common.db;
        #endregion

        int pwFailCount = 0;

        public FM_LogIn()
        {
            InitializeComponent();
            Tag = "FAIL";
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            #region Connection Open
            Conn = new SqlConnection(ConnInfo);
            Conn.Open();

            if (Conn.State != ConnectionState.Open)
            {
                MessageBox.Show("DB 연결에 실패하였습니다.");
                return;
            }
            #endregion

            #region Variable Init
            string userId = txtUserId.Text;
            string password = txtPassword.Text;
            #endregion

            #region Fill Data
            SqlDataAdapter Adapter = new SqlDataAdapter(
                $"SELECT USERNAME, PW FROM TB_1_USER WHERE USERID = '{userId}'", Conn);
            DataTable DtTemp = new DataTable();
            Adapter.Fill(DtTemp);
            #endregion

            if (DtTemp.Rows.Count == 0)
            {
                MessageBox.Show("등록되지 않은 아이디입니다.");
                return;
            }
            else if (DtTemp.Rows[0]["PW"].ToString() != password)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                pwFailCount++;
                if (pwFailCount == 3)
                {
                    MessageBox.Show("실패 가능 횟수를 초과하였습니다.");
                    Close();
                }
                return;
            }
            else
            {
                Common.signInId = txtUserId.Text;
                Common.signInName = DtTemp.Rows[0]["USERNAME"].ToString();
                Tag = DtTemp.Rows[0]["USERNAME"].ToString();
                Close();
            }
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

    }
}
