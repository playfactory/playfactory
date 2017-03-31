namespace PlayFactory.AspNetCore.Mvc.Filters.UnitOfWork
{
    /// <summary>
    /// Filter that disables Controller and / or Action UnitOfWork.
    /// </summary>
    public class DisableUnitOfWorkAttribute : OverrideFilter
    {
        public DisableUnitOfWorkAttribute()
            :base(typeof(UnitOfWorkFilter))
        {
            
        }
    }
}
