namespace PlayFactory.Entity
{
    /// <summary>
    /// Interface base para as entidade com Id tipo Int.
    /// </summary>
    public interface IEntity : IEntity<int>
    {
       
    }

    /// <summary>
    /// Interface base para as entidades com Id genérico.
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IEntity<TPrimaryKey> 
    {
        /// <summary>
        /// Id da entidade.
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// Verifica se a entidade possui o Id com valor default ou foi atribuído um Id.
        /// </summary>
        /// <returns></returns>
        bool IsTransient();
    }
}
