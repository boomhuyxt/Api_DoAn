using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class NghiPhep
{
    public int MaNghiPhep { get; set; }

    public int? MaNhanVien { get; set; }

    public string? LoaiNghi { get; set; }

    public DateOnly? TuNgay { get; set; }

    public DateOnly? DenNgay { get; set; }

    public string? LyDo { get; set; }

    public string? TrangThai { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
