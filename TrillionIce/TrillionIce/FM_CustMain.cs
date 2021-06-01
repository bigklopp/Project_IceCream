using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevForm;

namespace TrillionIce
{
    public partial class FM_CustMain : Form
    {

        public static string IdValidation = "FAIL";

        public static DataTable cartData = new DataTable();
        public static DataColumn cartItem = new DataColumn("ITEMNAME", typeof(string));
        public static DataColumn quantity = new DataColumn("QUANTITY", typeof(int));

        #region Connection Init
        private SqlConnection Conn = null;
        private string ConnInfo = Common.db;
        #endregion
        public FM_CustMain()
        {
            InitializeComponent();
            btnSearch_Click(null, null);
            
            cartData.Columns.Add(cartItem);
            cartData.Columns.Add(quantity);
            dgvCart.DataSource = cartData;
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
            if (FM_LogIn.auth == "SYS")
            {
                FM_SysMain SysMain = new FM_SysMain();
                SysMain.ShowDialog();
            }
            else
            {
                lbUserName.Text = $"{IdValidation}님, 환영합니다!";
            }
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

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string itemName = dgvItem.CurrentRow.Cells["ITEMNAME"].Value.ToString();
            
            try
            {
                // 이미지 초기화
                picImage.Image = null;
                string Sql = "SELECT ITEMIMG FROM TB_1_ITEM WHERE ITEMNAME = '" + itemName
                              + "' AND ITEMIMG IS NOT NULL";
                SqlDataAdapter Adapter = new SqlDataAdapter(Sql, Conn);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0) return;

                byte[] bImage = null;
                bImage = (byte[])dtTemp.Rows[0]["ITEMIMG"]; // 이미지를 byte 화 한다.
                if (bImage != null)
                {
                    picImage.Image = new Bitmap(new MemoryStream(bImage)); // 메모리 스트림을 이용하여 파일을 그림 파일로 만든다.
                    picImage.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedItem = dgvItem.CurrentRow.Cells["ITEMNAME"].Value.ToString();
            DataRow row = cartData.NewRow();
            row[cartItem] = selectedItem;
            cartData.Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dgvItem.Rows.Count == 0)
            {
                MessageBox.Show("장바구니에 품목이 없습니다.");
                return;
            }
            if (MessageBox.Show("장바구니에서 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo) == DialogResult.No) return;
            dgvCart.Rows.Remove(dgvCart.CurrentRow);
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button1_Click(null, null);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void picImage_Click(object sender, EventArgs e)
        {

        }
    }
}
