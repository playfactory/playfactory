using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayFactory.AspNetCore.Config;
using PlayFactory.AspNetCore.Mvc.Filters.Extensions;
using PlayFactory.EFCore.UnitOfWork;

namespace PlayFactory.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// Filter that implements UnitOfWork.
    /// </summary>
    public class UnitOfWorkAttribute : IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayFactoryOptionsCore _options;
        private bool _allowUnitOfWork;

        public UnitOfWorkAttribute(IUnitOfWork unitOfWork, IPlayFactoryOptionsCore options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
            _allowUnitOfWork = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (IsDisable(context.ActionDescriptor))
                return;

            var method = context.GetVerbs();

            _allowUnitOfWork = _options.AllowTransactionVerbsHttp.Contains(method);

            if (_allowUnitOfWork)
                _unitOfWork.BeginTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (IsDisable(context.ActionDescriptor))
                return;

            if (!_allowUnitOfWork)
                return;

            try
            {
                if (context.Exception != null || !context.ModelState.IsValid)
                {
                    _unitOfWork.Roolback();
                    return;
                }

                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Roolback();
                throw;
            }

        }

        private bool IsDisable(ActionDescriptor actionDescriptor)
        {
            return
                actionDescriptor.FilterDescriptors.Any(f => f.Filter.GetType() == typeof(DisableUnitOfWorkAttribute));
        }
    }
}
