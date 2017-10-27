using System.Collections.Generic;
using System.Linq;
using Sharpenter.IAM.UseCases.User;

namespace Sharpenter.IAM.Repository.EntityFramework.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext _context;

        public UserRepository(IdentityContext context)
        {
            _context = context;
        }

        public IList<Core.User> FindAll()
        {
            return _context.Set<Core.User>().ToList();
        }

        public void Add(Core.User user)
        {
            _context.Set<Core.User>().Add(user);
            _context.SaveChanges();
        }
    }
}