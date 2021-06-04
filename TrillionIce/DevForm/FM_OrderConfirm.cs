using System;
using System.Data;
using System.Windows.Forms;

namespace DevForm
{
    public partial class FM_OrderConfirm : Form
    {
        public FM_OrderConfirm()
        {
            InitializeComponent();
        }
        public void Inquire() // SP_T1_ORDER_LHC_S1
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_T1_ORDER_LHC_S1", CommandType.StoredProcedure);

                if (dtTemp.Rows.Count == 0)
                {
                    dgvGrid.DataSource = null;
                    MessageBox.Show("주문 내역이 없습니다.");
                    return;
                }
                else
                {
                    dgvGrid.DataSource = dtTemp;
                }

                dgvGrid.Columns["USERID"].HeaderText = "고객 ID";
                dgvGrid.Columns["USERNAME"].HeaderText = "고객 이름";
                dgvGrid.Columns["ITEMNAME"].HeaderText = "품목";
                dgvGrid.Columns["QUANTITY"].HeaderText = "주문 수량";
                dgvGrid.Columns["ORDERDATE"].HeaderText = "주문 일시";
                dgvGrid.Columns["STOCK"].HeaderText = "재고";
                dgvGrid.Columns["ORDERSEQ"].HeaderText = "주문 번호";
                dgvGrid.Columns["ITEMCODE"].HeaderText = "품목 코드";

                dgvGrid.Columns["ITEMNAME"].Width = 120;
                dgvGrid.Columns[4].Width = 200;

                dgvGrid.Columns["USERID"].ReadOnly = true;
                dgvGrid.Columns["USERNAME"].ReadOnly = true;
                dgvGrid.Columns["ITEMNAME"].ReadOnly = true;
                dgvGrid.Columns["QUANTITY"].ReadOnly = true;
                dgvGrid.Columns["ORDERDATE"].ReadOnly = true;
                dgvGrid.Columns["STOCK"].ReadOnly = true;
                dgvGrid.Columns["ORDERSEQ"].ReadOnly = true;
                dgvGrid.Columns["ITEMCODE"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음과 같은 오류가 발생하였습니다 : " + ex);
            }
            finally
            {
                helper.Close();
            }
        }

        public void OrderCancel() // SP_T1_ORDER_LHC_D1
        {
            if (dgvGrid.Rows.Count == 0) return;
            if (MessageBox.Show("해당 구매 내역을 취소하시겠습니까?", "취소", MessageBoxButtons.YesNo)
                        == DialogResult.No) return;
            if (dgvGrid.SelectedRows.Count == 0) { MessageBox.Show("삭제할 열을 모두 선택해주세요."); return; }

            
            string orderSeq;
            string userID;
            string itemCode;
            string orderDate;


            DataTable dt = new DataTable();
            dt.Columns.Add("USERID");
            dt.Columns.Add("USERNAME");
            dt.Columns.Add("ITEMNAME");
            dt.Columns.Add("QUANTITY");
            dt.Columns.Add("ORDERDATE");
            dt.Columns.Add("STOCK");
            dt.Columns.Add("ORDERSEQ");
            dt.Columns.Add("ITEMCODE");

            DBHelper helper = new DBHelper(true);

            try
            {
                DataTable dtTemp = (DataTable)dgvGrid.DataSource;

                    foreach (DataGridViewRow row in dgvGrid.SelectedRows)
                    {
                    dt.Rows.Add(row);
                    orderSeq = row.Cells["ORDERSEQ"].Value.ToString();    //선택된 열
                    userID = row.Cells["USERID"].Value.ToString();        //선택된 열
                    itemCode = row.Cells["ITEMCODE"].Value.ToString();    //선택된 열
                    orderDate = row.Cells["ORDERDATE"].Value.ToString();  //선택된 열

                    for (int i = dtTemp.Rows.Count - 1; i >=  0; i--)
                    {
                        if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;  //지워진 상태이면 다음 행으로
                        if (dtTemp.Rows[i]["ORDERSEQ"].ToString() == orderSeq &&
                            dtTemp.Rows[i]["USERID"].ToString() == userID &&
                            dtTemp.Rows[i]["ITEMCODE"].ToString() == itemCode &&
                            dtTemp.Rows[i]["ORDERDATE"].ToString() == orderDate)        //선택된 셀의 UserID와 같으면
                        {
                            dtTemp.Rows[i].Delete();
                            break;
                        }
                    }
                    DataTable dtTempChange = (DataTable)dgvGrid.DataSource;
                    if (dtTempChange == null) return;

                
                
                        foreach (DataRow drRow in dtTempChange.Rows)
                        {
                            if (drRow.RowState == DataRowState.Deleted)
                            {
                                drRow.RejectChanges();
                                userID = drRow["USERID"].ToString();
                                itemCode = drRow["ITEMCODE"].ToString();
                                orderSeq = drRow["ORDERSEQ"].ToString();
                                orderDate = drRow["ORDERDATE"].ToString();

                                helper.ExecuteNoneQuery("SP_T1_ORDER_LHC_D1",
                                    CommandType.StoredProcedure, helper.CreateParameter("USERID", userID)
                                    , helper.CreateParameter("ITEMCODE", itemCode)
                                    , helper.CreateParameter("ORDERSEQ", orderSeq)
                                    , helper.CreateParameter("ORDERDATE", orderDate));

                            }
                        }
                    }
                helper.Commit();
                MessageBox.Show("정상적으로 취소하였습니다.");
                Inquire();

            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("주문 취소에 실패하였습니다." + ex);
            }
            finally
            {
                helper.Close();
            }
        }

