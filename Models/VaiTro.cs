using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class VaiTro
{
    public int MaVaiTro { get; set; }

    public string MaCode { get; set; } = null!;

    public string TenVaiTro { get; set; } = null!;

    public virtual ICollection<TaiKhoan> MaTaiKhoans { get; set; } = new List<TaiKhoan>();
}
