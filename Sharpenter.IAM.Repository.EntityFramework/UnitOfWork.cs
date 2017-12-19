using Sharpenter.IAM.UseCases;

namespace Sharpenter.IAM.Repository.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityContext _context;

        public UnitOfWork(IdentityContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}