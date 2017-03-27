using Module = Autofac.Module;

namespace PlayFactory.Modules
{
    /// <summary>
    /// Esta classe pode ser usada como uma classe base para os módulos da aplicação.
    /// </summary>
    public abstract class PlayFactoryModule: Module, IPlayFactoryModule
    {  
        public virtual bool AutoLoad()
        {
            return true;
        }
    }
}
