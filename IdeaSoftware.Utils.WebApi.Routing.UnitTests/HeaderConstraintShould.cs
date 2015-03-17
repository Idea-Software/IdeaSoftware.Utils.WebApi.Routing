using System.Net.Http;
using System.Web.Http.Routing;
using FluentAssertions;
using NUnit.Framework;

namespace IdeaSoftware.Utils.WebApi.Routing.UnitTests
{
    [TestFixture]
    public class HeaderConstraintShould
    {
        [Test]
        public void ReturnTrue_OnMatch_WithCorrectHeaders()
        {
            var constraintUnderTest = new HeaderConstraint("test_abc", "bbb");
            var request = new HttpRequestMessage();
            request.Headers.Add("test_abc", "bbb");
            constraintUnderTest.Match(request, null, null, null, default(HttpRouteDirection)).Should().BeTrue();

        }
        [Test]
        public void ReturnFalse_OnMatch_WithCorrectHeaders()
        {
            var constraintUnderTest = new HeaderConstraint("test_abc", "bbb");
            var request = new HttpRequestMessage();
            request.Headers.Add("test_abc", "ccc");
            constraintUnderTest.Match(request, null, null, null, default(HttpRouteDirection)).Should().BeFalse();
        }
        [Test]
        public void ReturnTrue_OnMatch_WithCorrectHeaders_AndWildcardHeaderValue()
        {
            var constraintUnderTest = new HeaderConstraint("test_abc", "*");
            var request = new HttpRequestMessage();
            request.Headers.Add("test_abc", "ddd");
            constraintUnderTest.Match(request, null, null, null, default(HttpRouteDirection)).Should().BeTrue();
        }
        [Test]
        public void ReturnTrue_OnMatch_WithCorrectHeaders_AndExclusiveHeaderValue()
        {
            var constraintUnderTest = new HeaderConstraint("test_abc", "!eee");
            var request = new HttpRequestMessage();
            request.Headers.Add("test_abc", "fff");
            constraintUnderTest.Match(request, null, null, null, default(HttpRouteDirection)).Should().BeTrue();
        }
        [Test]
        public void ReturnFalse_OnMatch_WithIncorrectHeaders_AndExclusiveHeaderValue()
        {
            var constraintUnderTest = new HeaderConstraint("test_abc", "!ggg");
            var request = new HttpRequestMessage();
            request.Headers.Add("test_abc", "ggg");
            constraintUnderTest.Match(request, null, null, null, default(HttpRouteDirection)).Should().BeFalse();
        }

    }
}
