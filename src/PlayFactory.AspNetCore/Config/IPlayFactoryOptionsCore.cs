using System.Collections.Generic;
using PlayFactory.AspNetCore.Types;
using PlayFactory.IoC;

namespace PlayFactory.AspNetCore.Config
{
    /// <summary>
    /// Configuration Interface for PlayFactory ASP.NET Core
    /// </summary>
    public interface IPlayFactoryOptionsCore : ISingleInstanceDependency
    {
        /// <summary>
        /// Defines verbs that initiate a transaction control.
        /// </summary>
        IEnumerable<VerbsHttpMethod> AllowTransactionVerbsHttp{ get; set; }
    }
}