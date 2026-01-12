using System;
using System.Collections.Generic;

namespace Api_DoAn.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public int? MaTaiKhoan { get; set; }

    public string HoTen { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();

    public virtual ICollection<HopDongLaoDong> HopDongLaoDongs { get; set; } = new List<HopDongLaoDong>();

    public virtual ICollection<LichSuCongTac> LichSuCongTacs { get; set; } = new List<LichSuCongTac>();

    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();

    public virtual PhongBan MaNhanVienNavigation { get; set; } = null!;

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }

    public virtual ICollection<NghiPhep> NghiPheps { get; set; } = new List<NghiPhep>();
}
