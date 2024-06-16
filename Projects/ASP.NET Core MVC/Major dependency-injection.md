# Major dependency-injection lifetimes (Singleton vs Scoped vs Transient)

To inject a service in a controller, you need to first register that service in the `Program.cs` file.

_DotNET Dependency Injection system has three major lifetimes._

-   _The first one is the Singleton lifetime_ and the Singleton Lifetime services are created once throughout the application, **single instance is created**. The singleton objects are the same for every object and every request.

-   _The second one is the scoped lifetime_. The scoped lifetime services are created **once per request within the scope**. The scoped objects are the same within a request, but different across different requests.

-   _The third and the last important one is the transient lifetime_ and the transient lifetime services are created **each time they are requested**. The transient objects are always different, and a new instance is provided to every controller and every service.
