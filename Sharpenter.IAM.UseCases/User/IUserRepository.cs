using System.Collections.Generic;

namespace Sharpenter.IAM.UseCases.User
{
    public interface IUserRepository
    {
        IList<Core.User> FindAll();
        void Add(Core.User user);
    }
}