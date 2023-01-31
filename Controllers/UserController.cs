using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ustrack_api.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using ustrack_api.utils;

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

        // Register user
        [HttpPost]
        public JsonResult register(User user)
        {
            try
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(user.password);
                byte[] encrypted = new HMACSHA256().ComputeHash(data);
                user.password = Convert.ToBase64String(encrypted);
                this.context.Users.Add(user);
                context.SaveChanges();
                return new Response("saved").Json();
            }
            catch(DbUpdateException e)
            {
                return new Response("email exists", CodeStatusEnum.conflict).Json();
            }
        }
    }
}
