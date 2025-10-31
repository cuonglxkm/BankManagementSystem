using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class VwGiaoDichTheoThang
{
    public string MaKhachHang { get; set; } = null!;

    public string? TenKhachHang { get; set; }

    public string LoaiKhachHang { get; set; } = null!;

    public string SoTaiKhoan { get; set; } = null!;

    public string LoaiTaiKhoan { get; set; } = null!;

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    public int? SoGiaoDich { get; set; }

    public decimal? TongTienGiaoDich { get; set; }
}
