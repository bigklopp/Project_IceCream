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
    public partial class FM_CustMain : Form
    {

        public static string IdValidation = "FAIL";
        public static DataTable cartData = new DataTable();

        #region Connection Init
        private SqlConnection Conn = null;
        private string ConnInfo = Common.db;
        #endregion
        public FM_CustMain()
        {
            InitializeComponent();
            btnSearch_Click(null, null);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            FM_LogIn LogIn = new FM_LogIn();
            LogIn.ShowDialog();
            IdValidation = LogIn.Tag.ToString();
            if (IdValidation == "FAIL")
            {
                Environment.Exit(0);
            }
            lbUserName.Text = $"{IdValidation}님, 환영합니다!";
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (IdValidation == "FAIL")
            {
                MessageBox.Show("구매하려면 로그인하세요");
                return;
            }
            if (cartData.Rows.Count == 0)
            {
                MessageBox.Show("선택한 상품이 없습니다.");
                return;
            }
            FM_Order CustOrder = new FM_Order();
            CustOrder.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                #region Connection Open
                Conn = new SqlConnection(ConnInfo);
                Conn.Open();

                if (Conn.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("DB 연결에 실패하였습니다.");
                    return;
                }
                #endregion

                #region Variable Init
                string itemName = "";
                #endregion

                #region Fill Data
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT ITEMNAME, DESCRIPTION FROM TB_1_ITEM WITH(NOLOCK) " +
                                                           $"WHERE ITEMNAME LIKE '%{itemName}%' ", Conn);
                DataTable DtTemp = new DataTable();
                Adapter.Fill(DtTemp);
                #endregion

                #region Show Data
                if (DtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("검색 조건에 맞는 데이터가 없습니다.");
                    dgvItem.DataSource = null;
                    return;
                }
                dgvItem.DataSource = DtTemp;
                #endregion

                #region Set Column
                dgvItem.Columns["ITEMNAME"].HeaderText = "상품명";
                dgvItem.Columns["DESCRIPTION"].HeaderText = "상품설명";

                dgvItem.Columns[0].Width = 200;
                dgvItem.Columns[1].Width = 500;

                dgvItem.Columns["ITEMNAME"].ReadOnly = true;
                dgvItem.Columns["DESCRIPTION"].ReadOnly = true;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
