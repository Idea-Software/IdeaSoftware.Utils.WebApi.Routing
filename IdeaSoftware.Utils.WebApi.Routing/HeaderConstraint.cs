using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;

namespace IdeaSoftware.Utils.WebApi.Routing
{
    /// <summary>
    /// Contraint the restricts route against specified header and header value.
    /// </summary>
    public class HeaderConstraint : IHttpRouteConstraint
    {
        private readonly string _header;
        private readonly string _headerValue;
        private readonly bool _exclusive;

        public HeaderConstraint(string header, string headerValue)
        {
            _header = header;

            if (headerValue.StartsWith("!"))
            {
                _exclusive = true;
                _headerValue = headerValue.Substring(1);
            }
            else
            {
                _headerValue = headerValue;
            }
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            //allow preflight
            if (request.Method == HttpMethod.Options 
                && request.Headers.Contains("Access-Control-Request-Headers")
                && request.Headers.Contains("Access-Control-Request-Method"))
                return true;

            if (!request.Headers.Contains(_header))
                return false;
            if (_headerValue == "*")
                return true;
            IEnumerable<string> headerValues;
            var isHeaderValueMatches = request.Headers.TryGetValues(_header, out headerValues) && headerValues.Contains(_headerValue);
            return _exclusive ^ isHeaderValueMatches;
        }
    }
}