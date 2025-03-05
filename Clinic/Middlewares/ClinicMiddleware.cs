namespace clinic.Middlewares
{
    public class ClinicMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ClinicMiddleware> _logger;

        private readonly TimeSpan _StartTimeOpen = new TimeSpan(11, 0, 0);
        private readonly TimeSpan _EndTimeOpen = new TimeSpan(22, 0, 0);

        public ClinicMiddleware(RequestDelegate next, ILogger<ClinicMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("שבת באתר סגור");
                return;
            }
            var currentTime = DateTime.Now.TimeOfDay;
            if (currentTime < _StartTimeOpen || currentTime > _EndTimeOpen)
            {
                context.Response.StatusCode = 503;
                await context.Response.WriteAsync("סגור!");
                Console.WriteLine("סגור!");
                return;
            }
            await _next(context);

        }
    }
}
