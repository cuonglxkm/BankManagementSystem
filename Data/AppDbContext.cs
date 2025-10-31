using System;
using System.Collections.Generic;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangLuong> BangLuongs { get; set; }

    public virtual DbSet<CaNhan> CaNhans { get; set; }

    public virtual DbSet<ChiNhanh> ChiNhanhs { get; set; }

    public virtual DbSet<ChiTietLuong> ChiTietLuongs { get; set; }

    public virtual DbSet<CreditAcc> CreditAccs { get; set; }

    public virtual DbSet<DebitAcc> DebitAccs { get; set; }

    public virtual DbSet<GiaoDich> GiaoDiches { get; set; }

    public virtual DbSet<KeHoachLaiSuat> KeHoachLaiSuats { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhachHangChiNhanh> KhachHangChiNhanhs { get; set; }

    public virtual DbSet<KyLuong> KyLuongs { get; set; }

    public virtual DbSet<LoanAcc> LoanAccs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SaoKeTaiKhoan> SaoKeTaiKhoans { get; set; }

    public virtual DbSet<SavingAcc> SavingAccs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ToChuc> ToChucs { get; set; }

    public virtual DbSet<VwGiaoDichTheoThang> VwGiaoDichTheoThangs { get; set; }

    public virtual DbSet<VwKhachHangDoanhNghiep> VwKhachHangDoanhNghieps { get; set; }

    public virtual DbSet<VwTaiKhoanTinDungNo> VwTaiKhoanTinDungNos { get; set; }

    public virtual DbSet<VwThongTinTaiKhoan> VwThongTinTaiKhoans { get; set; }

    public virtual DbSet<VwTop10KhachHangTienGui> VwTop10KhachHangTienGuis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=BankManagementSystem;User Id=sa;Password=12345;Encrypt=false;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangLuong>(entity =>
        {
            entity.HasKey(e => e.MaBangLuong).HasName("PK__BangLuon__F879CE321356F616");

            entity.ToTable("BangLuong", tb => tb.HasTrigger("CalculateTongLuong"));

            entity.HasIndex(e => new { e.MaNhanVien, e.MaKyLuong }, "UQ__BangLuon__21A9AAB4E66DED38").IsUnique();

            entity.HasIndex(e => e.MaKyLuong, "idx_BangLuong_MaKy");

            entity.Property(e => e.MaBangLuong)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_bang_luong");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(200)
                .HasColumnName("Ghi_chu");
            entity.Property(e => e.LuongCoBan)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Luong_co_ban");
            entity.Property(e => e.MaKyLuong)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_ky_luong");
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_nhan_vien");
            entity.Property(e => e.NgayTinh).HasColumnName("Ngay_tinh");
            entity.Property(e => e.NguoiDuyet)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nguoi_duyet");
            entity.Property(e => e.ThuongTheoTaiKhoan)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Thuong_theo_tai_khoan");
            entity.Property(e => e.TongLuong)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tong_luong");

            entity.HasOne(d => d.MaKyLuongNavigation).WithMany(p => p.BangLuongs)
                .HasForeignKey(d => d.MaKyLuong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BangLuong__Ma_ky__02FC7413");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.BangLuongMaNhanVienNavigations)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BangLuong__Ma_nh__03F0984C");

            entity.HasOne(d => d.NguoiDuyetNavigation).WithMany(p => p.BangLuongNguoiDuyetNavigations)
                .HasForeignKey(d => d.NguoiDuyet)
                .HasConstraintName("FK__BangLuong__Nguoi__04E4BC85");
        });

        modelBuilder.Entity<CaNhan>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__CaNhan__F9279E96B9B8A362");

            entity.ToTable("CaNhan");

            entity.HasIndex(e => e.SoCmndCccd, "UQ__CaNhan__91E5FF6A8706A333").IsUnique();

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .HasColumnName("Gioi_tinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(50)
                .HasColumnName("Ho_ten");
            entity.Property(e => e.NgaySinh).HasColumnName("Ngay_sinh");
            entity.Property(e => e.SoCmndCccd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_CMND_CCCD");

            entity.HasOne(d => d.MaKhachHangNavigation).WithOne(p => p.CaNhan)
                .HasForeignKey<CaNhan>(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CaNhan__Ma_khach__52593CB8");
        });

        modelBuilder.Entity<ChiNhanh>(entity =>
        {
            entity.HasKey(e => e.MaChiNhanh).HasName("PK__ChiNhanh__7217ABECC9132B65");

            entity.ToTable("ChiNhanh");

            entity.Property(e => e.MaChiNhanh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ma_chi_nhanh");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(200)
                .HasColumnName("Dia_chi");
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Dien_thoai");
            entity.Property(e => e.MaNvQuanLy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_nv_quan_ly");
            entity.Property(e => e.TenChiNhanh)
                .HasMaxLength(100)
                .HasColumnName("Ten_chi_nhanh");
        });

        modelBuilder.Entity<ChiTietLuong>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__ChiTietL__51C3A5484948C8BC");

            entity.ToTable("ChiTietLuong");

            entity.Property(e => e.MaChiTiet)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_chi_tiet");
            entity.Property(e => e.LoaiMuc)
                .HasMaxLength(50)
                .HasColumnName("Loai_muc");
            entity.Property(e => e.MaBangLuong)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_bang_luong");
            entity.Property(e => e.SoTaiKhoanLienQuan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan_lien_quan");
            entity.Property(e => e.SoTienGoc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_tien_goc");
            entity.Property(e => e.SoTienThuong)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_tien_thuong");
            entity.Property(e => e.TyLe)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Ty_le");

            entity.HasOne(d => d.MaBangLuongNavigation).WithMany(p => p.ChiTietLuongs)
                .HasForeignKey(d => d.MaBangLuong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietLu__Ma_ba__08B54D69");

            entity.HasOne(d => d.SoTaiKhoanLienQuanNavigation).WithMany(p => p.ChiTietLuongs)
                .HasForeignKey(d => d.SoTaiKhoanLienQuan)
                .HasConstraintName("FK__ChiTietLu__So_ta__09A971A2");
        });

        modelBuilder.Entity<CreditAcc>(entity =>
        {
            entity.HasKey(e => e.SoTaiKhoan).HasName("PK__Credit_A__9113AB06ADBE0A0F");

            entity.ToTable("Credit_ACC");

            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.DuNoHienTai)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Du_no_hien_tai");
            entity.Property(e => e.HanMucTinDung)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Han_muc_tin_dung");
            entity.Property(e => e.LaiSuatNam)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Lai_suat_nam");

            entity.HasOne(d => d.SoTaiKhoanNavigation).WithOne(p => p.CreditAcc)
                .HasForeignKey<CreditAcc>(d => d.SoTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Credit_AC__So_ta__70DDC3D8");
        });

        modelBuilder.Entity<DebitAcc>(entity =>
        {
            entity.HasKey(e => e.SoTaiKhoan).HasName("PK__Debit_AC__9113AB066BDD6FBE");

            entity.ToTable("Debit_ACC");

            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.DuToiThieu)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Du_toi_thieu");
            entity.Property(e => e.LaiSuatNam)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Lai_suat_nam");
            entity.Property(e => e.SoDu)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_du");
            entity.Property(e => e.SoTienGuiBanDau)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_tien_gui_ban_dau");

            entity.HasOne(d => d.SoTaiKhoanNavigation).WithOne(p => p.DebitAcc)
                .HasForeignKey<DebitAcc>(d => d.SoTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Debit_ACC__So_ta__6D0D32F4");
        });

        modelBuilder.Entity<GiaoDich>(entity =>
        {
            entity.HasKey(e => e.MaGiaoDich).HasName("PK__GiaoDich__B1C8551CD3F680EA");

            entity.ToTable("GiaoDich");

            entity.HasIndex(e => e.SoTaiKhoanDich, "idx_GiaoDich_SoTaiKhoanDich");

            entity.HasIndex(e => e.SoTaiKhoanNguon, "idx_GiaoDich_SoTaiKhoanNguon");

            entity.HasIndex(e => e.ThoiGianGiaoDich, "idx_GiaoDich_ThoiGian");

            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_giao_dich");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(200)
                .HasColumnName("Ghi_chu");
            entity.Property(e => e.LoaiGiaoDich)
                .HasMaxLength(50)
                .HasColumnName("Loai_giao_dich");
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_nhan_vien");
            entity.Property(e => e.Nguon).HasMaxLength(50);
            entity.Property(e => e.SoTaiKhoanDich)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan_dich");
            entity.Property(e => e.SoTaiKhoanNguon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan_nguon");
            entity.Property(e => e.SoTien)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_tien");
            entity.Property(e => e.ThoiGianGiaoDich)
                .HasColumnType("datetime")
                .HasColumnName("Thoi_gian_giao_dich");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.GiaoDiches)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GiaoDich__Ma_nha__76969D2E");

            entity.HasOne(d => d.SoTaiKhoanDichNavigation).WithMany(p => p.GiaoDichSoTaiKhoanDichNavigations)
                .HasForeignKey(d => d.SoTaiKhoanDich)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GiaoDich__So_tai__787EE5A0");

            entity.HasOne(d => d.SoTaiKhoanNguonNavigation).WithMany(p => p.GiaoDichSoTaiKhoanNguonNavigations)
                .HasForeignKey(d => d.SoTaiKhoanNguon)
                .HasConstraintName("FK__GiaoDich__So_tai__778AC167");
        });

        modelBuilder.Entity<KeHoachLaiSuat>(entity =>
        {
            entity.HasKey(e => e.MaKeHoachLaiSuat).HasName("PK__KeHoachL__B94FD78F29CACD43");

            entity.ToTable("KeHoachLaiSuat");

            entity.Property(e => e.MaKeHoachLaiSuat)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_ke_hoach_lai_suat");
            entity.Property(e => e.HieuLucDen).HasColumnName("Hieu_luc_den");
            entity.Property(e => e.HieuLucTu).HasColumnName("Hieu_luc_tu");
            entity.Property(e => e.LaiSuatNam)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Lai_suat_nam");
            entity.Property(e => e.LoaiTaiKhoanApDung)
                .HasMaxLength(20)
                .HasColumnName("Loai_tai_khoan_ap_dung");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__F9279E96CB3B20DE");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(200)
                .HasColumnName("Dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoaiKhachHang)
                .HasMaxLength(20)
                .HasColumnName("Loai_khach_hang");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<KhachHangChiNhanh>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__F9279E96FBED176B");

            entity.ToTable("KhachHang_ChiNhanh");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.MaChiNhanh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ma_chi_nhanh");

            entity.HasOne(d => d.MaChiNhanhNavigation).WithMany(p => p.KhachHangChiNhanhs)
                .HasForeignKey(d => d.MaChiNhanh)
                .HasConstraintName("FK__KhachHang__Ma_ch__59FA5E80");

            entity.HasOne(d => d.MaKhachHangNavigation).WithOne(p => p.KhachHangChiNhanh)
                .HasForeignKey<KhachHangChiNhanh>(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KhachHang__Ma_kh__59063A47");
        });

        modelBuilder.Entity<KyLuong>(entity =>
        {
            entity.HasKey(e => e.MaKyLuong).HasName("PK__KyLuong__4CEBBCA4E7127F6B");

            entity.ToTable("KyLuong");

            entity.HasIndex(e => e.Thang, "UQ__KyLuong__2DD4F54BCEF803DA").IsUnique();

            entity.Property(e => e.MaKyLuong)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_ky_luong");
            entity.Property(e => e.DenNgay).HasColumnName("Den_ngay");
            entity.Property(e => e.Thang)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("OPEN")
                .HasColumnName("Trang_thai");
            entity.Property(e => e.TuNgay).HasColumnName("Tu_ngay");
        });

        modelBuilder.Entity<LoanAcc>(entity =>
        {
            entity.HasKey(e => e.SoTaiKhoan).HasName("PK__Loan_ACC__9113AB06B7C799BF");

            entity.ToTable("Loan_ACC");

            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.DuNoGoc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Du_no_goc");
            entity.Property(e => e.KyHan).HasColumnName("Ky_han");
            entity.Property(e => e.LaiSuatNam)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Lai_suat_nam");
            entity.Property(e => e.NgayGiaiNgan).HasColumnName("Ngay_giai_ngan");
            entity.Property(e => e.SoTienGiaiNgan)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_tien_giai_ngan");

            entity.HasOne(d => d.SoTaiKhoanNavigation).WithOne(p => p.LoanAcc)
                .HasForeignKey<LoanAcc>(d => d.SoTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loan_ACC__So_tai__73BA3083");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__7567117F1B6BA0EA");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_nhan_vien");
            entity.Property(e => e.ChucVu)
                .HasMaxLength(50)
                .HasColumnName("Chuc_vu");
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Dien_thoai");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoTen)
                .HasMaxLength(50)
                .HasColumnName("Ho_ten");
            entity.Property(e => e.MaChiNhanh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ma_chi_nhanh");

            entity.HasOne(d => d.MaChiNhanhNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaChiNhanh)
                .HasConstraintName("FK__NhanVien__Ma_chi__4BAC3F29");
        });

        modelBuilder.Entity<SaoKeTaiKhoan>(entity =>
        {
            entity.HasKey(e => new { e.SoTaiKhoan, e.Ky }).HasName("PK__SaoKeTai__D232E6CD66BC89C1");

            entity.ToTable("SaoKeTaiKhoan");

            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.Ky)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.NgayIn).HasColumnName("Ngay_in");
            entity.Property(e => e.SoDuCuoiKy)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_du_cuoi_ky");

            entity.HasOne(d => d.SoTaiKhoanNavigation).WithMany(p => p.SaoKeTaiKhoans)
                .HasForeignKey(d => d.SoTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaoKeTaiK__So_ta__7B5B524B");
        });

        modelBuilder.Entity<SavingAcc>(entity =>
        {
            entity.HasKey(e => e.SoTaiKhoan).HasName("PK__Saving_A__9113AB068FB12C11");

            entity.ToTable("Saving_ACC");

            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.DuToiThieu)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Du_toi_thieu");
            entity.Property(e => e.LaiSuatNam)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Lai_suat_nam");
            entity.Property(e => e.SoDu)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_du");

            entity.HasOne(d => d.SoTaiKhoanNavigation).WithOne(p => p.SavingAcc)
                .HasForeignKey<SavingAcc>(d => d.SoTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Saving_AC__So_ta__68487DD7");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.SoTaiKhoan).HasName("PK__TaiKhoan__9113AB06F7E0FC2E");

            entity.ToTable("TaiKhoan", tb => tb.HasTrigger("CheckQuotaCaNhan"));

            entity.HasIndex(e => e.MaKhachHang, "idx_TaiKhoan_MaKhachHang");

            entity.HasIndex(e => e.MaNhanVienMo, "idx_TaiKhoan_MaNhanVien");

            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.LoaiTaiKhoan)
                .HasMaxLength(20)
                .HasColumnName("Loai_tai_khoan");
            entity.Property(e => e.MaKeHoachLaiSuat)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_ke_hoach_lai_suat");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.MaNhanVienMo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_nhan_vien_mo");
            entity.Property(e => e.NgayMo).HasColumnName("Ngay_mo");
            entity.Property(e => e.TienTe)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("VND")
                .HasColumnName("Tien_te");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Ho?t d?ng")
                .HasColumnName("Trang_thai");

            entity.HasOne(d => d.MaKeHoachLaiSuatNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaKeHoachLaiSuat)
                .HasConstraintName("FK__TaiKhoan__Ma_ke___6383C8BA");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__Ma_kha__619B8048");

            entity.HasOne(d => d.MaNhanVienMoNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaNhanVienMo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__Ma_nha__628FA481");
        });

        modelBuilder.Entity<ToChuc>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__ToChuc__F9279E9627A2FA32");

            entity.ToTable("ToChuc");

            entity.HasIndex(e => e.MaSoThue, "UQ__ToChuc__54B60322884C936E").IsUnique();

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_so_thue");
            entity.Property(e => e.TenToChuc)
                .HasMaxLength(100)
                .HasColumnName("Ten_to_chuc");

            entity.HasOne(d => d.MaKhachHangNavigation).WithOne(p => p.ToChuc)
                .HasForeignKey<ToChuc>(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ToChuc__Ma_khach__5629CD9C");
        });

        modelBuilder.Entity<VwGiaoDichTheoThang>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GiaoDichTheoThang");

            entity.Property(e => e.LoaiKhachHang)
                .HasMaxLength(20)
                .HasColumnName("Loai_khach_hang");
            entity.Property(e => e.LoaiTaiKhoan)
                .HasMaxLength(20)
                .HasColumnName("Loai_tai_khoan");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.SoGiaoDich).HasColumnName("So_giao_dich");
            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(100)
                .HasColumnName("Ten_khach_hang");
            entity.Property(e => e.TongTienGiaoDich)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Tong_tien_giao_dich");
        });

        modelBuilder.Entity<VwKhachHangDoanhNghiep>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_KhachHangDoanhNghiep");

            entity.Property(e => e.LaiSuat)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Lai_suat");
            entity.Property(e => e.LoaiTaiKhoan)
                .HasMaxLength(20)
                .HasColumnName("Loai_tai_khoan");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_so_thue");
            entity.Property(e => e.SoDu)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_du");
            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.TenDoanhNghiep)
                .HasMaxLength(100)
                .HasColumnName("Ten_doanh_nghiep");
        });

        modelBuilder.Entity<VwTaiKhoanTinDungNo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TaiKhoanTinDung_No");

            entity.Property(e => e.ConLaiCoTheVay)
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("Con_lai_co_the_vay");
            entity.Property(e => e.DuNoHienTai)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Du_no_hien_tai");
            entity.Property(e => e.HanMucTinDung)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Han_muc_tin_dung");
            entity.Property(e => e.LoaiKhachHang)
                .HasMaxLength(20)
                .HasColumnName("Loai_khach_hang");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(100)
                .HasColumnName("Ten_khach_hang");
        });

        modelBuilder.Entity<VwThongTinTaiKhoan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ThongTinTaiKhoan");

            entity.Property(e => e.LoaiKhachHang)
                .HasMaxLength(20)
                .HasColumnName("Loai_khach_hang");
            entity.Property(e => e.LoaiTaiKhoan)
                .HasMaxLength(20)
                .HasColumnName("Loai_tai_khoan");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.NgayMo).HasColumnName("Ngay_mo");
            entity.Property(e => e.SoDu)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("So_du");
            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("So_tai_khoan");
            entity.Property(e => e.TenChiNhanh)
                .HasMaxLength(100)
                .HasColumnName("Ten_chi_nhanh");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(100)
                .HasColumnName("Ten_khach_hang");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasColumnName("Trang_thai");
        });

        modelBuilder.Entity<VwTop10KhachHangTienGui>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Top10KhachHang_TienGui");

            entity.Property(e => e.LoaiKhachHang)
                .HasMaxLength(20)
                .HasColumnName("Loai_khach_hang");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_khach_hang");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(100)
                .HasColumnName("Ten_khach_hang");
            entity.Property(e => e.TongTienGui)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Tong_tien_gui");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
