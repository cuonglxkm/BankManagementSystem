using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class KeHoachLaiSuat
{
    public string MaKeHoachLaiSuat { get; set; } = null!;

    public string? LoaiTaiKhoanApDung { get; set; }

    public decimal? LaiSuatNam { get; set; }

    public DateOnly? HieuLucTu { get; set; }

    public DateOnly? HieuLucDen { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
