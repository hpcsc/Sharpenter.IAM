using System.Collections.Generic;
using System.Linq;
using Sharpenter.IAM.UseCases.User.DTO;

namespace Sharpenter.IAM.UseCases.User
{
    internal class ListUserInteractor : IListUserInteractor
    {
        private readonly IUserRepository _userRepository;

        public ListUserInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Response<List<UserDTO>> List()
        {
            var users = _userRepository.FindAll();
            return Response<List<UserDTO>>.Succeed(users.Select(u => new UserDTO
            {
               Id = u.Id,
               Username =  u.Username
            }).ToList());
        }
    }
}