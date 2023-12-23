namespace WebApi.Authorization
{
    // a custom AllowAnonymous attribute instead of using .NET Core framework (Microsoft.AspNetCore.Authorization)
    // for consistency with the other custom auth classes in the project and to avoid ambiguous reference errors between namespaces.
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}
