using Autofac;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExam.Models
{
    public class RoleUpdateModel
    {
        public string RoleName { get; set; }

        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleUpdateModel()
        {
            _roleManager = Startup.AutofacContainer.Resolve<RoleManager<IdentityRole>>();
        }

        internal async Task AddNewRole()
        {
            await _roleManager.CreateAsync(new IdentityRole() { Name = RoleName });
        }
    }
}
