using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class ToChuc
{
    public string MaKhachHang { get; set; } = null!;

    public string TenToChuc { get; set; } = null!;

    public string MaSoThue { get; set; } = null!;

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
