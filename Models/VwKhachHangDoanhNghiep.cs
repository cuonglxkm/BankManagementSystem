using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class VwKhachHangDoanhNghiep
{
    public string MaKhachHang { get; set; } = null!;

    public string TenDoanhNghiep { get; set; } = null!;

    public string MaSoThue { get; set; } = null!;

    public string SoTaiKhoan { get; set; } = null!;

    public string LoaiTaiKhoan { get; set; } = null!;

    public decimal? SoDu { get; set; }

    public decimal? LaiSuat { get; set; }
}
