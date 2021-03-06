﻿using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IdeaSoftware.Utils.WebApi.Routing.Test.Controllers
{
    public class RouteTestController : ApiController
    {
        [EnableCors("*", "*", "*", "test-abc")]
        [HeaderBasedRoute("routeA", "test-abc", "A")]
        public IHttpActionResult Get_RouteA()
        {
            if (!Request.Headers.Contains("test-abc") || Request.Headers.GetValues("test-abc").First() != "A")
                return InternalServerError(new ApplicationException("Attribute logic is flawed."));
            return Ok("Route A resolved correctly");
        }

        [EnableCors("*", "*", "*", "test-abc")]
        [HeaderBasedRoute("routeB", "test-abc", "B")]
        public IHttpActionResult Get_RouteB()
        {
            if (!Request.Headers.Contains("test-abc") || Request.Headers.GetValues("test-abc").First() != "B")
                return InternalServerError(new ApplicationException("Attribute logic is flawed."));
            return Ok("Route B resolved correctly");
        }

        [EnableCors("*", "*", "*", "test-abc")]
        [HeaderBasedRoute("routeCD", "test-abc", "C")]
        [HeaderBasedRoute("routeCD", "test-abc", "D")]
        public IHttpActionResult Get_MultiRouteCD()
        {
            if (!Request.Headers.Contains("test-abc") || (Request.Headers.GetValues("test-abc").First() != "C" && Request.Headers.GetValues("test-abc").First() != "D"))
                return InternalServerError(new ApplicationException("Attribute logic is flawed."));
            return Ok("Multi Route C/D resolved correctly");
        }


        //wildcards


        [EnableCors("*", "*", "*", "test-abc")]
        [HeaderBasedRoute("routeE", "test-abc", "*")]
        public IHttpActionResult Get_WildcardRoute()
        {
            if (!Request.Headers.Contains("test-abc"))
                return InternalServerError(new ApplicationException("Attribute logic is flawed."));
            return Ok("Wild Card Route E resolved correctly");
        }

        //exclusion

        [EnableCors("*", "*", "*", "test-abc")]
        [HeaderBasedRoute("routeF", "test-abc", "!F")]
        public IHttpActionResult Get_ExclusiveRouteE()
        {
            if (!Request.Headers.Contains("test-abc") || (Request.Headers.GetValues("test-abc").First() == "F"))
                return InternalServerError(new ApplicationException("Attribute logic is flawed."));
            return Ok("Exclusive Route F resolved correctly");
        }


    }
}
