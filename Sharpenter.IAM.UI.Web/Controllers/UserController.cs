using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sharpenter.IAM.UseCases.User.DTO;

namespace Sharpenter.IAM.UI.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new
            {
                Success = true,
                Messages = new List<string>()
            });
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]CreateUserRequest request)
        {
            return Json(new
            {
                Success = true,
                Messages = new List<string>()
            });
        }
    }
}