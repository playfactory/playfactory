namespace PlayFactory.IoC
{
    /// <summary>
    /// All classes that implement the interface will be injected by Autofac and will be instantiated by http request.
    /// </summary>
    /// <remarks>The use of this interface is only by PlayFactory convention.</remarks>
    public interface IInstancePerLifetimeScopeDependency : IResolveIoCInstance
    {
    }
}
