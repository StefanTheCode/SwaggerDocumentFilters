using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerDemo.Filters;

public class RemoveObsoleteOperationsFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var obsoletePaths = swaggerDoc.Paths
            .Where(path => path.Value.Operations
                .Any(op => op.Value.Deprecated))
            .Select(path => path.Key)
            .ToList();

        foreach (var obsoletePath in obsoletePaths)
        {
            swaggerDoc.Paths.Remove(obsoletePath);
        }
    }
}