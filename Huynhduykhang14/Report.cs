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
    public partial class formRP : Form
    {
        public formRP()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        public formRP(string makh, string tenkh, string tentour, string thanhtien, string ngaydi, string ngaykt, string ngaylap)
        {
            InitializeComponent();
            lblSoHD.Text = "HD001";
            lblMaKHHD.Text = makh;
            lblTenKHHD.Text = tenkh;
            lblTenTourHD.Text = tentour;
            lblThanhTienHD.Text = thanhtien;
            lblNgayDiHD.Text = ngaydi;
            lblNgayKTHD.Text = ngaykt;
            lblNgayLapHD.Text = ngaylap;
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
