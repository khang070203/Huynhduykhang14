using Huynhduykhang14.Model;
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
    public partial class frmTourMienNam : Form
    {
        string matourmn;
        string nametourmn;
        string giatourmn;
        string ngaydimn;
        string ngayktmn;
        string ngaylapmn;
        public frmTourMienNam()
        {
            InitializeComponent();
        }

        private void frmTourMienNam_Load(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                List<TourMienNam> tourMN = context.TourMienNams.ToList();
                comboTourMienNam(tourMN);
                HienThiTourMN(tourMN);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboTourMienNam(List<TourMienNam> tourMN)
        {
            this.cmbTourMienNam.DataSource = tourMN;
            this.cmbTourMienNam.DisplayMember = "TenTourMienNam";
            this.cmbTourMienNam.ValueMember = "MaTourMienNam";
        }
        private void HienThiTourMN(List<TourMienNam> tourMN)
        {
            dgvViewTourMienNam.Rows.Clear();
            foreach (var item in tourMN)
            {
                int index = dgvViewTourMienNam.Rows.Add();
                dgvViewTourMienNam.Rows[index].Cells[0].Value = item.MaTourMienNam;
                dgvViewTourMienNam.Rows[index].Cells[1].Value = item.TenTourMienNam;
                dgvViewTourMienNam.Rows[index].Cells[2].Value = item.SoNguoiDiMienNam;
                dgvViewTourMienNam.Rows[index].Cells[3].Value = item.NgayDiMienNam;
                dgvViewTourMienNam.Rows[index].Cells[4].Value = item.NgayKetThucMienNam;
                dgvViewTourMienNam.Rows[index].Cells[5].Value = item.GiaTourMienNam;
            }
        }

        private void dgvViewTourMienNam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewTourMienNam.Rows.Count > 0 && e.RowIndex < dgvViewTourMienNam.RowCount - 1)
            {
                string tentourmn = dgvViewTourMienNam.Rows[e.RowIndex].Cells[1].Value.ToString();
                DuLichDB context = new DuLichDB();
                TourMienNam update = context.TourMienNams.FirstOrDefault(p => p.TenTourMienNam == tentourmn);
                matourmn = dgvViewTourMienNam.Rows[e.RowIndex].Cells[0].Value.ToString();
                nametourmn = dgvViewTourMienNam.Rows[e.RowIndex].Cells[1].Value.ToString();
                giatourmn = dgvViewTourMienNam.Rows[e.RowIndex].Cells[5].Value.ToString();
                ngaydimn = dgvViewTourMienNam.Rows[e.RowIndex].Cells[3].Value.ToString();
                ngayktmn = dgvViewTourMienNam.Rows[e.RowIndex].Cells[4].Value.ToString();
                ngaylapmn = DateTime.Now.ToString();

                if (update != null)
                {
                    cmbTourMienNam.Text = tentourmn;
                    nudSoNguoiDiMienNam.Text = (update.SoNguoiDiMienNam).ToString();
                    dtNgayDiMienNam.Text = (update.NgayDiMienNam).ToString();
                    dtNgayKTMienNam.Text = (update.NgayKetThucMienNam).ToString();
                    lblViewTenTour.Text = tentourmn;
                    lblGiaTourMN.Text = (update.GiaTourMienNam).ToString(); //từng sửa lblViewGiaTour.Text = (update.GiaTourTrongNuoc).ToString();
                    lblMaTourMN.Text = update.MaTourMienNam;
                    lblSoNgayMN.Text = (update.NgayDiMienNam).ToString();
                    lblKhoiHanhMN.Text = tentourmn;
                    lblSlotMN.Text = (update.SoNguoiDiMienNam).ToString();

                }
            }
        }

        private void btnLocketquaMienNam_Click(object sender, EventArgs e)
        {
            DuLichDB context = new DuLichDB();
            var listMN = context.TourMienNams.ToList().Where(o => o.TenTourMienNam == cmbTourMienNam.Text).ToList();
            lblSoLuongTourMienNam.Text = "Đã Tìm Thấy " + listMN.Count.ToString() + " Tour";
            HienThiTourMN(listMN);
        }

        private void btnResetMienNam_Click(object sender, EventArgs e)
        {
            DuLichDB context = new DuLichDB();
            List<TourMienNam> tourMN = context.TourMienNams.ToList();
            dgvViewTourMienNam.Rows.Clear();
            HienThiTourMN(tourMN);
            cmbTourMienNam.Text = "";
            nudSoNguoiDiMienNam.Value = 0;
            dtNgayDiMienNam.Value = DateTime.Now;
            dtNgayKTMienNam.Value = DateTime.Now;
            lblSoLuongTourMienNam.Text = "Đã tìm thấy 0 tour";
            lblViewTenTour.Text = "";
            lblGiaTourMN.Text = "";
            lblMaTourMN.Text = "";
            lblSoNgayMN.Text = "";
            lblKhoiHanhMN.Text = "";
            lblSlotMN.Text = "";
        }

        private void btnDatTourMN_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDonDatTour frmHD = new HoaDonDatTour(matourmn, nametourmn, giatourmn, ngaydimn, ngayktmn, ngaylapmn);
            frmHD.ShowDialog();
        }

        private void lblSoLuongTourMienNam_Click(object sender, EventArgs e)
        {

        }

        private void btnReturnMain_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chức năng này không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Hide();
                frmMain returnMain = new frmMain();
                returnMain.ShowDialog();
            }
        }

        private void pnlViewTenTourMienNam_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblGiaTourMN_Click(object sender, EventArgs e)
        {

        }

        private void pnlViewGiaTienMienNam_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }
    }
}
