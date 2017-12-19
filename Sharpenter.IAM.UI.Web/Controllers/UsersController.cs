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
        private readonly ICreateUserInteractor _createUserInteractor;

        public UsersController(IListUserInteractor listUserInteractor, ICreateUserInteractor createUserInteractor)
        {
            _listUserInteractor = listUserInteractor;
            _createUserInteractor = createUserInteractor;
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
            var response = _createUserInteractor.Create(request);
            return Json(response);
        }
    }
}