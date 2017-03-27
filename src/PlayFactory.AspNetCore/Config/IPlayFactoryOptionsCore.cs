using System.Collections.Generic;
using PlayFactory.AspNetCore.Types;
using PlayFactory.IoC;

namespace PlayFactory.AspNetCore.Config
{
    /// <summary>
    /// Interface de Configuração para PlayFactory ASP.NET Core
    /// </summary>
    public interface IPlayFactoryOptionsCore : ISingleInstanceDependency
    {
        /// <summary>
        /// Define os verbos que iniciará um controle de transação.
        /// </summary>
        IEnumerable<VerbsHttpMethod> AllowTransactionVerbsHttp{ get; set; }
    }
}