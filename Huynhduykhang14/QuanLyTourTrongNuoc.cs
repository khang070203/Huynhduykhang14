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
    public partial class QuanLyTourTrongNuoc : Form
    {
        public QuanLyTourTrongNuoc()
        {
            InitializeComponent();
        }

        private void QuanLyTourTrongNuoc_Load(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                List<TourMienBac> tourMB = context.TourMienBacs.ToList();
                List<TourMienTrung> tourMT = context.TourMienTrungs.ToList();
                List<TourMienNam> tourMN = context.TourMienNams.ToList();
                HienThiTourMB(tourMB);
                HienThiTourMT(tourMT);
                HienThiTourMN(tourMN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HienThiTourMB(List<TourMienBac> tourMB)
        {
            dgvQLTourMienBac.Rows.Clear();
            foreach (var item in tourMB)
            {
                int index = dgvQLTourMienBac.Rows.Add();
                dgvQLTourMienBac.Rows[index].Cells[0].Value = item.MaTourMienBac;
                dgvQLTourMienBac.Rows[index].Cells[1].Value = item.TenTourMienBac;
                dgvQLTourMienBac.Rows[index].Cells[2].Value = item.NgayDiMienBac;
                dgvQLTourMienBac.Rows[index].Cells[3].Value = item.NgayKetThucMienBac;
                dgvQLTourMienBac.Rows[index].Cells[4].Value = item.GiaTourMienBac;
                dgvQLTourMienBac.Rows[index].Cells[5].Value = item.SoNguoiDiMienBac;
            }
        }
        private void HienThiTourMT(List<TourMienTrung> tourMT)
        {
            dgvQLTourMienTrung.Rows.Clear();
            foreach (var item in tourMT)
            {
                int index = dgvQLTourMienTrung.Rows.Add();
                dgvQLTourMienTrung.Rows[index].Cells[0].Value = item.MaTourMienTrung;
                dgvQLTourMienTrung.Rows[index].Cells[1].Value = item.TenTourMienTrung;
                dgvQLTourMienTrung.Rows[index].Cells[2].Value = item.NgayDiMienTrung;
                dgvQLTourMienTrung.Rows[index].Cells[3].Value = item.NgayKetThucMienTrung;
                dgvQLTourMienTrung.Rows[index].Cells[4].Value = item.GiaTourMienTrung;
                dgvQLTourMienTrung.Rows[index].Cells[5].Value = item.SoNguoiDiMienTrung;
            }
        }


        private void HienThiTourMN(List<TourMienNam> tourMN)
        {
            dgvQLTourMienNam.Rows.Clear();
            foreach (var item in tourMN)
            {
                int index = dgvQLTourMienNam.Rows.Add();
                dgvQLTourMienNam.Rows[index].Cells[0].Value = item.MaTourMienNam;
                dgvQLTourMienNam.Rows[index].Cells[1].Value = item.TenTourMienNam;
                dgvQLTourMienNam.Rows[index].Cells[2].Value = item.NgayDiMienNam;
                dgvQLTourMienNam.Rows[index].Cells[3].Value = item.NgayKetThucMienNam;
                dgvQLTourMienNam.Rows[index].Cells[4].Value = item.GiaTourMienNam;
                dgvQLTourMienNam.Rows[index].Cells[5].Value = item.SoNguoiDiMienNam;
            }
        }

        private void cmbTour_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemTour_Click(object sender, EventArgs e)
        {
            try
            {
                string notice = "";
                if (notice == "")
                {
                    if (string.IsNullOrEmpty(txtQLMaTour.Text))
                    {
                        notice += "Chưa nhập mã tour.";
                    }
                    if (string.IsNullOrEmpty(txtQLTenTour.Text))
                    {
                        notice += "Chưa nhập tên tour.";
                    }
                    if (string.IsNullOrEmpty(dtQLNgayDi.Text))
                    {
                        notice += "Chưa chọn ngày đi.";
                    }
                    if (string.IsNullOrEmpty(dtQLNgayKT.Text))
                    {
                        notice += "Chưa chọn ngày kết thúc.";
                    }
                    if (string.IsNullOrEmpty(txtQLGiaTour.Text))
                    {
                        notice += "Chưa nhập giá tour.";
                    }
                    if (string.IsNullOrEmpty(numQLSoNguoiDi.Text))
                    {
                        notice += "Chưa chọn số người đi.";
                    }
                }

                if ((string.IsNullOrEmpty(txtQLMaTour.Text)) || (string.IsNullOrEmpty(txtQLTenTour.Text)) || (string.IsNullOrEmpty(dtQLNgayDi.Text)) || (string.IsNullOrEmpty(dtQLNgayKT.Text)) || (string.IsNullOrEmpty(txtQLGiaTour.Text)) || (string.IsNullOrEmpty(numQLSoNguoiDi.Text)))
                {
                    MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DuLichDB context = new DuLichDB();
                    TourMienBac addMB = context.TourMienBacs.FirstOrDefault(p => p.MaTourMienBac == txtQLMaTour.Text);
                    TourMienTrung addMT = context.TourMienTrungs.FirstOrDefault(O => O.MaTourMienTrung == txtQLMaTour.Text);
                    TourMienNam addMN = context.TourMienNams.FirstOrDefault(D => D.MaTourMienNam == txtQLMaTour.Text);


                    if (addMT == null || addMN == null || addMB == null)
                    {
                        
                        if (addMB == null && cmbTour.SelectedIndex == 0)
                        {
                            TourMienBac s = new TourMienBac()
                            {
                                MaTourMienBac = txtQLMaTour.Text,
                                TenTourMienBac = txtQLTenTour.Text,
                                NgayDiMienBac = (DateTime)(dtQLNgayDi.Value),
                                NgayKetThucMienBac = (DateTime)(dtQLNgayKT.Value),
                                GiaTourMienBac = float.Parse(txtQLGiaTour.Text),
                                SoNguoiDiMienBac = int.Parse(numQLSoNguoiDi.Text),
                            };

                            context.TourMienBacs.Add(s);

                            context.SaveChanges();

                            HienThiTourMB(context.TourMienBacs.ToList());
                           

                            txtQLMaTour.Text = "";
                            txtQLTenTour.Text = "";
                            dtQLNgayDi.Value = DateTime.Now;
                            dtQLNgayKT.Value = DateTime.Now;
                            txtQLGiaTour.Text = "";
                            numQLSoNguoiDi.Value = 0;

                            MessageBox.Show("Thêm thành công!");
                        }
                        else if (addMN == null && cmbTour.SelectedIndex == 2)
                        {
                            TourMienNam n = new TourMienNam()
                            {
                                MaTourMienNam = txtQLMaTour.Text,
                                TenTourMienNam = txtQLTenTour.Text,
                                NgayDiMienNam = (DateTime)(dtQLNgayDi.Value),
                                NgayKetThucMienNam = (DateTime)(dtQLNgayKT.Value),
                                GiaTourMienNam = float.Parse(txtQLGiaTour.Text),
                                SoNguoiDiMienNam = int.Parse(numQLSoNguoiDi.Text),
                            };

                            context.TourMienNams.Add(n);

                            context.SaveChanges();

                            HienThiTourMN(context.TourMienNams.ToList());

                            txtQLMaTour.Text = "";
                            txtQLTenTour.Text = "";
                            dtQLNgayDi.Value = DateTime.Now;
                            dtQLNgayKT.Value = DateTime.Now;
                            txtQLGiaTour.Text = "";
                            numQLSoNguoiDi.Value = 0;

                            MessageBox.Show("Thêm thành công!");
                        }

                        else if (addMT == null && cmbTour.SelectedIndex == 1)
                        {
                            TourMienTrung t = new TourMienTrung()
                            {
                                MaTourMienTrung = txtQLMaTour.Text,
                                TenTourMienTrung = txtQLTenTour.Text,
                                NgayDiMienTrung = (DateTime)(dtQLNgayDi.Value),
                                NgayKetThucMienTrung = (DateTime)(dtQLNgayKT.Value),
                                GiaTourMienTrung = float.Parse(txtQLGiaTour.Text),
                                SoNguoiDiMienTrung = int.Parse(numQLSoNguoiDi.Text),
                            };

                            context.TourMienTrungs.Add(t);

                            context.SaveChanges();


                            HienThiTourMT(context.TourMienTrungs.ToList());

                            txtQLMaTour.Text = "";
                            txtQLTenTour.Text = "";
                            dtQLNgayDi.Value = DateTime.Now;
                            dtQLNgayKT.Value = DateTime.Now;
                            txtQLGiaTour.Text = "";
                            numQLSoNguoiDi.Value = 0;

                            MessageBox.Show("Thêm thành công!");
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvQLTourMienTrung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQLTourMienTrung.Rows.Count > 0 && e.RowIndex < dgvQLTourMienTrung.RowCount - 1)
            {
                string matourtn = dgvQLTourMienTrung.Rows[e.RowIndex].Cells[0].Value.ToString();
                DuLichDB context = new DuLichDB();
                TourMienTrung update = context.TourMienTrungs.FirstOrDefault(p => p.MaTourMienTrung == matourtn);
                if (update != null)
                {
                    txtQLMaTour.Text = matourtn;
                    txtQLTenTour.Text = update.TenTourMienTrung;
                    dtQLNgayDi.Text = (update.NgayDiMienTrung).ToString();
                    dtQLNgayKT.Text = (update.NgayKetThucMienTrung).ToString();
                    txtQLGiaTour.Text = (update.GiaTourMienTrung).ToString();
                    numQLSoNguoiDi.Value = (decimal)(update.SoNguoiDiMienTrung);

                }
            }
        }

        private void dgvQLTourMienNam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQLTourMienNam.Rows.Count > 0 && e.RowIndex < dgvQLTourMienNam.RowCount - 1)
            {
                string matourtn = dgvQLTourMienNam.Rows[e.RowIndex].Cells[0].Value.ToString();
                DuLichDB context = new DuLichDB();
                TourMienNam update = context.TourMienNams.FirstOrDefault(p => p.MaTourMienNam == matourtn);
                if (update != null)
                {
                    txtQLMaTour.Text = matourtn;
                    txtQLTenTour.Text = update.TenTourMienNam;
                    dtQLNgayDi.Text = (update.NgayDiMienNam).ToString();
                    dtQLNgayKT.Text = (update.NgayKetThucMienNam).ToString();
                    txtQLGiaTour.Text = (update.GiaTourMienNam).ToString();
                    numQLSoNguoiDi.Value = (decimal)(update.SoNguoiDiMienNam);

                }
            }
        }

        private void dgvQLTourMienBac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQLTourMienBac.Rows.Count > 0 && e.RowIndex < dgvQLTourMienBac.RowCount - 1)
            {
                string matourtn = dgvQLTourMienBac.Rows[e.RowIndex].Cells[0].Value.ToString();
                DuLichDB context = new DuLichDB();
                TourMienBac update = context.TourMienBacs.FirstOrDefault(p => p.MaTourMienBac == matourtn);
                if (update != null)
                {
                    txtQLMaTour.Text = matourtn;
                    txtQLTenTour.Text = update.TenTourMienBac;
                    dtQLNgayDi.Text = (update.NgayDiMienBac).ToString();
                    dtQLNgayKT.Text = (update.NgayKetThucMienBac).ToString();
                    txtQLGiaTour.Text = (update.GiaTourMienBac).ToString();
                    numQLSoNguoiDi.Value = (decimal)(update.SoNguoiDiMienBac);

                }
            }
        }

        private void btnXoaTour_Click(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                TourMienBac deleteMB = context.TourMienBacs.FirstOrDefault(p => p.MaTourMienBac == txtQLMaTour.Text);
                TourMienNam deleteMN = context.TourMienNams.FirstOrDefault(p => p.MaTourMienNam == txtQLMaTour.Text);
                TourMienTrung deleteMT = context.TourMienTrungs.FirstOrDefault(p => p.MaTourMienTrung == txtQLMaTour.Text);


                if (deleteMB != null || deleteMN != null    || deleteMT != null)
                {
                    
                    if (deleteMB != null)
                    {
                        context.TourMienBacs.Remove(deleteMB);

                        context.SaveChanges();

                        HienThiTourMB(context.TourMienBacs.ToList());

                    }

                
                    if (deleteMN != null)
                    {
                        context.TourMienNams.Remove(deleteMN);

                        context.SaveChanges();

                        HienThiTourMN(context.TourMienNams.ToList());

                    }
                    if (deleteMT != null)
                    {
                        context.TourMienTrungs.Remove(deleteMT);

                        context.SaveChanges();

                        HienThiTourMT(context.TourMienTrungs.ToList());

                    }
                    MessageBox.Show("Xoá tour thành công!");
                }

                else
                {
                    MessageBox.Show("Không tìm thấy tour cần xóa!");
                }

                txtQLMaTour.Text = "";
                txtQLTenTour.Text = "";
                dtQLNgayDi.Value = DateTime.Now;
                dtQLNgayKT.Value = DateTime.Now;
                txtQLGiaTour.Text = "";
                numQLSoNguoiDi.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaTour_Click(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                TourMienBac updateMB = context.TourMienBacs.FirstOrDefault(p => p.MaTourMienBac == txtQLMaTour.Text);
                TourMienNam updateMN = context.TourMienNams.FirstOrDefault(p => p.MaTourMienNam == txtQLMaTour.Text);
                TourMienTrung updateMT = context.TourMienTrungs.FirstOrDefault(p => p.MaTourMienTrung == txtQLMaTour.Text);

                if (updateMB != null || updateMT != null || updateMN != null)
                {
                    if (updateMB != null)
                    {
                        updateMB.TenTourMienBac = txtQLTenTour.Text;
                        updateMB.NgayDiMienBac = (DateTime)(dtQLNgayDi.Value);
                        updateMB.NgayKetThucMienBac = (DateTime)(dtQLNgayKT.Value);
                        updateMB.GiaTourMienBac = float.Parse(txtQLGiaTour.Text);

                        context.SaveChanges();

                        HienThiTourMB(context.TourMienBacs.ToList());
                    }
                    if (updateMN != null)
                    {
                        updateMN.TenTourMienNam = txtQLTenTour.Text;
                        updateMN.NgayDiMienNam = (DateTime)(dtQLNgayDi.Value);
                        updateMN.NgayKetThucMienNam = (DateTime)(dtQLNgayKT.Value);
                        updateMN.GiaTourMienNam = float.Parse(txtQLGiaTour.Text);

                        context.SaveChanges();

                        HienThiTourMN(context.TourMienNams.ToList());
                    }
                    if (updateMT != null)
                    {
                        updateMT.TenTourMienTrung = txtQLTenTour.Text;
                        updateMT.NgayDiMienTrung = (DateTime)(dtQLNgayDi.Value);
                        updateMT.NgayKetThucMienTrung = (DateTime)(dtQLNgayKT.Value);
                        updateMT.GiaTourMienTrung = float.Parse(txtQLGiaTour.Text);

                        context.SaveChanges();

                        HienThiTourMT(context.TourMienTrungs.ToList());
                    }

                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tour này!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chức năng này không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Hide();
                //frmMain returnMain = new frmMain();
                //returnMain.ShowDialog();
            }
        }
    }
}
    


