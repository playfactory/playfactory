using Module = Autofac.Module;

namespace PlayFactory.Modules
{
    /// <summary>
    /// This class can be used as a base class for the application modules.
    /// </summary>
    public abstract class PlayFactoryModule: Module, IPlayFactoryModule
    {  
        /// <inheritdoc />
        public virtual bool AutoLoad()
        {
            return true;
        }
    }
}
