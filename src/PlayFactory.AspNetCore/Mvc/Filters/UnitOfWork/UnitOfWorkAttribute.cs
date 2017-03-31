using Microsoft.AspNetCore.Mvc;

namespace PlayFactory.AspNetCore.Mvc.Filters.UnitOfWork
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
