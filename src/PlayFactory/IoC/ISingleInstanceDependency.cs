namespace PlayFactory.IoC
{
    /// <summary>
    /// All classes that implement the interface will be injected by Autofac, being instantiated one per application (Pattern Singleton).
    /// </summary>
    /// <remarks>The use of this interface is only by PlayFactory convention.</remarks>
    public interface ISingleInstanceDependency : IResolveIoCInstance
    {
    }
}
