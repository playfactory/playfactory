using PlayFactory.IoC;

namespace PlayFactory.AplicationService
{
    /// <summary>
    /// Essa interface deve ser implementada por todos os serviços de aplicação (Application Service) para identificá-los por convenção.
    /// </summary>
    public interface IApplicationService : IInstancePerDependency
    {
    }
}
