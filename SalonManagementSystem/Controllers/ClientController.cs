using SalonManagementSystem.DAL;
using SalonManagementSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace SalonManagementSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly DBHelper _db;

        public ClientController(DBHelper db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Client c)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@ClientName", c.ClientName),
                new SqlParameter("@ClientPhone", c.ClientPhone)
            };

            _db.Execute("sp_AddClient", p);

            return RedirectToAction("Index");
        }
    }
}
