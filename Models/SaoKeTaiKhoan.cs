using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class SaoKeTaiKhoan
{
    public string SoTaiKhoan { get; set; } = null!;

    public string Ky { get; set; } = null!;

    public DateOnly? NgayIn { get; set; }

    public decimal? SoDuCuoiKy { get; set; }

    public virtual TaiKhoan SoTaiKhoanNavigation { get; set; } = null!;
}
