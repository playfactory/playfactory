using PlayFactory.IoC;

namespace PlayFactory.DomainService
{
    /// <summary>
    /// Essa interface deve ser implementada por todos os serviços de domínio (Domain Service) para identificá-los por convenção.
    /// </summary>
    public interface IDomainService : IInstancePerDependency
    {
    }
}
