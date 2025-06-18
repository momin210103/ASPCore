
namespace RoutingBasics
{
    public class MonthConstraint: IRouteConstraint
    {
        private static readonly string[] validmonths = { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var value)) return false;
            return validmonths.Contains(value?.ToString()?.ToLower());
            
        }
    }
}
