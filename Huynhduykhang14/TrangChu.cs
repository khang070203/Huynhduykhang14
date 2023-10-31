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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                DuLichDB context = new DuLichDB();
                List<TourMienBac> tourMB = context.TourMienBacs.ToList();
                List<TourMienNam> tourMN = context.TourMienNams.ToList();
                List<TourMienTrung> tourMT = context.TourMienTrungs.ToList();
                List<TourNgoaiNuoc> tourNN = context.TourNgoaiNuocs.ToList();

                cmbDiaDiemNoiTieng.Text = "2019";
                labelMT.Text = "TNN001";
                labelTen.Text = " TP.Hồ Chí Minh-Ấn ĐỘ";
                string a = "D:\\Doanwindow\\hinh\\AD1.jpg";
                ptTourBanChay.Image = Image.FromFile(a);
                ptTourBanChay.SizeMode = PictureBoxSizeMode.StretchImage;
                string a1 = "D:\\Doanwindow\\hinh\\AD2.jpg";
                ptDiaDiemNoiTieng1.Image = Image.FromFile(a1);
                ptDiaDiemNoiTieng1.SizeMode = PictureBoxSizeMode.StretchImage;
                string a2 = "D:\\Doanwindow\\hinh\\AD3.jpg";
                ptDiaDiemNoiTieng2.Image = Image.FromFile(a2);
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string a3 = "D:\\Doanwindow\\hinh\\AD4.jpg";
                ptDiaDiemNoiTieng3.Image = Image.FromFile(a3);
                ptDiaDiemNoiTieng3.SizeMode = PictureBoxSizeMode.StretchImage;
                string a4 = "D:\\Doanwindow\\hinh\\AD5.jpg";
                ptDiaDiemNoiTieng4.Image = Image.FromFile(a4);
                ptDiaDiemNoiTieng4.SizeMode = PictureBoxSizeMode.StretchImage;
                labelTien.Text = "120000000";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnlTourBanChay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ptDiaDiemNoiTieng2_Click(object sender, EventArgs e)
        {

        }

        private void cmbDiaDiemNoiTieng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiaDiemNoiTieng.SelectedIndex == 0)
            {
                labelMT.Text = "TNN001";
                labelTen.Text = " TP.Hồ Chí Minh-Ấn ĐỘ";
                string a = "D:\\Doanwindow\\hinh\\AD1.jpg";
                ptTourBanChay.Image = Image.FromFile(a);
                ptTourBanChay.SizeMode = PictureBoxSizeMode.StretchImage;
                string a1 = "D:\\Doanwindow\\hinh\\AD2.jpg";
                ptDiaDiemNoiTieng1.Image = Image.FromFile(a1);
                ptDiaDiemNoiTieng1.SizeMode = PictureBoxSizeMode.StretchImage;
                string a2 = "D:\\Doanwindow\\hinh\\AD3.jpg";
                ptDiaDiemNoiTieng2.Image = Image.FromFile(a2);
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string a3 = "D:\\Doanwindow\\hinh\\AD4.jpg";
                ptDiaDiemNoiTieng3.Image = Image.FromFile(a3);
                ptDiaDiemNoiTieng3.SizeMode = PictureBoxSizeMode.StretchImage;
                string a4 = "D:\\Doanwindow\\hinh\\AD5.jpg";
                ptDiaDiemNoiTieng4.Image = Image.FromFile(a4);
                ptDiaDiemNoiTieng4.SizeMode = PictureBoxSizeMode.StretchImage;
                labelTien.Text = "120000000";
            }
            else if (cmbDiaDiemNoiTieng.SelectedIndex == 1)
            {
                labelMT.Text = "TMN003";
                labelTen.Text = "TP.Hồ Chí Minh-Cần Thơ";
                string b = "D:\\Doanwindow\\hinh\\CT1.jpg";
                ptTourBanChay.Image = Image.FromFile(b);
                ptTourBanChay.SizeMode = PictureBoxSizeMode.StretchImage;
                string b1 = "D:\\Doanwindow\\hinh\\CT2.jpg";
                ptDiaDiemNoiTieng1.Image = Image.FromFile(b1);
                ptDiaDiemNoiTieng1.SizeMode = PictureBoxSizeMode.StretchImage;
                string b2 = "D:\\Doanwindow\\hinh\\CT3.jpg";
                ptDiaDiemNoiTieng2.Image = Image.FromFile(b2);
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string b3 = "D:\\Doanwindow\\hinh\\CT4.jpg";
                ptDiaDiemNoiTieng3.Image = Image.FromFile(b3);
                ptDiaDiemNoiTieng3.SizeMode = PictureBoxSizeMode.StretchImage;
                string b4 = "D:\\Doanwindow\\hinh\\CT5.jpg";
                ptDiaDiemNoiTieng4.Image = Image.FromFile(b4);
                ptDiaDiemNoiTieng4.SizeMode = PictureBoxSizeMode.StretchImage;
                labelTien.Text = "2500000";
            }
            else if (cmbDiaDiemNoiTieng.SelectedIndex == 2)
            {
                labelMT.Text = "TMT05";
                labelTen.Text = "TP. Hồ Chí Minh - Đà Lạt";
                string c = "D:\\Doanwindow\\hinh\\DL1.jpg";
                ptTourBanChay.Image = Image.FromFile(c);
                ptTourBanChay.SizeMode = PictureBoxSizeMode.StretchImage;
                string c1 = "D:\\Doanwindow\\hinh\\DL2.jpg";
                ptDiaDiemNoiTieng1.Image = Image.FromFile(c1);
                ptDiaDiemNoiTieng1.SizeMode = PictureBoxSizeMode.StretchImage;
                string c2 = "D:\\Doanwindow\\hinh\\DL3.jpg";
                ptDiaDiemNoiTieng2.Image = Image.FromFile(c2);
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string c3 = "D:\\Doanwindow\\hinh\\DL4.jpg";
                ptDiaDiemNoiTieng3.Image = Image.FromFile(c3);
                ptDiaDiemNoiTieng3.SizeMode = PictureBoxSizeMode.StretchImage;
                string c4 = "D:\\Doanwindow\\hinh\\DL5.jpg";
                ptDiaDiemNoiTieng4.Image = Image.FromFile(c4);
                ptDiaDiemNoiTieng4.SizeMode = PictureBoxSizeMode.StretchImage;
                labelTien.Text = "2000000";
            }
            else if (cmbDiaDiemNoiTieng.SelectedIndex == 3)
            {
                labelMT.Text = "TMB003";
                labelTen.Text = "Hà Nội - Lạng Sơn";
                string d = "D:\\Doanwindow\\hinh\\LS1.jpg";
                ptTourBanChay.Image = Image.FromFile(d);
                ptTourBanChay.SizeMode = PictureBoxSizeMode.StretchImage;
                string d1 = "D:\\Doanwindow\\hinh\\LS1.jpg";
                ptDiaDiemNoiTieng1.Image = Image.FromFile(d1);
                ptDiaDiemNoiTieng1.SizeMode = PictureBoxSizeMode.StretchImage;
                string d2 = "D:\\Doanwindow\\hinh\\LS1.jpg";
                ptDiaDiemNoiTieng2.Image = Image.FromFile(d2);
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string d3 = "D:\\Doanwindow\\hinh\\LS1.jpg";
                ptDiaDiemNoiTieng3.Image = Image.FromFile(d3);
                ptDiaDiemNoiTieng3.SizeMode = PictureBoxSizeMode.StretchImage;
                string d4 = "D:\\Doanwindow\\hinh\\LS1.jpg";
                ptDiaDiemNoiTieng4.Image = Image.FromFile(d4);
                ptDiaDiemNoiTieng4.SizeMode = PictureBoxSizeMode.StretchImage;
                labelTien.Text = "35500000";
            }
            else if (cmbDiaDiemNoiTieng.SelectedIndex == 4)
            {
                labelMT.Text = "TN004";
                labelTen.Text = "Hà Nội - Hàn Quốc";
                string f = "D:\\Doanwindow\\hinh\\TS1.jpg";
                ptTourBanChay.Image = Image.FromFile(f);
                ptTourBanChay.SizeMode = PictureBoxSizeMode.StretchImage;
                string f1 = "D:\\Doanwindow\\hinh\\TS2.jpg";
                ptDiaDiemNoiTieng1.Image = Image.FromFile(f1);
                ptDiaDiemNoiTieng1.SizeMode = PictureBoxSizeMode.StretchImage;
                string f2 = "D:\\Doanwindow\\hinh\\TS3.jpg";
                ptDiaDiemNoiTieng2.Image = Image.FromFile(f2);
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string f3 = "D:\\Doanwindow\\hinh\\TS4.jpg";
                ptDiaDiemNoiTieng3.Image = Image.FromFile(f3);
                ptDiaDiemNoiTieng3.SizeMode = PictureBoxSizeMode.StretchImage;
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string f4 = "D:\\Doanwindow\\hinh\\TS5.jpg";
                ptDiaDiemNoiTieng4.Image = Image.FromFile(f4);
                ptDiaDiemNoiTieng4.SizeMode = PictureBoxSizeMode.StretchImage;
                labelTien.Text = "185000000";
            }

            else if (cmbDiaDiemNoiTieng.SelectedIndex == 5)
            {
                labelMT.Text = "TN003";
                labelTen.Text = "Hà Nội - Thụy Điển";
                string f = "D:\\Doanwindow\\hinh\\TD1.jpg";
                ptTourBanChay.Image = Image.FromFile(f);
                ptTourBanChay.SizeMode = PictureBoxSizeMode.StretchImage;
                string f1 = "D:\\Doanwindow\\hinh\\TD2.jpg";
                ptDiaDiemNoiTieng1.Image = Image.FromFile(f1);
                ptDiaDiemNoiTieng1.SizeMode = PictureBoxSizeMode.StretchImage;
                string f2 = "D:\\Doanwindow\\hinh\\TD3.jpg";
                ptDiaDiemNoiTieng2.Image = Image.FromFile(f2);
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string f3 = "D:\\Doanwindow\\hinh\\TS4.jpg";
                ptDiaDiemNoiTieng3.Image = Image.FromFile(f3);
                ptDiaDiemNoiTieng3.SizeMode = PictureBoxSizeMode.StretchImage;
                ptDiaDiemNoiTieng2.SizeMode = PictureBoxSizeMode.StretchImage;
                string f4 = "D:\\Doanwindow\\hinh\\TD5.jpg";
                ptDiaDiemNoiTieng4.Image = Image.FromFile(f4);
                ptDiaDiemNoiTieng4.SizeMode = PictureBoxSizeMode.StretchImage;
                labelTien.Text = "170000000";
            }
        }
    }
}
