using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /*public void Inquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_ORDER_LHC_S1", CommandType.StoredProcedure);

                if (dtTemp.Rows.Count == 0)
                {
                    dgvCart.DataSource = null;
                    MessageBox.Show("조회할 데이터가 없습니다.");
                }
                else
                {
                    dgvCart.DataSource = dtTemp;
                }



                dgvCart.Columns["USERID"].HeaderText = "고객 ID";
                dgvCart.Columns["USERNAME"].HeaderText = "고객 이름";
                dgvCart.Columns["columnName"].HeaderText = "품목";
                dgvCart.Columns["QUANTITY"].HeaderText = "주문 수량";
                dgvCart.Columns["ORDERDATE"].HeaderText = "주문 일시";
                dgvCart.Columns["STOCK"].HeaderText = "재고";
                dgvCart.Columns["ORDERSEQ"].HeaderText = "주문 번호";
                dgvCart.Columns["ITEMCODE"].HeaderText = "품목 코드";

                dgvCart.Columns[4].Width = 200;

                // 컬럼의 수정 여부를 지정한다. 
                dgvCart.Columns["USERID"].ReadOnly = true;
                dgvCart.Columns["USERNAME"].ReadOnly = true;
                dgvCart.Columns["columnName"].ReadOnly = true;
                dgvCart.Columns["QUANTITY"].ReadOnly = true;
                dgvCart.Columns["ORDERDATE"].ReadOnly = true;
                dgvCart.Columns["STOCK"].ReadOnly = true;
                dgvCart.Columns["ORDERSEQ"].ReadOnly = true;
                dgvCart.Columns["ITEMCODE"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("예외 발생" + ex);
            }
            finally
            {
                helper.Close();
            }

        }*/

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
