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
    public partial class FM_Order : Form
    {
        public FM_Order()
        {
            InitializeComponent();
            dgvCart.DataSource = FM_CustMain.cartData;
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
