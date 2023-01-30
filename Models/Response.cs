using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ustrack_api.utils;
namespace ustrack_api.Models
{
	public class Response
	{
		[JsonProperty("message")]
		private Object message;
        private CodeStatusEnum status;
		public Response(Object message, CodeStatusEnum status = CodeStatusEnum.success)
		{
			this.message = message;
			this.status = status;
		}

		public JsonResult Json()
		{
			JsonResult response = new JsonResult(this);
			response.StatusCode = (int) this.status;
			return response;

        }
    }
}

