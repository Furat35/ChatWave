using Microsoft.AspNetCore.Http;

namespace ChatWave.Application.Helpers
{
    public class HeaderService : IHeaderService
    {
        private readonly IHttpContextAccessor _httpContext;

        public HeaderService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void AddToResponseHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                _httpContext.HttpContext?.Response.Headers.Add(header.Key, header.Value);
        }
    }

    public interface IHeaderService
    {
        void AddToResponseHeaders(Dictionary<string, string> headers);
    }
}
