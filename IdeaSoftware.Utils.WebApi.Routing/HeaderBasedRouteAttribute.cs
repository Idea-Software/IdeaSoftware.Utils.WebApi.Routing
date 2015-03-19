using System.Collections.Generic;
using System.Web.Http.Routing;

namespace IdeaSoftware.Utils.WebApi.Routing
{
    public class HeaderBasedRouteAttribute : RouteFactoryAttribute
    {
        private readonly string _header;
        private readonly string _headerValue;

        /// <summary>
        /// Represents route constrained by HTTP header
        /// </summary>
        /// <param name="template">The route template.</param>
        /// <param name="header">Required HTTP header</param>
        /// <param name="headerValue">Required HTTP header value. Use '*' for any; Prepend with '!' to exclude Header Value;</param>
        public HeaderBasedRouteAttribute(string template, string header, string headerValue)
            : base(template)
        {
            _header = header;
            _headerValue = headerValue;
        }

        public override IDictionary<string, object> Constraints
        {
            get
            {
                return new HttpRouteValueDictionary { { "HeaderConstraint", new HeaderConstraint(_header, _headerValue) } };
            }
        }
    }
}
