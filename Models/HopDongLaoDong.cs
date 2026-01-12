using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class HopDongLaoDong
{
    public int MaHopDong { get; set; }

    public int? MaNhanVien { get; set; }

    public string? LoaiHopDong { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public decimal? MucLuong { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
