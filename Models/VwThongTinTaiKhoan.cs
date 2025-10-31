using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class VwThongTinTaiKhoan
{
    public string SoTaiKhoan { get; set; } = null!;

    public string LoaiTaiKhoan { get; set; } = null!;

    public DateOnly NgayMo { get; set; }

    public string? TrangThai { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public string? TenKhachHang { get; set; }

    public string LoaiKhachHang { get; set; } = null!;

    public string TenChiNhanh { get; set; } = null!;

    public decimal? SoDu { get; set; }
}
