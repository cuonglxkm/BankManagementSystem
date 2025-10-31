using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? ChucVu { get; set; }

    public string? MaChiNhanh { get; set; }

    public virtual ICollection<BangLuong> BangLuongMaNhanVienNavigations { get; set; } = new List<BangLuong>();

    public virtual ICollection<BangLuong> BangLuongNguoiDuyetNavigations { get; set; } = new List<BangLuong>();

    public virtual ICollection<GiaoDich> GiaoDiches { get; set; } = new List<GiaoDich>();

    public virtual ChiNhanh? MaChiNhanhNavigation { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
