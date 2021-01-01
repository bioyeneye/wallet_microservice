using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WalletMicroservice.Common.Models.Responses;

namespace WalletMicroservice.Common.Filters
{
    /// <summary>
    /// Validation error filter
    /// </summary>
    public class ValidateModelStateActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Check if ModelState is valid.
            if (!context.ModelState.IsValid)
            {
                var validationError = context?.ModelState?
                                .Keys
                                .Where(i => context.ModelState[i].Errors.Count > 0)?
                                .Select(k => context.ModelState[k]?.Errors?.First()?.ErrorMessage)?
                                .ToList();
                var result = new BadRequestObjectResult(Response.ValidationError(validationError));

                result.ContentTypes.Add(MediaTypeNames.Application.Json);
                result.ContentTypes.Add(MediaTypeNames.Application.Xml);
                context.Result = result;
            }
            else
            {
                await next();
            }
        }
    }

}
