using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class LichSuCongTac
{
    public int MaLichSu { get; set; }

    public int? MaNhanVien { get; set; }

    public int? PhongBanCu { get; set; }

    public int? PhongBanMoi { get; set; }

    public int? ChucVuCu { get; set; }

    public int? ChucVuMoi { get; set; }

    public DateOnly? NgayThayDoi { get; set; }

    public string? GhiChu { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
