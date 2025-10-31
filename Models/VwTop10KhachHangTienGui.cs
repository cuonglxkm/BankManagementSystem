using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class VwTop10KhachHangTienGui
{
    public string MaKhachHang { get; set; } = null!;

    public string? TenKhachHang { get; set; }

    public string LoaiKhachHang { get; set; } = null!;

    public decimal? TongTienGui { get; set; }
}
