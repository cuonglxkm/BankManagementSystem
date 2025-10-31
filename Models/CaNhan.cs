using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class CaNhan
{
    public string MaKhachHang { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string SoCmndCccd { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
