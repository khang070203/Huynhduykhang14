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
    public partial class frmTourMienTrung : Form
    {
        string matourmt;
        string nametourmt;
        string giatourmt;
        string ngaydimt;
        string ngayktmt;
        string ngaylapmt;
        public frmTourMienTrung()
        {
            InitializeComponent();
        }

        private void TourMienTrung_Load(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                List<TourMienTrung> tourMT = context.TourMienTrungs.ToList();
                comboTourMienTrung(tourMT);
                HienThiTourMT(tourMT);
                //loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboTourMienTrung(List<TourMienTrung> tourMT)
        {
            this.cmbTourMienTrung.DataSource = tourMT;
            this.cmbTourMienTrung.DisplayMember = "TenTourMienTrung";
            this.cmbTourMienTrung.ValueMember = "MaTourMienTrung";
        }

        private void HienThiTourMT(List<TourMienTrung> tourMT)
        {
            dgvViewTourMienTrung.Rows.Clear();
            foreach (var item in tourMT)
            {
                int index = dgvViewTourMienTrung.Rows.Add();
                dgvViewTourMienTrung.Rows[index].Cells[0].Value = item.MaTourMienTrung;
                dgvViewTourMienTrung.Rows[index].Cells[1].Value = item.TenTourMienTrung;
                dgvViewTourMienTrung.Rows[index].Cells[2].Value = item.SoNguoiDiMienTrung;
                dgvViewTourMienTrung.Rows[index].Cells[3].Value = item.NgayDiMienTrung;
                dgvViewTourMienTrung.Rows[index].Cells[4].Value = item.NgayKetThucMienTrung;
                dgvViewTourMienTrung.Rows[index].Cells[5].Value = item.GiaTourMienTrung;
            }
        }

        private void cmbTourMienTrung_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dtNgayDiMienTrung_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvViewTourMienTrung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvViewTourMienTrung_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvViewTourMienTrung.Rows.Count > 0 && e.RowIndex < dgvViewTourMienTrung.RowCount - 1)
            {
                string tentourmt = dgvViewTourMienTrung.Rows[e.RowIndex].Cells[1].Value.ToString();
                DuLichDB context = new DuLichDB();
                TourMienTrung update = context.TourMienTrungs.FirstOrDefault(p => p.TenTourMienTrung == tentourmt);
                matourmt = dgvViewTourMienTrung.Rows[e.RowIndex].Cells[0].Value.ToString();
                nametourmt = dgvViewTourMienTrung.Rows[e.RowIndex].Cells[1].Value.ToString();
                giatourmt = dgvViewTourMienTrung.Rows[e.RowIndex].Cells[5].Value.ToString();
                ngaydimt = dgvViewTourMienTrung.Rows[e.RowIndex].Cells[3].Value.ToString();
                ngayktmt = dgvViewTourMienTrung.Rows[e.RowIndex].Cells[4].Value.ToString();
                ngaylapmt = DateTime.Now.ToString();
                
                if (update != null)
                {
                    cmbTourMienTrung.Text = tentourmt;
                    nudSoNguoiDiMienTrung.Text = (update.SoNguoiDiMienTrung).ToString();
                    dtNgayDiMienTrung.Text = (update.NgayDiMienTrung).ToString();
                    dtNgayKTMienTrung.Text = (update.NgayKetThucMienTrung).ToString();
                    lblViewTenTour.Text = tentourmt;
                    lblGiaTourMT.Text = (update.GiaTourMienTrung).ToString(); //từng sửa lblViewGiaTour.Text = (update.GiaTourTrongNuoc).ToString();
                    lblMaTourMT.Text = update.MaTourMienTrung;
                    lblSoNgayMT.Text = (update.NgayDiMienTrung).ToString();
                    lblKhoiHanhMT.Text = tentourmt;
                    lblSlotMT.Text = (update.SoNguoiDiMienTrung).ToString();
                    
                }
            }
        }

        private void btnLocketquaMienTrung_Click(object sender, EventArgs e)
        {
            DuLichDB context = new DuLichDB();
            var listMT = context.TourMienTrungs.ToList().Where(o => o.TenTourMienTrung == cmbTourMienTrung.Text).ToList();
            lblSoLuongTourMienTrung.Text = "Đã Tìm Thấy " + listMT.Count.ToString() + " Tour";
            HienThiTourMT(listMT);
        }

        private void btnResetMienTrung_Click(object sender, EventArgs e)
        {
            DuLichDB context = new DuLichDB();
            List<TourMienTrung> tourMT = context.TourMienTrungs.ToList();
            dgvViewTourMienTrung.Rows.Clear();
            HienThiTourMT(tourMT);
            cmbTourMienTrung.Text = "";
            nudSoNguoiDiMienTrung.Value = 0;
            dtNgayDiMienTrung.Value = DateTime.Now;
            dtNgayKTMienTrung.Value = DateTime.Now;
            lblSoLuongTourMienTrung.Text = "Đã tìm thấy 0 tour";
            lblViewTenTour.Text = "";
            lblGiaTourMT.Text = "";
            lblMaTourMT.Text = "";
            lblSoNgayMT.Text = "";
            lblKhoiHanhMT.Text = "";
            lblSlotMT.Text = "";
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

        private void btnDatTourMT_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDonDatTour frmHD = new HoaDonDatTour(matourmt, nametourmt, giatourmt, ngaydimt, ngayktmt, ngaylapmt);
            frmHD.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblSlotMT_Click(object sender, EventArgs e)
        {

        }

        private void lblSoNgayMT_Click(object sender, EventArgs e)
        {

        }

        private void lblKhoiHanhMT_Click(object sender, EventArgs e)
        {

        }

        private void lblMaTourMT_Click(object sender, EventArgs e)
        {

        }

        private void dtNgayKTMienTrung_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
