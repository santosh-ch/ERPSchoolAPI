using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolAPI
{
    public class IntegerArrayBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;
            var isQueryParamFound = data.TryGetValue("ids", out var idString);
            if (isQueryParamFound)
            {
                int[] ids = idString.ToString().Split(',').Select(x=>Convert.ToInt32(x)).ToArray();
                bindingContext.Result = ModelBindingResult.Success(ids);
            }
            return Task.CompletedTask;
        }
    }
}
