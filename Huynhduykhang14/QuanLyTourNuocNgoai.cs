using Huynhduykhang14.Model;
using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huynhduykhang14
{
    public partial class QuanLyTourNuocNgoai : Form
    {
        public QuanLyTourNuocNgoai()
        {
            InitializeComponent();
        }

        private void QuanLyTourNuocNgoai_Load(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                List<TourNgoaiNuoc> tourNN = context.TourNgoaiNuocs.ToList();
                HienThiTourNN(tourNN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThiTourNN(List<TourNgoaiNuoc> tourNN)
        {
            dgvQLTourNgoaiNuoc.Rows.Clear();
            foreach (var item in tourNN)
            {
                int index = dgvQLTourNgoaiNuoc.Rows.Add();
                dgvQLTourNgoaiNuoc.Rows[index].Cells[0].Value = item.MaTourNgoaiNuoc;
                dgvQLTourNgoaiNuoc.Rows[index].Cells[1].Value = item.TenTourNgoaiNuoc;
                dgvQLTourNgoaiNuoc.Rows[index].Cells[2].Value = item.NgayDiNgoaiNuoc;
                dgvQLTourNgoaiNuoc.Rows[index].Cells[3].Value = item.NgayKetThucNgoaiNuoc;
                dgvQLTourNgoaiNuoc.Rows[index].Cells[4].Value = item.GiaTourNgoaiNuoc;
                dgvQLTourNgoaiNuoc.Rows[index].Cells[5].Value = item.SoNguoiDiNgoaiNuoc;
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvQLTourNgoaiNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQLTourNgoaiNuoc.Rows.Count > 0 && e.RowIndex < dgvQLTourNgoaiNuoc.RowCount - 1)
            {
                string matournn = dgvQLTourNgoaiNuoc.Rows[e.RowIndex].Cells[0].Value.ToString();
                DuLichDB context = new DuLichDB();
                TourNgoaiNuoc update = context.TourNgoaiNuocs.FirstOrDefault(p => p.MaTourNgoaiNuoc == matournn);
                if (update != null)
                {
                    txtQLMaTour.Text = matournn;
                    txtQLTenTour.Text = update.TenTourNgoaiNuoc;
                    dtQLNgayDi.Text = (update.NgayDiNgoaiNuoc).ToString();
                    dtQLNgayKT.Text = (update.NgayKetThucNgoaiNuoc).ToString();
                    txtQLGiaTour.Text = (update.GiaTourNgoaiNuoc).ToString();
                    numQLSoNguoiDi.Value = (decimal)(update.SoNguoiDiNgoaiNuoc);
                }
            }
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

                {
                    DuLichDB context = new DuLichDB();

                    TourNgoaiNuoc addNN = context.TourNgoaiNuocs.FirstOrDefault(o => o.MaTourNgoaiNuoc == txtQLMaTour.Text);


                    //Thêm Tour Ngoài Nước
                    if (addNN == null )
                    {
                        TourNgoaiNuoc r = new TourNgoaiNuoc()
                        {
                            MaTourNgoaiNuoc = txtQLMaTour.Text,
                            TenTourNgoaiNuoc = txtQLTenTour.Text,
                            NgayDiNgoaiNuoc = (DateTime)(dtQLNgayDi.Value),
                            NgayKetThucNgoaiNuoc = (DateTime)(dtQLNgayKT.Value),
                            GiaTourNgoaiNuoc = float.Parse(txtQLGiaTour.Text),
                            SoNguoiDiNgoaiNuoc = int.Parse(numQLSoNguoiDi.Text),
                        };

                        context.TourNgoaiNuocs.Add(r);

                        context.SaveChanges();

                        HienThiTourNN(context.TourNgoaiNuocs.ToList());

                        txtQLMaTour.Text = "";
                        txtQLTenTour.Text = "";
                        dtQLNgayDi.Value = DateTime.Now;
                        dtQLNgayKT.Value = DateTime.Now;
                        txtQLGiaTour.Text = "";
                        numQLSoNguoiDi.Value = 0;

                        MessageBox.Show("Thêm thành công!");
                    }

                    else
                    {
                        MessageBox.Show("Đã có tour này rồi!");
                    }
                }
            }
            

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaTour_Click(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                TourNgoaiNuoc deleteNN = context.TourNgoaiNuocs.FirstOrDefault(p => p.MaTourNgoaiNuoc == txtQLMaTour.Text);


                //Xóa Tour Ngoài Nước
                if (deleteNN != null)
                {
                    context.TourNgoaiNuocs.Remove(deleteNN);

                    context.SaveChanges();

                    HienThiTourNN(context.TourNgoaiNuocs.ToList());
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
               
                TourNgoaiNuoc updateNN = context.TourNgoaiNuocs.FirstOrDefault(p => p.MaTourNgoaiNuoc == txtQLMaTour.Text);
            

                    if (updateNN != null)
                    {
                        updateNN.TenTourNgoaiNuoc = txtQLTenTour.Text;
                        updateNN.NgayDiNgoaiNuoc = (DateTime)(dtQLNgayDi.Value);
                        updateNN.NgayKetThucNgoaiNuoc = (DateTime)(dtQLNgayKT.Value);
                        updateNN.GiaTourNgoaiNuoc = float.Parse(txtQLGiaTour.Text);

                        context.SaveChanges();

                        HienThiTourNN(context.TourNgoaiNuocs.ToList());
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

       