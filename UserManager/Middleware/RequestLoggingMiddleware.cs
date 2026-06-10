using System.Text;

namespace UserManagerAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private static readonly object lockObj = new object();

        public RequestLoggingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            var start = DateTime.UtcNow;

            var ip = context.Connection.RemoteIpAddress?.ToString();
            var method = context.Request.Method;
            var path = context.Request.Path;
            var host = Environment.MachineName;

            var clientName = context.Request.Headers["X-Client-Name"].ToString();
            var apiKey = context.Request.Headers["X-AUTH-KEY"].ToString();

            try
            {
                await _next(context);

                var log = BuildLog("Info", start, ip, clientName, host, method, path, "", "Request completed");

                WriteLog(log);
            }
            catch (Exception ex)
            {
                var log = BuildLog("Error", start, ip, clientName, host, method, path, "", ex.Message);

                WriteLog(log);
                throw;
            }
        }

        private string BuildLog(string level, DateTime time, string ip, string client, string host, string method, string path, string parameters, string message)
        {
            return $"{level} | {time:yyyy-MM-dd HH:mm:ss} | {ip} | {client} | {host} | {method} {path} | {parameters} | {message}";
        }

        private void WriteLog(string log)
        {
            var logDir = Path.Combine(_env.ContentRootPath, "Logs");
            Directory.CreateDirectory(logDir);

            var file = Path.Combine(logDir, $"log-{DateTime.UtcNow:yyyy-MM-dd}.txt");
            lock (lockObj) { 
                File.AppendAllText(file, log + Environment.NewLine, Encoding.UTF8);
            }
        }
    }
}
