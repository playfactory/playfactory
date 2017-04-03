using Microsoft.EntityFrameworkCore;
using PlayFactory.UnitOfWork;

namespace PlayFactory.EFCore.UnitOfWork
{
    public interface IUnitOfWorkDbContext : IUnitOfWork
    {
        DbContext GetDbContext();
    }
}
