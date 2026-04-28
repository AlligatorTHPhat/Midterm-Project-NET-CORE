using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GiuaKyNetCore_Nhom6.Models;
using GiuaKyNetCore_Nhom6.Data;
namespace GiuaKyNetCore_Nhom6.Controllers
{
    public class PhieuMuonController : Controller
    {
        private readonly QLThuVienContext _context;

        public PhieuMuonController(QLThuVienContext context)
        {
            _context = context;
        }

        [Route("phieu-muon/{id}")]
        public IActionResult Details(int id)
        {
            var phieuMuon = _context.Phieumuonsaches
                .Include(p => p.MaDocGiaNavigation)
                .Include(p => p.MaSaches)
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
