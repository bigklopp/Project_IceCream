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
        public FM_CustMain()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            FM_LogIn LogIn = new FM_LogIn();
            LogIn.ShowDialog();
            string IdValidation = LogIn.Tag.ToString();
            if (IdValidation == "FAIL")
            {
                Environment.Exit(0);
            }
            lbUserName.Text = $"{IdValidation}님, 환영합니다!";
        }
    }
}
