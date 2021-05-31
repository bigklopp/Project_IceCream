using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrillionIce
{
    public partial class FM_CustMain : Form
    {
        public static string IdValidation = "FAIL";
        public static DataTable cartData = new DataTable();
        public FM_CustMain()
        {
            InitializeComponent();
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
            dgvCart.DataSource = cartData;
        }
    }
}
