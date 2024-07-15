using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerDemo.Filters;

public class AddGlobalMetadataDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var pathItem in swaggerDoc.Paths.Values)
        {
            foreach (var operation in pathItem.Operations.Values)
            {
                // Add a common description to all operations
                operation.Description = operation.Description ?? "This is a common description for all operations.";

                // Add a common tag to all operations
                operation.Tags = operation.Tags ?? new List<OpenApiTag>();
                operation.Tags.Add(new OpenApiTag { Name = "CommonTag" });
            }
        }
    }
}