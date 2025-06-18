using RoutingBasics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("month", typeof(MonthConstraint));
});
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("profile/name", async context =>
    {
        context.Response.WriteAsync("Hello Momin!");

    });
    //Sales-report/month/year
    endpoints.Map("sales-report/{month:month}/{year:range(1900,2100)}", async context =>
    {
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        int? year = Convert.ToInt32(context.Request.RouteValues["year"]);
        await context.Response.WriteAsync($"Sales Report for {month}-{year}");
    });
});
app.Run(async context =>
{
    await context.Response.WriteAsync($"Please Enter a Route{context.Request.Path}");
});

app.Run();
