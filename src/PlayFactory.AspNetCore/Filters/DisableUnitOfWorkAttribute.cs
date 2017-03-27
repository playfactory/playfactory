using Microsoft.AspNetCore.Mvc.Filters;

namespace PlayFactory.AspNetCore.Filters
{
    /// <summary>
    /// Filter que desabilita o UnitOfWork da Controller e/ou da Action.
    /// </summary>
    public class DisableUnitOfWorkAttribute : ActionFilterAttribute
    {
       
    }
}
