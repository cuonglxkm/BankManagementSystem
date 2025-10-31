using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class ChiNhanh
{
    public string MaChiNhanh { get; set; } = null!;

    public string TenChiNhanh { get; set; } = null!;

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? MaNvQuanLy { get; set; }

    public virtual ICollection<KhachHangChiNhanh> KhachHangChiNhanhs { get; set; } = new List<KhachHangChiNhanh>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
