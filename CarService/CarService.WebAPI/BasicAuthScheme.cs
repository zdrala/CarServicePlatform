using Microsoft.OpenApi.Models;

namespace CarService.WebAPI
{
   internal class BasicAuthScheme : OpenApiSecurityScheme
    {
        public string Type { get; set; }
    }
}