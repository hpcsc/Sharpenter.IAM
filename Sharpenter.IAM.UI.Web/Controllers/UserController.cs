using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Sharpenter.IAM.UI.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Json(new
            {
                Success = true,
                Messages = new List<string>()
            });
        }
    }
}