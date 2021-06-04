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

        public FM_CustMain()
        {
            InitializeComponent();
            btnSearch_Click(null, null);
            
            cartData.Columns.Add(cartItem);
            cartData.Columns.Add(quantity);
            dgvCart.DataSource = cartData;


            dgvCart.Columns[0].Width = 150;
            dgvCart.Columns[1].Width = 75;

            dgvCart.Columns["ITEMNAME"].HeaderText = "상품명";
            dgvCart.Columns["QUANTITY"].HeaderText = "수량";
            dgvCart.Columns["ITEMNAME"].ReadOnly = true;

        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            
            FM_LogIn LogIn = new FM_LogIn();
            LogIn.ShowDialog();
            IdValidation = LogIn.Tag.ToString();
            if (IdValidation == "FAIL")
            {
                return;
            }
            if (FM_LogIn.auth == "SYS")
            {
                FM_SysMain SysMain = new FM_SysMain();
                SysMain.ShowDialog();
            }
            else
            {
                lbUserName.Text = $"{IdValidation}님, 환영합니다!";
                btnLogIn.Visible = false;
                btnLogOut.Visible = true;
                btnLogOut.Location = new Point(1400, 17);
                lbUserName.Location = new Point(1220, 23);
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (IdValidation == "FAIL")
            {
                MessageBox.Show("구매하려면 로그인하세요");
                btnLogIn_Click(null, null);
                btnPurchase_Click(null, null);
                return;
            }
            if (cartData.Rows.Count == 0)
            {
                MessageBox.Show("선택한 상품이 없습니다.");
                return;
            }
            FM_Order CustOrder = new FM_Order();
            CustOrder.ShowDialog();
            dgvCart.DataSource = cartData;
        }

        private void btnSearch_Click(object sender, EventArgs e) // SP_T1_CUST_HYT_S1
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string itemName = txtSearchItem.Text;

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_T1_CUST_HYT_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("ITEMNAME", itemName));

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("검색 조건에 맞는 데이터가 없습니다.");
                    dgvItem.DataSource = null;
                    return;
                }
                dgvItem.DataSource = dtTemp;

                dgvItem.Columns["ITEMNAME"].HeaderText = "상품명";
                dgvItem.Columns["DESCRIPTION"].HeaderText = "상품설명";

                dgvItem.Columns[0].Width = 200;
                dgvItem.Columns[1].Width = 500;

                dgvItem.Columns["ITEMNAME"].ReadOnly = true;
                dgvItem.Columns["DESCRIPTION"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e) // SP_T1_CIMG_HYT_S1
        {
            picImage.Image = null;
            DBHelper helper = new DBHelper(false);
            try
            {
                string itemName = dgvItem.CurrentRow.Cells["ITEMNAME"].Value.ToString();

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_T1_CIMG_HYT_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("ITEMNAME", itemName));

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
                helper.Close();
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
            //if (MessageBox.Show("장바구니에서 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo) == DialogResult.No) return;
            dgvCart.Rows.Remove(dgvCart.CurrentRow);
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button1_Click(null, null);
        }

        private void txtSearchItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "Logout", MessageBoxButtons.YesNo) == DialogResult.No) return;

            lbUserName.Text = "구매하려면 로그인하세요";
            lbUserName.Location = new Point(1210, 23);
            btnLogIn.Visible = true;
            btnLogOut.Visible = false;
            IdValidation = "FAIL";
            Common.signInId = "";
            Common.signInName = "";
            FM_LogIn.auth = "";
        }

    }
}
