namespace Huynhduykhang14.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourMienTrung")]
    public partial class TourMienTrung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourMienTrung()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaTourMienTrung { get; set; }

        [StringLength(200)]
        public string TenTourMienTrung { get; set; }

        public int? SoNguoiDiMienTrung { get; set; }

        public DateTime? NgayDiMienTrung { get; set; }

        public DateTime? NgayKetThucMienTrung { get; set; }

        public double? GiaTourMienTrung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
