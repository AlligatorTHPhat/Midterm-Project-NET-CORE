using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GiuaKyNetCore_Nhom6.Models;
namespace GiuaKyNetCore_Nhom6.Controllers
{
    public class PhieuMuonController : Controller
    {
        private readonly QlthuvienContext _context;

        public PhieuMuonController(QlthuvienContext context)
        {
            _context = context;
        }

        [Route("phieu-muon/{id}")]
        public IActionResult Details(int id)
        {
            // Include các bảng liên quan để lấy đủ dữ liệu Độc giả, Chi tiết PM, Sách, NXB
            var phieuMuon = _context.Phieumuonsaches
                .Include(p => p.MaDocGiaNavigation)
                .Include(p => p.Chitietphieumuons)
                    .ThenInclude(ct => ct.MaSachNavigation)
                        .ThenInclude(s => s.MaNxbNavigation)
                .FirstOrDefault(p => p.MaPhieuMuon == id);

            if (phieuMuon == null)
            {
                return NotFound("Không tìm thấy mã phiếu mượn này.");
            }

            return View(phieuMuon);
        }
    }
}
