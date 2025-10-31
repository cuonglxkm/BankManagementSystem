using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class ChiTietLuong
{
    public string MaChiTiet { get; set; } = null!;

    public string MaBangLuong { get; set; } = null!;

    public string? LoaiMuc { get; set; }

    public string? SoTaiKhoanLienQuan { get; set; }

    public decimal? SoTienGoc { get; set; }

    public decimal? TyLe { get; set; }

    public decimal? SoTienThuong { get; set; }

    public virtual BangLuong MaBangLuongNavigation { get; set; } = null!;

    public virtual TaiKhoan? SoTaiKhoanLienQuanNavigation { get; set; }
}
