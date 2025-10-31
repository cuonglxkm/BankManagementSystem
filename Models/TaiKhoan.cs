using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class TaiKhoan
{
    public string SoTaiKhoan { get; set; } = null!;

    public string LoaiTaiKhoan { get; set; } = null!;

    public DateOnly NgayMo { get; set; }

    public string? TrangThai { get; set; }

    public string? TienTe { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public string MaNhanVienMo { get; set; } = null!;

    public string? MaKeHoachLaiSuat { get; set; }

    public virtual ICollection<ChiTietLuong> ChiTietLuongs { get; set; } = new List<ChiTietLuong>();

    public virtual CreditAcc? CreditAcc { get; set; }

    public virtual DebitAcc? DebitAcc { get; set; }

    public virtual ICollection<GiaoDich> GiaoDichSoTaiKhoanDichNavigations { get; set; } = new List<GiaoDich>();

    public virtual ICollection<GiaoDich> GiaoDichSoTaiKhoanNguonNavigations { get; set; } = new List<GiaoDich>();

    public virtual LoanAcc? LoanAcc { get; set; }

    public virtual KeHoachLaiSuat? MaKeHoachLaiSuatNavigation { get; set; }

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual NhanVien MaNhanVienMoNavigation { get; set; } = null!;

    public virtual ICollection<SaoKeTaiKhoan> SaoKeTaiKhoans { get; set; } = new List<SaoKeTaiKhoan>();

    public virtual SavingAcc? SavingAcc { get; set; }
}
