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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {

        }
        private Form actForm = null;

        private void openView(Form View)
        {
            if (actForm != null)
                actForm.Close();
            actForm = View;
            View.TopLevel = false;
            View.FormBorderStyle = FormBorderStyle.None;
            View.Dock = DockStyle.Fill;
            pnlView.Controls.Add(View);
            pnlView.Tag = View;
            View.BringToFront();
            View.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        private void btnMienBac_Click(object sender, EventArgs e)
        {
            pnlView.Size = new Size(1101, 442);
            this.Size = new Size(1143, 708);

            this.Hide();
            frmTourMienBac tourTN = new frmTourMienBac();

            tourTN.ShowDialog();
        }

        private void btnMienTrung_Click(object sender, EventArgs e)
        {
            pnlView.Size = new Size(1101, 442);
            this.Size = new Size(1143, 708);

            this.Hide();
            frmTourMienTrung tourTN = new frmTourMienTrung();

            tourTN.ShowDialog();
        }

        private void btnMienNam_Click(object sender, EventArgs e)
        {
            pnlView.Size = new Size(1101, 442);
            this.Size = new Size(1143, 708);

            this.Hide();
            frmTourMienNam tourTN = new frmTourMienNam();

            tourTN.ShowDialog();
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuanLyThongTin_Click(object sender, EventArgs e)
        {
            pnlView.Size = new Size(970, 640);
            this.Size = new Size(980, 785);

            this.Hide();
            QuanLy ql = new QuanLy();

            ql.ShowDialog();
        }

        private void btnTourNuocNgoai_Click(object sender, EventArgs e)
        {
            pnlView.Size = new Size(980, 785);
            this.Size = new Size(1218, 933);

            this.Hide();
            frmTourNgoaiNuoc tourNN = new frmTourNgoaiNuoc();

            tourNN.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Size = new Size(970, 640);
            pnlView.Size = new Size(980, 785);

            openView(new frmTrangChu());
        }
    }
}
