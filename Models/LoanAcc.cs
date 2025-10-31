using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class LoanAcc
{
    public string SoTaiKhoan { get; set; } = null!;

    public decimal? DuNoGoc { get; set; }

    public int? KyHan { get; set; }

    public decimal? LaiSuatNam { get; set; }

    public decimal? SoTienGiaiNgan { get; set; }

    public DateOnly? NgayGiaiNgan { get; set; }

    public virtual TaiKhoan SoTaiKhoanNavigation { get; set; } = null!;
}
