using Hellang.Middleware.ProblemDetails;

namespace DDD.API.ProblemDetailsMapping
{
    public static class ExceptionMapping
    {
        public static ProblemDetailsOptions Configure(this ProblemDetailsOptions options) 
        {
            options.IncludeExceptionDetails = (ctx, env) => false;

            return options;
        }
    }
}
