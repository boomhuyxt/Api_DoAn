using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class Luong
{
    public int MaLuong { get; set; }

    public int? MaNhanVien { get; set; }

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    public decimal? LuongCoBan { get; set; }

    public decimal? Thuong { get; set; }

    public decimal? KhauTru { get; set; }

    public decimal? TongLuong { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
