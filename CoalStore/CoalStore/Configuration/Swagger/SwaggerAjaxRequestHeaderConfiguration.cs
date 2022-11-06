using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CoalStore.API.Configuration.Swagger
{
    internal sealed class SwaggerAjaxRequestHeaderConfiguration : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Requested-With",
                In = ParameterLocation.Header,
                Example = new OpenApiString("XMLHttpRequest"),
                Required = false,
            });
        }
    }
}
