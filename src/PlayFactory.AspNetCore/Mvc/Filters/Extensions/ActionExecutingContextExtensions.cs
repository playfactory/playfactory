using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayFactory.AspNetCore.Exceptions;
using PlayFactory.AspNetCore.Types;

namespace PlayFactory.AspNetCore.Mvc.Filters.Extensions
{
    /// <summary>
    ///Help for the ActionExecutingContext class
    /// </summary>
    public static class ActionExecutingContextExtensions
    {
        /// <summary>
        /// Return a corresponding VerbsHttpMethod with the verb used in the request.
        /// </summary>
        /// <param name="context">ActionExecutingContext</param>
        /// <returns>Return VerbsHttpMethod corresponding to the request.</returns>
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
