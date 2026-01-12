using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class TaiKhoan
{
    public int MaTaiKhoan { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhauHash { get; set; } = null!;

    public string? Email { get; set; }

    public string? SoDienThoai { get; set; }

    public string? AnhDaiDien { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual NhanVien? NhanVien { get; set; }

    public virtual ICollection<TepTin> TepTins { get; set; } = new List<TepTin>();

    public virtual ICollection<VaiTro> MaVaiTros { get; set; } = new List<VaiTro>();
}
