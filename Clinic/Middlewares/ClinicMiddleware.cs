namespace clinic.Middlewares
{
    public class ClinicMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ClinicMiddleware> _logger;

        private readonly TimeSpan _StartTimeOpen = new TimeSpan(9, 0, 0);
        private readonly TimeSpan _EndTimeOpen = new TimeSpan(10, 0, 0);

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
                Console.WriteLine("שבת באתר סגור!");

                return;
            }
            var currentTime = DateTime.Now.TimeOfDay;
           
            await _next(context);

        }
        

    }
}
