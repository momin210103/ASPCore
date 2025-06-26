using ModelValidationExample.CustomModelBinder; // Ensure this namespace is correct and contains PersonBinderProvider

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
