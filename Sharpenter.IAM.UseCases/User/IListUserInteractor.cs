using System.Collections.Generic;
using Sharpenter.IAM.UseCases.User.DTO;

namespace Sharpenter.IAM.UseCases.User
{
    public interface IListUserInteractor
    {
        Response<List<UserDTO>> List();
    }
}