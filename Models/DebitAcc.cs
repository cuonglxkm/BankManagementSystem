using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models;

public partial class DebitAcc
{
    public string SoTaiKhoan { get; set; } = null!;

    public decimal? SoDu { get; set; }

    public decimal? DuToiThieu { get; set; }

    public decimal? SoTienGuiBanDau { get; set; }

    public decimal? LaiSuatNam { get; set; }

    public virtual TaiKhoan SoTaiKhoanNavigation { get; set; } = null!;
}
