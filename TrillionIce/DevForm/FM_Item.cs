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
        private SqlConnection Connect = null;
        private string strConn = Common.db;
        
        public FM_Item()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvItem.DataSource = null; // 그리드의 데이터 소스를 초기화 한다.
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                // 조회를 위한 파라매터 설정
                string itemCode = txtItemCode.Text;  // 품목 코드
                string itemName = txtItemName.Text;  // 품목 명
                string startStock= txtStart.Text;     // 재고수량  
                string endStock = txtEnd.Text;       // 재고수량

                string Sql = "SELECT ITEMCODE,  " +
                             "       ITEMNAME,  " +
                             "       MAKEDATE,  " +
                             "       MAKER,     " +
                             "       EDITDATE,  " +
                             "       EDITOR     " +
                             "  FROM TB_1_ITEM WITH(NOLOCK) " +
                             " WHERE ITEMCODE LIKE '%" + itemCode + "%' " +
                             "   AND ITEMNAME LIKE '%" + itemName + "%' ";

                SqlDataAdapter Adapter = new SqlDataAdapter(Sql, Connect);

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    dgvItem.DataSource = null;
                    return;
                }
                dgvItem.DataSource = dtTemp; // 데이터 그리드 뷰에 데이터 테이블 등록

                // 그리드뷰의 헤더 명칭 선언
                dgvItem.Columns["ITEMCODE"].HeaderText = "품목 코드";
                dgvItem.Columns["ITEMNAME"].HeaderText = "품목 명";
                dgvItem.Columns["MAKEDATE"].HeaderText = "등록 일시";
                dgvItem.Columns["MAKER"].HeaderText = "등록자";
                dgvItem.Columns["EDITDATE"].HeaderText = "수정일시";
                dgvItem.Columns["EDITOR"].HeaderText = "수정자";

                // 그리드 뷰의 폭 지정
                dgvItem.Columns[0].Width = 100;
                dgvItem.Columns[1].Width = 100;
                dgvItem.Columns[2].Width = 100;
                dgvItem.Columns[3].Width = 100;
                dgvItem.Columns[4].Width = 100;

                // 컬럼의 수정 여부를 지정 한다
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
            { Connect.Close();}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvItem.Rows.Count == 0) return;

            // 데이터 그리드 뷰 에 신규 행 추가
            DataRow dr = ((DataTable)dgvItem.DataSource).NewRow();
            ((DataTable)dgvItem.DataSource).Rows.Add(dr);
            dgvItem.Columns["ITEMCODE"].ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 선택된 행 데이터 저장 
            if (dgvItem.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 등록 하시겠습니까?", "데이터등록", MessageBoxButtons.YesNo) == DialogResult.No) return;

            string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
            string itemName = dgvItem.CurrentRow.Cells["ITEMNAME"].Value.ToString();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction Tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();
            Tran = Connect.BeginTransaction("TestTran");
            cmd.Transaction = Tran;
            cmd.Connection = Connect;

            cmd.CommandText = "UPDATE TB_1_ITEM                         " +
                              "    SET ITEMNAME  = '" + itemName + "',   " +
                              "        EDITOR = '" + Common.signInId + "',  " +
                              "        EDITDATE = GETDATE()          " +
                              "  WHERE ITEMCODE = '" + itemCode + "'" +
                              " IF (@@ROWCOUNT =0) " +
                              "INSERT INTO TB_1_ITEM(ITEMCODE,  ITEMNAME,   MAKEDATE,   MAKER) " +
                              "VALUES('" + itemCode + "','" + itemName + "'," +  "GETDATE(), '" + Common.signInId + "')";

            cmd.ExecuteNonQuery();

            // 성공 시 DB COMMIT
            Tran.Commit();
            MessageBox.Show("정상적으로 등록 하였습니다.");
            Connect.Close();

            btnSearch_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 선택된 행을 삭제 한다.
            if (this.dgvItem.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 삭제 하시겠습니까", "데이터삭제", MessageBoxButtons.YesNo)
                == DialogResult.No) return;

            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            // 트랜잭션 관리를 위한 권한 위임 
            tran = Connect.BeginTransaction("TranStart");
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            try
            {
                string Itemcode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
                cmd.CommandText = "DELETE TB_1_ITEM WHERE ITEMCODE = '" + Itemcode + "'";

                cmd.ExecuteNonQuery();

                // 성공 시 DB Commit
                tran.Commit();
                MessageBox.Show("정상적으로 삭제 하였습니다.");
                btnSearch_Click(null, null); // 데이터 재조회
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("데이터 삭제에 실패 하였습니다." + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            try
            {
                string sImageFile = string.Empty;
                // 이미지 불러오기 및 저장. 파일 탐색기 호출. 
                if (dgvItem.Rows.Count == 0) return;

                OpenFileDialog Dialog = new OpenFileDialog();
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    sImageFile = Dialog.FileName;
                    picImage.Tag = Dialog.FileName;
                }
                else return;
                picImage.Image = Bitmap.FromFile(sImageFile);  // 지정된 파일에서 System.Drawing.Image를 만든다.
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
        }

        private void btnPicSave_Click(object sender, EventArgs e)
        {
            // 픽처박스의 이미지 저장. 
            if (dgvItem.Rows.Count == 0) return;
            if (picImage.Image == null) return;
            if (picImage.Tag.ToString() == "") return;

            if (MessageBox.Show("선택된 이미지로 등록 하시겠습니까?", "이미지 등록", MessageBoxButtons.YesNo) == DialogResult.No) return;

            Byte[] bImage = null;
            Connect = new SqlConnection(strConn);

            try
            {
                FileStream stream = new FileStream(picImage.Tag.ToString(), FileMode.Open, FileAccess.Read);  // 읽어들일 파일을 바이너리 화 할 대상(FileStream) 으로 변경한다.
                BinaryReader reader = new BinaryReader(stream);                                                   // 읽어들인 파일을 바이너리 코드로 객체를 생성 한다.
                bImage = reader.ReadBytes(Convert.ToInt32(stream.Length));                                        // 만들어진 바이너리 코드의 이미지를 Byte 화 하여 데이터 형식으로 저장 한다.
                reader.Close();                                                                                   // 바이너리 리더를 종료한다.
                stream.Close();                                                                                   // 스트림 리더를 종료한다.

                SqlCommand cmd = new SqlCommand();                            

                cmd.Connection = Connect;
                Connect.Open();

                string sItemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
                cmd.CommandText = "UPDATE  TB_1_ITEM SET ITEMIMG = @Image WHERE ITEMCODE = @ItemCode";
                cmd.Parameters.AddWithValue("@Image", bImage);
                cmd.Parameters.AddWithValue("@ItemCode", sItemCode);

                cmd.ExecuteNonQuery();
                MessageBox.Show("정상적으로 등록 하였습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }

        }

        private void btnPicDelete_Click(object sender, EventArgs e)
        {
            // 품목에 저장된 이미지 삭제
            if (dgvItem.Rows.Count == 0) return;
            if (MessageBox.Show("선택한 이미지를 삭제하시겠습니까?",
                "이미지삭제", MessageBoxButtons.YesNo) == DialogResult.No) return;

            SqlCommand cmd = new SqlCommand();
            Connect = new SqlConnection(strConn);
            Connect.Open();

            try
            {
                string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
                cmd.CommandText = "UPDATE TB_1_ITEM SET ITEMIMG = null WHERE ITEMCODE = '"
                                  + itemCode + "'";
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
                picImage.Image = null;
                MessageBox.Show("정상적으로 삭제 하였습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
            finally
            {Connect.Close();}
        }

        private void dgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택 시 해당품목 이미지 가져오기.
            string itemCode = dgvItem.CurrentRow.Cells["ITEMCODE"].Value.ToString();
            Connect = new SqlConnection(strConn);
            Connect.Open();
            try
            {
                // 이미지 초기화
                picImage.Image = null;
                string sSql = "SELECT ITEMIMG FROM TB_1_ITEM WHERE ITEMCODE = '" + itemCode
                              + "' AND ITEMIMG IS NOT NULL";
                SqlDataAdapter Adapter = new SqlDataAdapter(sSql, Connect);
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
                Connect.Close();
            }

        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string itemName = dgvItem.CurrentRow.Cells["ITEMNAME"].Value.ToString();

            try
            {
                // 이미지 초기화
                currentImage.Image = null;
                string Sql = "SELECT ITEMIMG FROM TB_1_ITEM WHERE ITEMNAME = '" + itemName
                              + "' AND ITEMIMG IS NOT NULL";
                SqlDataAdapter Adapter = new SqlDataAdapter(Sql, Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0) return;

                byte[] bImage = null;
                bImage = (byte[])dtTemp.Rows[0]["ITEMIMG"]; // 이미지를 byte 화 한다.
                if (bImage != null)
                {
                    currentImage.Image = new Bitmap(new MemoryStream(bImage)); // 메모리 스트림을 이용하여 파일을 그림 파일로 만든다.
                    currentImage.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("다음과 같은 에러가 발생하였습니다 : " + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }
    }
}
