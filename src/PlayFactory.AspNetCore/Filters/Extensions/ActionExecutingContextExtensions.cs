﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayFactory.AspNetCore.Exceptions;
using PlayFactory.AspNetCore.Types;

namespace PlayFactory.AspNetCore.Filters.Extensions
{
    /// <summary>
    /// Help para a classe ActionExecutingContext
    /// </summary>
    public static class ActionExecutingContextExtensions
    {
        /// <summary>
        /// Retorna um VerbsHttpMethod correspondente com o verbo utilizado na requisição.
        /// </summary>
        /// <param name="context">Help</param>
        /// <returns>Retorna VerbsHttpMethod correspondente a requisição.</returns>
        public static VerbsHttpMethod GetVerbs(this ActionExecutingContext context)
        {
            var method = context.HttpContext.Request.Method;

            if (HttpMethods.IsGet(method))
                return VerbsHttpMethod.Get;

            if (HttpMethods.IsPost(method))
                return VerbsHttpMethod.Post;

            if (HttpMethods.IsDelete(method))
                return VerbsHttpMethod.Delete;

            if (HttpMethods.IsPut(method))
                return VerbsHttpMethod.Put;

            if (HttpMethods.IsHead(method))
                return VerbsHttpMethod.Head;

            if (HttpMethods.IsOptions(method))
                return VerbsHttpMethod.Options;

            if (HttpMethods.IsPatch(method))
                return VerbsHttpMethod.Patch;            

            if (HttpMethods.IsTrace(method))
                return VerbsHttpMethod.Trace;

            if (HttpMethods.IsConnect(method))
                return VerbsHttpMethod.Connect;

            throw new HttpMethodNotFoundException($"Could not find the HttpMethod '{method}'");
        }
    }
}
