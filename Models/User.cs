using System;
using System.ComponentModel.DataAnnotations;

namespace ustrack_api.Models
{
	public class User
	{
		[Key]
		public int idUser { get; set; }
		public string email { get; set; }
		public string name { get; set; }
		public string password { get; set; }
	}
}

