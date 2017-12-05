using FreeezeWebApp.Models.Application.Entities;
using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class LoginController : Controller
    {
        public DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppLogin login)
        {
            if (this.ModelState.IsValid)
            {
                DBLoginRepository loginRepository = new DBLoginRepository(this.DatabaseContext);
                DBEditorRepository editorRepository = new DBEditorRepository(this.DatabaseContext);

                DBEditor editor = editorRepository.Find(login.Username);

                if (editor == null ||
                    login.Username != editor.Username ||
                    new PasswordHasher().Hash(login.Password, editor.PasswordSalt) != editor.PasswordHash)
                {
                    throw new NotImplementedException("Return user not found exception");
                } //neexistuje nebo nesedí přihlašovací údaje

                //Request
                //TODO: Check user login
                throw new NotImplementedException();
            }
            return View();
        }
    }
}