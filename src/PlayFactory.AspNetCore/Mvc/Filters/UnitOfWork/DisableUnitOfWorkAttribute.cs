namespace PlayFactory.AspNetCore.Mvc.Filters
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
