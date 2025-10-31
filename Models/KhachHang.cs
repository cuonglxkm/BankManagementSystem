using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string LoaiKhachHang { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public virtual CaNhan? CaNhan { get; set; }

    public virtual KhachHangChiNhanh? KhachHangChiNhanh { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();

    public virtual ToChuc? ToChuc { get; set; }
}
