using RoutingBasics.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("profile/name", async context =>
    {
        context.Response.WriteAsync("Hello Momin!");

    });
    endpoints.Map("sales-report/{year:int:min(19000)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        if(month=="apr" || month=="jul" || month == "oct" || month == "jan")
        {
            await context.Response.WriteAsync($"Sales Report for {month} {year}");
        }

    });
});
app.Run(async context =>
{
    await context.Response.WriteAsync($"Please Enter a Route{context.Request.Path}");
});

app.Run();
