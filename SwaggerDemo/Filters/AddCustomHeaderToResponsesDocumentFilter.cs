using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerDemo.Filters;

public class AddCustomHeaderToResponsesDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var pathItem in swaggerDoc.Paths.Values)
        {
            foreach (var operation in pathItem.Operations.Values)
            {
                foreach (var response in operation.Responses.Values)
                {
                    response.Headers ??= new Dictionary<string, OpenApiHeader>();

                    response.Headers.Add("X-Custom-Header", new OpenApiHeader
                    {
                        Description = "This is a custom header added to all responses.",
                        Schema = new OpenApiSchema
                        {
                            Type = "string"
                        }
                    });
                }
            }
        }
    }
}