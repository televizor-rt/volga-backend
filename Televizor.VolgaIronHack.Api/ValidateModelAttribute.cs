using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Televizor.VolgaIronHack;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ModelState.IsValid)
            return base.OnActionExecutionAsync(context, next);

        context.Result = new BadRequestObjectResult(context.ModelState);

        return Task.CompletedTask;
    }
}