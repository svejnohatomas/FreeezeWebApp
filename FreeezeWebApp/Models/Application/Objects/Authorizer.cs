using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Web;

namespace FreeezeWebApp.Models.Application.Objects
{
    internal sealed class Authorizer
    {
        private DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();

        internal bool IsLogedIn(HttpSessionStateBase httpSession)
        {
            return (httpSession["authorized"] is DBLogin sessionLogin && sessionLogin.UTCLogoutTime >= DateTime.UtcNow);
        }
        internal void ReauthorizeLogin(HttpSessionStateBase httpSession)
        {
            DBLoginRepository loginRepository = new DBLoginRepository(this.DatabaseContext);
            DBLogin login = loginRepository.Find((httpSession["authorized"] as DBLogin).ID);
            login.UTCLogoutTime = DateTime.UtcNow.AddMinutes(10);
            loginRepository.Update(login, true);
            httpSession["authorized"] = login;
        }
    }
}