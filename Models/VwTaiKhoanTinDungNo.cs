using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class VwTaiKhoanTinDungNo
{
    public string SoTaiKhoan { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public string? TenKhachHang { get; set; }

    public string LoaiKhachHang { get; set; } = null!;

    public decimal? HanMucTinDung { get; set; }

    public decimal? DuNoHienTai { get; set; }

    public decimal? ConLaiCoTheVay { get; set; }
}
