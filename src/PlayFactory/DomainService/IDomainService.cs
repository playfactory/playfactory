using PlayFactory.IoC;

namespace PlayFactory.DomainService
{
    /// <summary>
    /// This interface must be implemented by all Domain Services to identify them by convention.
    /// </summary>
    public interface IDomainService : IInstancePerDependency
    {
    }
}
