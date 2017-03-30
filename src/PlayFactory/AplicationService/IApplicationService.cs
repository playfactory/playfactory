using PlayFactory.IoC;

namespace PlayFactory.AplicationService
{
    /// <summary>
    /// This interface must be implemented by all Application Service to identify them by convention.
    /// </summary>
    public interface IApplicationService : IInstancePerDependency
    {
    }
}
