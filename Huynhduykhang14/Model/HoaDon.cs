namespace Huynhduykhang14.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(10)]
        public string MaHD { get; set; }

        public DateTime? NgayLapHD { get; set; }

        public double? TongTien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(10)]
        public string MaTourMienBac { get; set; }

        [StringLength(10)]
        public string MaTourMienTrung { get; set; }

        [StringLength(10)]
        public string MaTourMienNam { get; set; }

        [StringLength(10)]
        public string MaTourNgoaiNuoc { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual TourMienBac TourMienBac { get; set; }

        public virtual TourMienNam TourMienNam { get; set; }

        public virtual TourMienTrung TourMienTrung { get; set; }

        public virtual TourNgoaiNuoc TourNgoaiNuoc { get; set; }
    }
}
