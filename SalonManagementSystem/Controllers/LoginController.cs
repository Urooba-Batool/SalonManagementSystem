using Microsoft.AspNetCore.Mvc;
using SalonManagementSystem.DAL;
using SalonManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SalonManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly DBHelper _db;

        public LoginController(DBHelper db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@Role", l.UserRole),
                new SqlParameter("@Password", l.UserPassword)
            };

            DataTable dt = _db.GetData("sp_LoginUser", p);

            if (dt.Rows.Count > 0)
            {
                string role = dt.Rows[0]["UserRole"].ToString();

                if (role == "Admin")
                    return RedirectToAction("AdminDashboard");

                else
                    return RedirectToAction("StaffDashboard");
            }

            ViewBag.Error = "Invalid login!";
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult StaffDashboard()
        {
            return View();
        }
    }
}