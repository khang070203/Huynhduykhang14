using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Huynhduykhang14.Model
{
    public partial class DuLichDB : DbContext
    {
        public DuLichDB()
            : base("name=DuLichDB")
        {
        }

        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TourMienBac> TourMienBacs { get; set; }
        public virtual DbSet<TourMienNam> TourMienNams { get; set; }
        public virtual DbSet<TourMienTrung> TourMienTrungs { get; set; }
        public virtual DbSet<TourNgoaiNuoc> TourNgoaiNuocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaTourMienBac)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaTourMienTrung)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaTourMienNam)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaTourNgoaiNuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TourMienBac>()
                .Property(e => e.MaTourMienBac)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TourMienNam>()
                .Property(e => e.MaTourMienNam)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TourMienTrung>()
                .Property(e => e.MaTourMienTrung)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TourNgoaiNuoc>()
                .Property(e => e.MaTourNgoaiNuoc)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
