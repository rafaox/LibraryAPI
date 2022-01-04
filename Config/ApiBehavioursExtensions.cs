using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services.Base;

namespace LibraryApi.Config
{
    public static class ApiBehavioursExtensions
    {
        public static IMvcBuilder ConfigureApiBehaviours(this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(options => options.Filters.Add(new ProducesAttribute("application/json")))
                .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)
                .ConfigureApiBehaviorOptions(
                    options => options.InvalidModelStateResponseFactory = context =>
                    {
                        BaseResponse<IEnumerable<string>> response = new BaseResponse<IEnumerable<string>>
                        {
                            Code = StatusCodes.Status400BadRequest,
                            Response = context.ModelState
                                .Values.SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage)
                        };

                        return new BadRequestObjectResult(response);
                    }
                );
        }
    }
}