//var builder = WebApplication.CreateBuilder(args);
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "MyRoot"
});
var app = builder.Build();

app.UseStaticFiles();//Works for the wwwroot and MyRoot folder

//For More than one static file Customize folder
app.UseStaticFiles(new StaticFileOptions() //Works for MyWebRoot
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"MyWebRoot"))
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        context.Response.WriteAsync("Hello!");
    });
});

app.Run();
