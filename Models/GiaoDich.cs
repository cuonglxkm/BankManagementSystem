using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class GiaoDich
{
    public string MaGiaoDich { get; set; } = null!;

    public DateTime ThoiGianGiaoDich { get; set; }

    public string LoaiGiaoDich { get; set; } = null!;

    public decimal SoTien { get; set; }

    public string? Nguon { get; set; }

    public string? GhiChu { get; set; }

    public string MaNhanVien { get; set; } = null!;

    public string? SoTaiKhoanNguon { get; set; }

    public string SoTaiKhoanDich { get; set; } = null!;

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;

    public virtual TaiKhoan SoTaiKhoanDichNavigation { get; set; } = null!;

    public virtual TaiKhoan? SoTaiKhoanNguonNavigation { get; set; }
}
