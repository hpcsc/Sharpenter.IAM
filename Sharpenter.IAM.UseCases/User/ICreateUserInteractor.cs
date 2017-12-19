using Sharpenter.IAM.UseCases.User.DTO;

namespace Sharpenter.IAM.UseCases.User
{
    public interface ICreateUserInteractor
    {
        Response Create(CreateUserRequest request);
    }
}