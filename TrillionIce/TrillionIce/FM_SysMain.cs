using System;
using System.Reflection;
using System.Windows.Forms;
using DevForm;

namespace TrillionIce
{
    public partial class FM_SysMain : Form
    {
        public FM_SysMain()
        {
            InitializeComponent();
        }

        private void mSystem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Assembly Assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "DevForm.dll");
            Type TypeForm = Assemb.GetType("DevForm." + e.ClickedItem.Name.ToString(), true);
            Form ShowForm = (Form)Activator.CreateInstance(TypeForm);

            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == e.ClickedItem.Name.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }

            myTabControl1.AddForm(ShowForm);
        }

        private void stbItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == "FM_Item")
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }
            FM_Item itemForm = new FM_Item();
            myTabControl1.AddForm(itemForm);
        }

        private void stbOrder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == "FM_OrderConfirm")
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }
            FM_OrderConfirm orderForm = new FM_OrderConfirm();
            myTabControl1.AddForm(orderForm);
        }

        private void stbClose_Click(object sender, EventArgs e)
        {
            if (myTabControl1.TabPages.Count == 0) return;
            myTabControl1.SelectedTab.Dispose();
        }

        private void stbExit_Click(object sender, EventArgs e)
        {
            FM_CustMain.IdValidation = "FAIL";
            Close();
        }

        private void FM_SysMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM_CustMain.IdValidation = "FAIL";
        }
    }
    public partial class MDIForm : TabPage { }

    public partial class MyTabControl : TabControl
    {
        public void AddForm(Form NewForm)
        {
            if (NewForm == null) return;
            NewForm.TopLevel = false;      // 인자로 받은 폼이 최상위 개체가 아님을 선언

            MDIForm page = new MDIForm();
            page.Controls.Clear();         // 페이지 초기화
            page.Controls.Add(NewForm);    // 페이지에 폼 추가
            page.Text = NewForm.Text;      // 페이지의 이름 = 폼에서 지정한 이름
            page.Name = NewForm.Name;

            base.TabPages.Add(page);       // 탭 컨트롤에 페이지 추가
            NewForm.Show();                // 인자로 받은 폼 출력
            base.SelectedTab = page;       // 현재 선택된 페이지를 호출한 폼의 페이지로 실행
        }
    }
}
