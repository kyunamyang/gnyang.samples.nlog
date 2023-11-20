

using Microsoft.AspNetCore.Mvc.Filters;
using NLog.Fluent;

[AttributeUsage(AttributeTargets.Class)]
public class CustomLogFilter : ActionFilterAttribute
{
    private readonly NLog.Logger _logger;

    public CustomLogFilter()
    {
        _logger = NLog.LogManager.GetCurrentClassLogger();
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //check for other kinds of IActionResult if any ...
        //...
        _logger.Info($"{context.ActionDescriptor.DisplayName}");

        await next();

    }

}