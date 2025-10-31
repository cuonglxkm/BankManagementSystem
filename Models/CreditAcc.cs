using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class CreditAcc
{
    public string SoTaiKhoan { get; set; } = null!;

    public decimal? HanMucTinDung { get; set; }

    public decimal? DuNoHienTai { get; set; }

    public decimal? LaiSuatNam { get; set; }

    public virtual TaiKhoan SoTaiKhoanNavigation { get; set; } = null!;
}
