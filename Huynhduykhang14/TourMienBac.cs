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
    public partial class frmTourMienBac : Form
    {

        string matourmb;
        string nametourmb;
        string giatourmb;
        string ngaydimb;
        string ngayktmb;
        string ngaylapmb;

        public frmTourMienBac()
        {
            InitializeComponent();
        }

        private void frmTourMienBac_Load(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                List<TourMienBac> tourMB = context.TourMienBacs.ToList();
                comboTourMienBac(tourMB);
                HienThiTourMB(tourMB);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboTourMienBac(List<TourMienBac> tourMB)
        {
            this.cmbTourMienBac.DataSource = tourMB;
            this.cmbTourMienBac.DisplayMember = "TenTourMienBac";
            this.cmbTourMienBac.ValueMember = "MaTourMienBac";
        }

        private void HienThiTourMB(List<TourMienBac> tourMB)
        {
            dgvViewTourMienBac.Rows.Clear();
            foreach (var item in tourMB)
            {
                int index = dgvViewTourMienBac.Rows.Add();
                dgvViewTourMienBac.Rows[index].Cells[0].Value = item.MaTourMienBac;
                dgvViewTourMienBac.Rows[index].Cells[1].Value = item.TenTourMienBac;
                dgvViewTourMienBac.Rows[index].Cells[2].Value = item.SoNguoiDiMienBac;
                dgvViewTourMienBac.Rows[index].Cells[3].Value = item.NgayDiMienBac;
                dgvViewTourMienBac.Rows[index].Cells[4].Value = item.NgayKetThucMienBac;
                dgvViewTourMienBac.Rows[index].Cells[5].Value = item.GiaTourMienBac;
            }
        }

        private void dgvViewTourMienBac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewTourMienBac.Rows.Count > 0 && e.RowIndex < dgvViewTourMienBac.RowCount - 1)
            {
                string tentourmb = dgvViewTourMienBac.Rows[e.RowIndex].Cells[1].Value.ToString();
                DuLichDB context = new DuLichDB();
                TourMienBac update = context.TourMienBacs.FirstOrDefault(p => p.TenTourMienBac == tentourmb);
                matourmb = dgvViewTourMienBac.Rows[e.RowIndex].Cells[0].Value.ToString();
                nametourmb = dgvViewTourMienBac.Rows[e.RowIndex].Cells[1].Value.ToString();
                giatourmb = dgvViewTourMienBac.Rows[e.RowIndex].Cells[5].Value.ToString();
                ngaydimb = dgvViewTourMienBac.Rows[e.RowIndex].Cells[3].Value.ToString();
                ngayktmb = dgvViewTourMienBac.Rows[e.RowIndex].Cells[4].Value.ToString();
                ngaylapmb = DateTime.Now.ToString();

                if (update != null)
                {
                    cmbTourMienBac.Text = tentourmb;
                    nudSoNguoiDiMienBac.Text = (update.SoNguoiDiMienBac).ToString();
                    dtNgayDiMienBac.Text = (update.NgayDiMienBac).ToString();
                    dtNgayKTMienBac.Text = (update.NgayKetThucMienBac).ToString();
                    lblViewTenTour.Text = tentourmb;
                    lblGiaTourMB.Text = (update.GiaTourMienBac).ToString(); //từng sửa lblViewGiaTour.Text = (update.GiaTourTrongNuoc).ToString();
                    lblMaTourMB.Text = update.MaTourMienBac;
                    lblSoNgayMB.Text = (update.NgayDiMienBac).ToString();
                    lblKhoiHanhMB.Text = tentourmb;
                    lblSlotMB.Text = (update.SoNguoiDiMienBac).ToString();

                }
            }
        }

        private void btnResetMienBac_Click(object sender, EventArgs e)
        {
            DuLichDB context = new DuLichDB();
            List<TourMienBac> tourMB = context.TourMienBacs.ToList();
            dgvViewTourMienBac.Rows.Clear();
            HienThiTourMB(tourMB);
            cmbTourMienBac.Text = "";
            nudSoNguoiDiMienBac.Value = 0;
            dtNgayDiMienBac.Value = DateTime.Now;
            dtNgayKTMienBac.Value = DateTime.Now;
            lblSoLuongTourMienBac.Text = "Đã tìm thấy 0 tour";
            lblViewTenTour.Text = "";
            lblGiaTourMB.Text = "";
            lblMaTourMB.Text = "";
            lblSoNgayMB.Text = "";
            lblKhoiHanhMB.Text = "";
            lblSlotMB.Text = "";
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

        private void btnLocketquaMienBac_Click(object sender, EventArgs e)
        {
            DuLichDB context = new DuLichDB();
            var listMB = context.TourMienBacs.ToList().Where(o => o.TenTourMienBac == cmbTourMienBac.Text).ToList();
            lblSoLuongTourMienBac.Text = "Đã Tìm Thấy " + listMB.Count.ToString() + " Tour";
            HienThiTourMB(listMB);
        }

        private void btnDatTourMB_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDonDatTour frmHD = new HoaDonDatTour(matourmb, nametourmb, giatourmb, ngaydimb, ngayktmb, ngaylapmb);
            frmHD.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblSlotMB_Click(object sender, EventArgs e)
        {

        }

        private void lblSoNgayMB_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblKhoiHanhMB_Click(object sender, EventArgs e)
        {

        }

        private void lblMaTourMB_Click(object sender, EventArgs e)
        {

        }

        private void nudSoNguoiDiMienBac_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
