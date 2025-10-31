using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class KhachHangChiNhanh
{
    public string MaKhachHang { get; set; } = null!;

    public string? MaChiNhanh { get; set; }

    public virtual ChiNhanh? MaChiNhanhNavigation { get; set; }

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
