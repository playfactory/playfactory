using System;
using System.Collections.Generic;
using System.Text;
using PlayFactory.AspNetCore.Types;

namespace PlayFactory.AspNetCore.Config
{
    /// <summary>
    /// Classe de Configuração para o PlayFactory ASP.NET Core
    /// </summary>
    public class PlayFactoryOptionsCore : IPlayFactoryOptionsCore
    {
        /// <summary>
        /// Define os verbos que iniciará um controle de transação. Por Padrão o Controle de transação será iniciado
        /// para os verbos http: Post, Put, Update e Delete. 
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
