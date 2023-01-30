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
            //const string query = "select * from users";
            //DataTable table = new DataTable();
            //string dataSource = _configuration.GetConnectionString("UstrackSource");
            //MySqlDataReader myReader;
            //using(MySqlConnection mycon=new MySqlConnection(dataSource))
            //{
            //     mycon.Open();
            //    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        mycon.Close();
            //    }
            //}
            JsonResult result = new JsonResult(this.context.Users.ToList());
            return result;
        }

        // For a post request, I can send Class object as parameter
        [HttpPost]
        public JsonResult register(User user)
        {
            //this.context.Users.Add(user);
            //context.SaveChanges();
            return new Response("saved").Json();
        }
    }
}
