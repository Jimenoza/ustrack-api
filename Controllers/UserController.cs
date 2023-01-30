using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ustrack_api.Models;

namespace ustrack_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext context;
        public UserController(UserContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public JsonResult getUsers()
        {
            JsonResult result = new JsonResult(this.context.Users.ToList());
            return result;
        }

        // Reguster
        [HttpPost]
        public JsonResult register(User user)
        {
            this.context.Users.Add(user);
            context.SaveChanges();
            return new Response("saved").Json();
        }
    }
}
