using Sharpenter.IAM.UseCases.User.DTO;

namespace Sharpenter.IAM.UseCases.User
{
    public class CreateUserInteractor : ICreateUserInteractor
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserInteractor(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Response Create(CreateUserRequest request)
        {
            _userRepository.Add(new Core.User(request.Username));
            _unitOfWork.Commit();
            return Response.Succeed();
        }
    }
}