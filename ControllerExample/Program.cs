var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();// add all the controller classess as services
var app = builder.Build();

//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers(); // map the controllers to the endpoints
//});
app.UseStaticFiles();
app.UseRouting();
app.MapControllers(); // map the controllers to the endpoints

app.Run();
