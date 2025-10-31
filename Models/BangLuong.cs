using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class BangLuong
{
    public string MaBangLuong { get; set; } = null!;

    public string MaKyLuong { get; set; } = null!;

    public string MaNhanVien { get; set; } = null!;

    public decimal? LuongCoBan { get; set; }

    public decimal? ThuongTheoTaiKhoan { get; set; }

    public decimal? TongLuong { get; set; }

    public DateOnly? NgayTinh { get; set; }

    public string? NguoiDuyet { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietLuong> ChiTietLuongs { get; set; } = new List<ChiTietLuong>();

    public virtual KyLuong MaKyLuongNavigation { get; set; } = null!;

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;

    public virtual NhanVien? NguoiDuyetNavigation { get; set; }
}
