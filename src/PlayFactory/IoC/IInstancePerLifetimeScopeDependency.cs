namespace PlayFactory.IoC
{
    /// <summary>
    /// Todas as clases que implementem esta interface poderão ser injetadas pelo Autofac, sendo instânciadas uma classe por requisição.
    /// </summary>
    /// <remarks>O uso dessa interface é a penas por convenção do PlayFactory.</remarks>
    public interface IInstancePerLifetimeScopeDependency : IResolveIoCInstance
    {
    }
}
