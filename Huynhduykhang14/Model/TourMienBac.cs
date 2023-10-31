namespace Huynhduykhang14.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourMienBac")]
    public partial class TourMienBac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourMienBac()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaTourMienBac { get; set; }

        [StringLength(200)]
        public string TenTourMienBac { get; set; }

        public int? SoNguoiDiMienBac { get; set; }

        public DateTime? NgayDiMienBac { get; set; }

        public DateTime? NgayKetThucMienBac { get; set; }

        public double? GiaTourMienBac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
