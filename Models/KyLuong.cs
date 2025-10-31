using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class KyLuong
{
    public string MaKyLuong { get; set; } = null!;

    public string Thang { get; set; } = null!;

    public DateOnly? TuNgay { get; set; }

    public DateOnly? DenNgay { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<BangLuong> BangLuongs { get; set; } = new List<BangLuong>();
}
