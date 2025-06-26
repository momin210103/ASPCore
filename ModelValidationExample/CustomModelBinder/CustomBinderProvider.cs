using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelValidationExample.Models;

namespace ModelValidationExample.CustomModelBinder
{
    public class CustomBinderProvider: IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
            {
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            }
            return null;
        }
    }
    
}
