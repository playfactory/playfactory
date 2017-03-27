using Autofac.Core;

namespace PlayFactory.Modules
{
    /// <summary>
    /// Essa interface deve ser implementada por todos os módulos da aplicação para identificá-los por convenção.
    /// </summary>
    public interface IPlayFactoryModule : IModule
    {
        bool AutoLoad();
    }
}
