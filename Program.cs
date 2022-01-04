using System.IO.Compression;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.ResponseCompression;
using LibraryApi.Config;
using LibraryApi.Services.Errors;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

// Add services to the container.
builder.Services.ConfigureSQLServer(config, env);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().ConfigureApiBehaviours();
builder.Services.RegisterApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSwaggerGen("Library API", "Documentação de auxílio para integração");
builder.Services.AddCors();
builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
builder.Services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.RegisterApiVersioning();
builder.Services.ConfigureServices();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.RegisterSwaggerUI(
        "Library API Documentation",
        app.Services.GetRequiredService<IApiVersionDescriptionProvider>()
    );
}
app.UseCors(options => {
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseRouting();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapControllers();
app.Run();
