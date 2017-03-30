using Microsoft.AspNetCore.Mvc.Filters;

namespace PlayFactory.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// Filter that disables Controller and / or Action UnitOfWork.
    /// </summary>
    public class DisableUnitOfWorkAttribute : ActionFilterAttribute
    {
       
    }
}
