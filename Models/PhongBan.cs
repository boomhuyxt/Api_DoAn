using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class PhongBan
{
    public int MaPhongBan { get; set; }

    public string? TenPhongBan { get; set; }

    public virtual NhanVien? NhanVien { get; set; }
}
