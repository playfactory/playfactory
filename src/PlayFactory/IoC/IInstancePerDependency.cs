namespace PlayFactory.IoC
{
    /// <summary>
    /// Todas as clases que implementem esta interface poderão ser injetadas pelo Autofac, sendo instânciadas por solicitação.
    /// </summary>
    /// <remarks>O uso dessa interface é a penas por convenção do PlayFactory.</remarks>
    public interface IInstancePerDependency : IResolveIoCInstance
    {
    }
}
