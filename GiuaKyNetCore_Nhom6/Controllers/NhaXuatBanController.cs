using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GiuaKyNetCore_Nhom6.Models;
namespace GiuaKyNetCore_Nhom6.Controllers
{
    public class NhaXuatBanController : Controller
    {
        private readonly QlthuvienContext _context;

        public NhaXuatBanController(QlthuvienContext context)
        {
            _context = context;
        }

        [Route("nha-xuat-ban/thong-ke-sach-muon")]
        public IActionResult ThongKeSachMuon()
        {
            // Kết hợp NXB, Sách và Chi Tiết Phiếu Mượn để đếm số lượng
            var data = _context.Nhaxuatbans
                .Select(nxb => new ThongKeNxbViewModel
                {
                    MaNXB = nxb.MaNxb,
                    TenNXB = nxb.TenNxb,
                    // Đếm số lần các sách của NXB này xuất hiện trong phiếu mượn
                    SoLuongSachDangMuon = _context.Chitietphieumuons
                        .Count(ct => ct.MaSachNavigation.MaNxb == nxb.MaNxb)
                }).ToList();

            return View(data);
        }
    }
}