        public void OrderConfirm() // SP_T1_ORDER_LHC_U1
        {
            if (dgvGrid.Rows.Count == 0) return;
            if (MessageBox.Show("해당 구매 내역을 확정하시겠습니까?", "확정", MessageBoxButtons.YesNo)
            == DialogResult.No) return;
            if (dgvGrid.SelectedRows.Count == 0) { MessageBox.Show("주문 확정할 열을 모두 선택해주세요."); return; }

            string orderSeq;
            string userID;
            string itemCode;
            string orderDate;


            DataTable dt = new DataTable();
            dt.Columns.Add("USERID");
            dt.Columns.Add("USERNAME");
            dt.Columns.Add("ITEMNAME");
            dt.Columns.Add("QUANTITY");
            dt.Columns.Add("ORDERDATE");
            dt.Columns.Add("STOCK");
            dt.Columns.Add("ORDERSEQ");
            dt.Columns.Add("ITEMCODE");

            DBHelper helper = new DBHelper(true);
            try
            {
                foreach (DataGridViewRow row in dgvGrid.SelectedRows)
                {
                    dt.Rows.Add(row);
                    orderSeq = row.Cells["ORDERSEQ"].Value.ToString();    //선택된 열
                    userID = row.Cells["USERID"].Value.ToString();        //선택된 열
                    itemCode = row.Cells["ITEMCODE"].Value.ToString();    //선택된 열
                    orderDate = row.Cells["ORDERDATE"].Value.ToString();  //선택된 열

                    DataTable dtTemp = (DataTable)dgvGrid.DataSource;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue; //지워진 상태이면 다음 행으로
                    if (dtTemp.Rows[i]["ORDERSEQ"].ToString() == orderSeq &&
                        dtTemp.Rows[i]["USERID"].ToString() == userID &&
                        dtTemp.Rows[i]["ITEMCODE"].ToString() == itemCode &&
                        dtTemp.Rows[i]["ORDERDATE"].ToString() == orderDate)
                    {
                        dtTemp.Rows[i].Delete();
                        break;
                    }
                }
                int quantity;
                DataTable dtTempChange = (DataTable)dgvGrid.DataSource;
                if (dtTempChange == null) return;
                        foreach (DataRow drRow in dtTempChange.Rows)
                        {
                            if (drRow.RowState == DataRowState.Deleted)
                            {
                                drRow.RejectChanges();
                                userID = drRow["USERID"].ToString();
                                itemCode = drRow["ITEMCODE"].ToString();
                                orderSeq = drRow["ORDERSEQ"].ToString();
                                orderDate = drRow["ORDERDATE"].ToString();
                                quantity = int.Parse(drRow["QUANTITY"].ToString());
                                helper.ExecuteNoneQuery("SP_T1_ORDER_LHC_U1", CommandType.StoredProcedure
                                    , helper.CreateParameter("USERID", userID)
                                    , helper.CreateParameter("ITEMCODE", itemCode)
                                    , helper.CreateParameter("ORDERSEQ", orderSeq)
                                    , helper.CreateParameter("ORDERDATE", orderDate)
                                    , helper.CreateParameter("QUANTITY", quantity));
                            }
                        }
                }
                helper.Commit();
                MessageBox.Show("정상적으로 반영하였습니다.");
                Inquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("주문 확정에 실패하였습니다." + ex);
            }
            finally
            {
                helper.Close();
            }
        }

        private void FM_OrderConfirm_Load(object sender, EventArgs e)
        {
            Inquire();
        }

        private void btnOrderConfirm_Click(object sender, EventArgs e)
        {
            OrderConfirm();
        }

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            OrderCancel();
        }
    }
}
