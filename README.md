# IdeaSoftware.Utils.WebApi.Routing [![NuGet Version](http://img.shields.io/nuget/v/IdeaSoftware.Utils.WebApi.Routing.svg?style=flat)](https://www.nuget.org/packages/IdeaSoftware.Utils.WebApi.Routing/)
Routing helpers for Web API

##Header Based Routing
Allows for Web Api 2 controllers routing based on headers. Compatible with CORS.

###Route Based on Custom Header Value
```C#
[HeaderBasedRoute("/api/myroute", "my-custom-header", "valueA")]
public IHttpActionResult Get()
{
    return Ok();
}
```

###Require Customer Header to be present with any value using wildcard
```C#
[HeaderBasedRoute("/api/myroute", "my-custom-header", "*")]
```

###Excluding request with based on header value with !
```C#
[HeaderBasedRoute("/api/myroute", "my-custom-header", "!valueB")]
```

###Working with CORS
```C#
[EnableCors("*", "*", "*", "my-custom-header")]
[HeaderBasedRoute("routeE", "my-custom-header", "*")]
```
