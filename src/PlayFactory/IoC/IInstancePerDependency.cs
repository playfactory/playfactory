namespace PlayFactory.IoC
{
    /// <summary>
    /// All classes that implement the interface can be injected by Autofac, being instantiated by request of the instance.
    /// </summary>
    /// <remarks>The use of this interface is only by PlayFactory convention.</remarks>
    public interface IInstancePerDependency : IResolveIoCInstance
    {

    }
}
