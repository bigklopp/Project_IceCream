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
    public partial class FM_ChangePw : Form
    {
        int pwFailCount = 0;

        public FM_ChangePw()
        {
            InitializeComponent();
        }

        private void btnChangePw_Click(object sender, EventArgs e) // SP_T1_USER_HYT_S2, SP_T1_USER_HYT_U1
        {
            string userId = txtUserId.Text;
            string currentPw = txtCurrentPw.Text;
            string newPw = txtNewPw.Text;

            if (userId == "" || currentPw == "" || newPw == "" || userId == " Userid"
                    || currentPw == " Current Password" || newPw == " New Password")
            { MessageBox.Show("모든 항목을 입력해주세요."); return; }

            DBHelper helper1 = new DBHelper(false);
            DataTable dtTemp = helper1.FillTable("SP_T1_USER_HYT_S2", CommandType.StoredProcedure
                            , helper1.CreateParameter("USERID", userId));

            if (dtTemp.Rows.Count == 0)
            {
                MessageBox.Show("등록되지 않은 아이디입니다.");
                return;
            }
            else if (dtTemp.Rows[0]["PW"].ToString() != currentPw)
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
                if (MessageBox.Show("새로운 비밀번호로 변경하시겠습니까?", "Change password", MessageBoxButtons.YesNo)
                    == DialogResult.No) return;

                DBHelper helper2 = new DBHelper(true);
                helper2.ExecuteNoneQuery("SP_t1_USER_HYT_U1", CommandType.StoredProcedure
                                , helper2.CreateParameter("USERID", userId)
                                , helper2.CreateParameter("NEWPW", newPw));
                helper2.Commit();
                helper2.Close();

                MessageBox.Show("성공적으로 비밀번호를 변경하였습니다.");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserId_Enter(object sender, EventArgs e)
        {
            txtUserId.Clear();
            txtUserId.ForeColor = Color.Black;
        }

        private void txtCurrentPw_Enter(object sender, EventArgs e)
        {
            txtCurrentPw.Clear();
            txtCurrentPw.ForeColor = Color.Black;
            txtCurrentPw.PasswordChar = '*';
        }

        private void txtNewPw_Enter(object sender, EventArgs e)
        {
            txtNewPw.Clear();
            txtNewPw.ForeColor = Color.Black;
            txtNewPw.PasswordChar = '*';
        }

        private void btnChangePw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChangePw_Click(sender, e);
            }
        }

        private void txtNewPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChangePw_Click(sender, e);
            }
        }
    }
}
