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
        #region Connection Init
        private SqlConnection Conn = null;
        string ConnInfo = Common.db;
        #endregion

        int pwFailCount = 0;
        public FM_ChangePw()
        {
            InitializeComponent();
        }


        private void btnChangePw_Click(object sender, EventArgs e)
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
            string currentPw = txtCurrentPw.Text;
            string newPw = txtNewPw.Text;
            #endregion

            #region Fill Data
            SqlDataAdapter Adapter = new SqlDataAdapter(
                $"SELECT PW FROM TB_1_USER WHERE USERID = '{userId}'", Conn);
            DataTable DtTemp = new DataTable();
            Adapter.Fill(DtTemp);
            #endregion

            if (DtTemp.Rows.Count == 0)
            {
                MessageBox.Show("등록되지 않은 아이디입니다.");
                return;
            }
            else if (DtTemp.Rows[0]["PW"].ToString() != currentPw)
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

                #region Transaction Decl
                SqlTransaction Txn;
                SqlCommand Cmd = new SqlCommand();
                #endregion

                #region Transaction Init
                Txn = Conn.BeginTransaction("PW_Change");
                Cmd.Transaction = Txn;
                Cmd.Connection = Conn;
                #endregion

                #region Transaction Commit
                Cmd.CommandText = $"UPDATE TB_1_USER SET PW = '{newPw}' WHERE USERID = '{userId}'";
                Cmd.ExecuteNonQuery();
                Txn.Commit();
                #endregion

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
    }
}
