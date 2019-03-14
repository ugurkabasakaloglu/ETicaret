using ETicaretWebMvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ETicaretWebMvc.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roles
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="admin",Description= "yönetici rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="user", Description="kullanıcı rolü" };
                manager.Create(role);
            }
            //Users
            if (!context.Users.Any(i => i.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Admin", SurName = "Admin", UserName = "admin", Email = "admin@gmail.com"};
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id,"admin");
            }
            if (!context.Users.Any(i => i.UserName == "ugur"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() {Name="Uğur" ,SurName= "Kabasakaloğlu", UserName="ugur", Email="ugurkabasakaloglu@gmail.com"};
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id,"user");
                }
            base.Seed(context);
        }
    }
}