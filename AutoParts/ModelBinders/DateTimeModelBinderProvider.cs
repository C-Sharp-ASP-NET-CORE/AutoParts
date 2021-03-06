using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutoParts.ModelBinders
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string customDateFormat;

        public DateTimeModelBinderProvider(string _customDateFormat)
        {
            customDateFormat = _customDateFormat;
        }

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(customDateFormat);
            }

            return null;
        }
    }
}
