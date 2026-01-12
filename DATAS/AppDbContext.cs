using System;
using System.Collections.Generic;
using Api_DoAn.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_DoAn.DATAS;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChamCong> ChamCongs { get; set; }

    public virtual DbSet<HopDongLaoDong> HopDongLaoDongs { get; set; }

    public virtual DbSet<LichSuCongTac> LichSuCongTacs { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<NghiPhep> NghiPheps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TepTin> TepTins { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=api_w_a_m;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChamCong>(entity =>
        {
            entity.HasKey(e => e.MaChamCong).HasName("PK__ChamCong__307331A128C1B8B8");

            entity.ToTable("ChamCong");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.ChamCongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__ChamCong__MaNhan__3C69FB99");
        });

        modelBuilder.Entity<HopDongLaoDong>(entity =>
        {
            entity.HasKey(e => e.MaHopDong).HasName("PK__HopDongL__36DD4342DB983199");

            entity.ToTable("HopDongLaoDong");

            entity.Property(e => e.LoaiHopDong).HasMaxLength(50);
            entity.Property(e => e.MucLuong).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HopDongLaoDongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HopDongLa__MaNha__45F365D3");
        });

        modelBuilder.Entity<LichSuCongTac>(entity =>
        {
            entity.HasKey(e => e.MaLichSu).HasName("PK__LichSuCo__C443222A79498402");

            entity.ToTable("LichSuCongTac");

            entity.Property(e => e.GhiChu).HasMaxLength(255);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.LichSuCongTacs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__LichSuCon__MaNha__398D8EEE");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK__Luong__6609A48D8D37E05F");

            entity.ToTable("Luong");

            entity.Property(e => e.KhauTru).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Thuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongLuong)
                .HasComputedColumnSql("(([LuongCoBan]+[Thuong])-[KhauTru])", false)
                .HasColumnType("decimal(20, 2)");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__Luong__MaNhanVie__4316F928");
        });

        modelBuilder.Entity<NghiPhep>(entity =>
        {
            entity.HasKey(e => e.MaNghiPhep).HasName("PK__NghiPhep__1ED7CDB4A2E5EFA2");

            entity.ToTable("NghiPhep");

            entity.Property(e => e.LoaiNghi).HasMaxLength(50);
            entity.Property(e => e.LyDo).HasMaxLength(255);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Chờ duyệt", "DF__NghiPhep__TrangT__3F466844");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.NghiPheps)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__NghiPhep__MaNhan__403A8C7D");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA474FF3C233");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.MaTaiKhoan, "UQ__NhanVien__AD7C6528DE268AC4").IsUnique();

            entity.Property(e => e.MaNhanVien).ValueGeneratedOnAdd();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(150);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Đang làm", "DF__NhanVien__TrangT__31EC6D26");

            entity.HasOne(d => d.MaNhanVienNavigation).WithOne(p => p.NhanVien)
                .HasForeignKey<NhanVien>(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_PhongBan");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithOne(p => p.NhanVien)
                .HasForeignKey<NhanVien>(d => d.MaTaiKhoan)
                .HasConstraintName("FK__NhanVien__MaTaiK__32E0915F");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPhongBan).HasName("PK__PhongBan__D0910CC8F5B4AEDB");

            entity.ToTable("PhongBan");

            entity.Property(e => e.TenPhongBan).HasMaxLength(150);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C6529BB724361");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0FB9F5B55").IsUnique();

            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.MatKhauHash).HasMaxLength(255);
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())", "DF__TaiKhoan__NgayTa__29572725")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true, "DF__TaiKhoan__TrangT__286302EC");

            entity.HasMany(d => d.MaVaiTros).WithMany(p => p.MaTaiKhoans)
                .UsingEntity<Dictionary<string, object>>(
                    "TaiKhoanVaiTro",
                    r => r.HasOne<VaiTro>().WithMany()
                        .HasForeignKey("MaVaiTro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TaiKhoan___MaVai__2E1BDC42"),
                    l => l.HasOne<TaiKhoan>().WithMany()
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TaiKhoan___MaTai__2D27B809"),
                    j =>
                    {
                        j.HasKey("MaTaiKhoan", "MaVaiTro").HasName("PK__TaiKhoan__4158A135DC1C7BF2");
                        j.ToTable("TaiKhoan_VaiTro");
                    });
        });

        modelBuilder.Entity<TepTin>(entity =>
        {
            entity.HasKey(e => e.MaTep).HasName("PK__TepTin__314EA1A80EE02ABD");

            entity.ToTable("TepTin");

            entity.Property(e => e.CongKhai).HasDefaultValue(true, "DF__TepTin__CongKhai__49C3F6B7");
            entity.Property(e => e.DuongDan).HasMaxLength(255);
            entity.Property(e => e.NgayTai)
                .HasDefaultValueSql("(getdate())", "DF__TepTin__NgayTai__48CFD27E")
                .HasColumnType("datetime");
            entity.Property(e => e.TenTep).HasMaxLength(255);

            entity.HasOne(d => d.NguoiTaiLenNavigation).WithMany(p => p.TepTins)
                .HasForeignKey(d => d.NguoiTaiLen)
                .HasConstraintName("FK__TepTin__NguoiTai__4AB81AF0");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.MaVaiTro).HasName("PK__VaiTro__C24C41CF4EB4687F");

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.MaCode, "UQ__VaiTro__152C7C5CEFDA1B89").IsUnique();

            entity.Property(e => e.MaCode).HasMaxLength(50);
            entity.Property(e => e.TenVaiTro).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
