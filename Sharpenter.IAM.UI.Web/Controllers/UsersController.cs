using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sharpenter.IAM.UseCases.User;
using Sharpenter.IAM.UseCases.User.DTO;

namespace Sharpenter.IAM.UI.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IListUserInteractor _listUserInteractor;

        public UsersController(IListUserInteractor listUserInteractor)
        {
            _listUserInteractor = listUserInteractor;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _listUserInteractor.List();
            return Json(response);
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