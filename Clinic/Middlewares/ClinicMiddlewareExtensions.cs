namespace clinic.Middlewares
{
    public static class ClinicMiddlewareExtensions
    {
        public static IApplicationBuilder UseClinic(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ClinicMiddleware>();
        }
    }
}
