using bekle.Models;
using bekle.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bekle.Services.Bussines
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();
        public bool Authenticate(UserAccount user)
        {
            return daoService.FindbyUser(user);


        }
        public bool register(UserAccount user)
        {
            return daoService.AddUser(user);
        }   
        public UserAccount getActiveUser()
        {
            return daoService.getActiveUser();
        }


    }
}
