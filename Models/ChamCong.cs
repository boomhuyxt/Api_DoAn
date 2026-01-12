using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class ChamCong
{
    public int MaChamCong { get; set; }

    public int? MaNhanVien { get; set; }

    public DateOnly? NgayLamViec { get; set; }

    public TimeOnly? GioVao { get; set; }

    public TimeOnly? GioRa { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
