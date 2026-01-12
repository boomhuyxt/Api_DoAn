using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class TepTin
{
    public int MaTep { get; set; }

    public string? TenTep { get; set; }

    public string? DuongDan { get; set; }

    public int? NguoiTaiLen { get; set; }

    public DateTime? NgayTai { get; set; }

    public bool? CongKhai { get; set; }

    public virtual TaiKhoan? NguoiTaiLenNavigation { get; set; }
}
