using GiuaKyNetCore_Nhom6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GiuaKyNetCore_Nhom6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var members = new List<Member>
            {
                new Member { Name = "Trần Hoàng Phát", StudentId = "49.01.104.107", Role = "Nhóm trưởng" },
                new Member { Name = "Lê Văn Khánh", StudentId = "49.01.104.068", Role = "CRUD" },
                new Member { Name = "Văn Hồng Quân", StudentId = "49.01.104.121", Role = "CRUD" },
                new Member { Name = "Ngô Thanh Phong", StudentId = "49.01.104.110", Role = "Import Db" },
                new Member { Name = "Con Văn Long", StudentId = "49.01.104.083", Role = "Query" }
            };

            ViewBag.GroupName = "Nhóm 6 - Đồ án Giữa Kỳ";
            return View(members);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
