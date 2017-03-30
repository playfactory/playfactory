using System;
using System.Collections.Generic;
using System.Text;
using PlayFactory.AspNetCore.Types;

namespace PlayFactory.AspNetCore.Config
{
    /// <summary>
    /// Configuration Class for the ASP.NET Core PlayFactory
    /// </summary>
    public class PlayFactoryOptionsCore : IPlayFactoryOptionsCore
    {
        /// <summary>
        /// Defines verbs that initiate a transaction control. By default transaction control will start
        /// For the verbs http: Post, Put, Update e Delete. 
        /// </summary>
        public IEnumerable<VerbsHttpMethod> AllowTransactionVerbsHttp { get; set; }

        public PlayFactoryOptionsCore()
        {
            AllowTransactionVerbsHttp = new List<VerbsHttpMethod>
            {
                VerbsHttpMethod.Post,
                VerbsHttpMethod.Delete,
                VerbsHttpMethod.Update,
                VerbsHttpMethod.Put
            };
        }

        
    }
}
