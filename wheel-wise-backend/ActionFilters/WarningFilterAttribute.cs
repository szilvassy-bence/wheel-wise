using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace wheel_wise.ActionFilters;

public class WarningFilterAttribute : ActionFilterAttribute
{
    private readonly string _severity;

    public WarningFilterAttribute(string severity)
    {
        _severity = severity;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Debug.WriteLine($"Pre-Warning on {context.ActionDescriptor.DisplayName}: {_severity}");
    }

    public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
    {
        Debug.WriteLine($"Post-Warning on {actionExecutedContext.ActionDescriptor.DisplayName}: {_severity}");
    }
}