using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DevForm
{
    public partial class FM_Item : Form
    {
        public FM_Item()
        {
            InitializeComponent();
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e) // SP_ITEM_HYT_S1
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                dgvItem.DataSource = null;

                string itemCode = txtItemCode.Text; 
                string itemName = txtItemName.Text; 
                string startStock= txtStart.Text; 
                string endStock = txtEnd.Text;
                if (startStock == string.Empty) startStock = "-100000000";
                if (endStock == string.Empty) endStock = "100000000";

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_T1_ITEM_HYT_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("ITEMCODE", itemCode)
                                , helper.CreateParameter("ITEMNAME", itemName)
                                , helper.CreateParameter("STARTSTOCK", startStock)
                                , helper.CreateParameter("ENDSTOCK", endStock));
                if (dtTemp.Rows.Count == 0)
                {
                    dgvItem.DataSource = null;
                    return;
                }
                dgvItem.DataSource = dtTemp;

                dgvItem.Columns["ITEMCODE"].HeaderText = "품목 코드";
                dgvItem.Columns["ITEMNAME"].HeaderText = "품목 명";
                dgvItem.Columns["STOCK"].HeaderText = "재고수량";
                dgvItem.Columns["MAKEDATE"].HeaderText = "등록 일시";
                dgvItem.Columns["MAKER"].HeaderText = "등록자";
                dgvItem.Columns["EDITDATE"].HeaderText = "수정일시";
                dgvItem.Columns["EDITOR"].HeaderText = "수정자";

                dgvItem.Columns[0].Width = 100;
                dgvItem.Columns[1].Width = 200;
                dgvItem.Columns[2].Width = 100;
                dgvItem.Columns[3].Width = 100;
                dgvItem.Columns[4].Width = 100;

                dgvItem.Columns["ITEMCODE"].ReadOnly = true;
                dgvItem.Columns["MAKER"].ReadOnly = true;
                dgvItem.Columns["MAKEDATE"].ReadOnly = true;
                dgvItem.Columns["EDITOR"].ReadOnly = true;
                dgvItem.Columns["EDITDATE"].ReadOnly = true;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvItem.Rows.Count == 0) return;

            DataRow dr = ((DataTable)dgvItem.DataSource).NewRow();
            ((DataTable)dgvItem.DataSource).Rows.Add(dr);
            dgvItem.Columns["ITEMCODE"].ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e) // SP_ITEM_HYT_U1
        {
            if (dgvItem.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 등록 하시겠습니까?", "데이터등록", MessageBoxButtons.YesNo) == DialogResult.No) return;

            string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
            string itemName = dgvItem.CurrentRow.Cells["ITEMNAME"].Value.ToString();
            string stock = dgvItem.CurrentRow.Cells["STOCK"].Value.ToString();

            DBHelper helper = new DBHelper(true);
            try
            {
                helper.ExecuteNoneQuery("SP_T1_ITEM_HYT_U1", CommandType.StoredProcedure
                                , helper.CreateParameter("ITEMNAME", itemName)
                                , helper.CreateParameter("ITEMCODE", itemCode)
                                , helper.CreateParameter("SIGNINID", Common.signInId)
                                , helper.CreateParameter("STOCK", stock));
                helper.Commit();
                MessageBox.Show("정상적으로 등록 하였습니다.");
            }
            catch(Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("데이터 등록에 실패하였습니다." + ex);
            }
            finally
            {
                helper.Close();
            }
            btnSearch_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e) // SP_ITEM_HYT_D1
        {
            if (this.dgvItem.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 삭제 하시겠습니까", "데이터삭제", MessageBoxButtons.YesNo)
                == DialogResult.No) return;

            DBHelper helper = new DBHelper(true);
            try
            {
                string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
                helper.ExecuteNoneQuery("SP_T1_ITEM_HYT_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("ITEMCODE", itemCode));

                helper.Commit();
                MessageBox.Show("정상적으로 삭제 하였습니다.");
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("데이터 삭제에 실패 하였습니다." + ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            try
            {
                string sImageFile = string.Empty;
                if (dgvItem.Rows.Count == 0) return;

                OpenFileDialog Dialog = new OpenFileDialog();
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    sImageFile = Dialog.FileName;
                    picImage.Tag = Dialog.FileName;
                }
                else return;
                picImage.Image = Bitmap.FromFile(sImageFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
        }

        private void btnPicSave_Click(object sender, EventArgs e) // SP_IIMG_HYT_U1
        {
            if (dgvItem.Rows.Count == 0) return;
            if (picImage.Image == null) return;
            if (picImage.Tag.ToString() == "") return;

            if (MessageBox.Show("선택된 이미지로 등록 하시겠습니까?", "이미지 등록", MessageBoxButtons.YesNo) == DialogResult.No) return;

            DBHelper helper = new DBHelper(true);
            try
            {
                FileStream stream = new FileStream(picImage.Tag.ToString(), FileMode.Open, FileAccess.Read);  // 읽어들일 파일을 바이너리 화 할 대상(FileStream) 으로 변경한다.
                BinaryReader reader = new BinaryReader(stream);                                               // 읽어들인 파일을 바이너리 코드로 객체를 생성 한다.
                Byte[] bImage = reader.ReadBytes(Convert.ToInt32(stream.Length));                             // 만들어진 바이너리 코드의 이미지를 Byte 화 하여 데이터 형식으로 저장 한다.
                reader.Close();                                                                               // 바이너리 리더를 종료한다.
                stream.Close();                                                                               // 스트림 리더를 종료한다.
                string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();

                helper.ExecuteNoneQuery("SP_T1_IIMG_HYT_U1", CommandType.StoredProcedure
                    , helper.CreateParameter("ITEMCODE", itemCode)
                    , helper.CreateParameter("ITEMIMG", bImage));
                helper.Commit();
                MessageBox.Show("정상적으로 등록 하였습니다.");
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
            finally
            {
                picImage.Image = null;
                helper.Close();
            }
        }

        private void btnPicDelete_Click(object sender, EventArgs e) // SP_IIMG_HYT_D1
        {
            if (dgvItem.Rows.Count == 0) return;
            if (MessageBox.Show("선택한 이미지를 삭제하시겠습니까?", "이미지삭제", MessageBoxButtons.YesNo) 
                == DialogResult.No) return;

            DBHelper helper = new DBHelper(true);
            try
            {
                string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
                helper.ExecuteNoneQuery("SP_T1_IIMG_HYT_D1", CommandType.StoredProcedure
                    , helper.CreateParameter("ITEMCODE", itemCode));
                helper.Commit();
                picImage.Image = null;
                MessageBox.Show("정상적으로 삭제 하였습니다.");
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
            finally
            {
                picImage.Image = null;
                helper.Close();
            }
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e) // SP_IIMG_HYT_S1
        {
            currentImage.Image = null;

            DBHelper helper = new DBHelper(false);
            try
            {
                string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_T1_IIMG_HYT_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("ITEMCODE", itemCode));

                if (dtTemp.Rows.Count == 0) return;

                byte[] bImage = null;
                bImage = (byte[])dtTemp.Rows[0]["ITEMIMG"];
                if (bImage != null)
                {
                    currentImage.Image = new Bitmap(new MemoryStream(bImage));
                    currentImage.BringToFront();
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
    }
}
