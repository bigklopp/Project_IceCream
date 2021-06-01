using System;
using System.Data;
using System.Windows.Forms;
using DevForm;

namespace TrillionIce
{
    public partial class FM_Order : Form
    {
        public FM_Order()
        {
            InitializeComponent();
            dgvCart.DataSource = FM_CustMain.cartData;
        }

        public void Pay()
        {
            if (dgvCart.Rows.Count == 0) return;
            if (MessageBox.Show("결제하시겠습니까?", "결제", MessageBoxButtons.YesNo)
            == DialogResult.No) return;

            DataTable dtTemp = (DataTable)dgvCart.DataSource;
            if (dtTemp == null) return;
            DBHelper helper = new DBHelper(true);
            DataTable cartData = new DataTable();
            cartData = (DataTable)dgvCart.DataSource;

            try
            {
                for( int i = 0; i < dtTemp.Rows.Count; i++)
                {
                if (dtTemp.Rows[i] == null) return;
                string userId = Common.signInId;
                string columnName = dgvCart.Rows[i].Cells["ITEMNAME"].Value.ToString();
                int quantity = int.Parse(dgvCart.Rows[i].Cells["QUANTITY"].Value.ToString());
                dtTemp.Rows[i].RejectChanges();
                helper.ExecuteNoneQuery("SP_ORDER_LHC_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("USERID", userId)
                    , helper.CreateParameter("QUANTITY", quantity)
                    , helper.CreateParameter("ITEMNAME", columnName));
                }
                // 성공 시 DB Commit
                helper.Commit();
                // 메세지
                MessageBox.Show("정상적으로 주문되었습니다.");
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("주문에 실패하였습니다." + ex);
            }
            finally
            {
                helper.Close();
            }
            Close();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Pay();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
