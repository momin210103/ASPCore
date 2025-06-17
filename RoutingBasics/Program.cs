var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("profile/name", async context =>
    {
        context.Response.WriteAsync("Hello Momin!");

    });
});
app.Run(async context =>
{
    await context.Response.WriteAsync($"Please Enter a Route{context.Request.Path}");
});

app.Run();
