namespace Huynhduykhang14.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourMienNam")]
    public partial class TourMienNam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourMienNam()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaTourMienNam { get; set; }

        [StringLength(200)]
        public string TenTourMienNam { get; set; }

        public int? SoNguoiDiMienNam { get; set; }

        public DateTime? NgayDiMienNam { get; set; }

        public DateTime? NgayKetThucMienNam { get; set; }

        public double? GiaTourMienNam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
