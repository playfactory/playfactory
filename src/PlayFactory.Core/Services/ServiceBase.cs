using PlayFactory.UnitOfWork;

namespace PlayFactory.Core.Services
{
    public abstract class ServiceBase
    {
        public IActiveUnitOfWork CurrentUnitOfWork { get; set; }
    }
}
