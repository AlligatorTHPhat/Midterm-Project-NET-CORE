using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GiuaKyNetCore_Nhom6.Models;
using GiuaKyNetCore_Nhom6.Data;
namespace GiuaKyNetCore_Nhom6.Controllers
{
    public class NhaXuatBanController : Controller
    {
        private readonly QLThuVienContext _context;

        public NhaXuatBanController(QLThuVienContext context)
        {
            _context = context;
        }

        [Route("nha-xuat-ban/thong-ke-sach-muon")]
        public IActionResult ThongKeSachMuon()
        {
            var data = _context.Nhaxuatbans
                .Select(nxb => new ThongKeNxbViewModel
                {
                    MaNXB = nxb.MaNxb,
                    TenNXB = nxb.TenNxb,
                    SoLuongSachDangMuon = nxb.Saches.Count(s => s.MaPhieuMuons.Any())
                }).ToList();

            return View(data);
        }
    }
}
