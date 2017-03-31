using Microsoft.AspNetCore.Mvc;

namespace PlayFactory.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// Attribute that implements UnitOfWork.
    /// </summary>
    public class UnitOfWorkAttribute : TypeFilterAttribute
    {
        public UnitOfWorkAttribute() : base(typeof(UnitOfWorkFilter))
        {
        }

        
    }
}
