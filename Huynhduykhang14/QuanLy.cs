using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huynhduykhang14
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private Form actFormQL = null;

        private void openViewQL(Form View)
        {
            if (actFormQL != null)
                actFormQL.Close();
            actFormQL = View;
            View.TopLevel = false;
            View.FormBorderStyle = FormBorderStyle.None;
            View.Dock = DockStyle.Fill;
            pnlViewQL.Controls.Add(View);
            pnlViewQL.Tag = View;
            View.BringToFront();
            View.Show();
        }

     

        private void btnQLTour_Click(object sender, EventArgs e)
        {
           // this.Size = new Size(1150, 950);
          //  pnlViewQL.Size = new Size(1110, 950);
            openViewQL(new QuanLyTourTrongNuoc());
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {

        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
           // this.Size = new Size(1150, 950);
           // pnlViewQL.Size = new Size(1110, 950);


           
            openViewQL(new QuanLyNhanVien());
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
           // this.Size = new Size(1150, 950);
          //  pnlViewQL.Size = new Size(1110, 950);


            
            openViewQL(new QuanLyKhachHang());
        }

        private void pnlViewQL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLTour1_Click(object sender, EventArgs e)
        {
          //  this.Size = new Size(1150, 950);
          //  pnlViewQL.Size = new Size(1110, 950);


            

            openViewQL(new QuanLyTourNuocNgoai());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chức năng này không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmMain returnMain = new frmMain();
                returnMain.ShowDialog();
            }
        }
    }
}
