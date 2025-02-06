using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger.Swaggers
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // Check if the property is an enum
            if (context.Type.IsEnum)
            {
                // Change the schema type to string for enums
                schema.Type = "string";

                // Convert enum values to strings and add them to the schema
                schema.Enum = Enum.GetNames(context.Type)
                                  .Select(name => new OpenApiString(name))
                                  .Cast<IOpenApiAny>()
                                  .ToList();
            }
        }
    }
}
