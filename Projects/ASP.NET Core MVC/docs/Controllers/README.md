# Application controllers overview

A C# class that is responsible for controlling the way that a user interacts with an MVC application. So we basically use controllers to handle the user requests.

**For example**: clicks on a button, there is a controller on the back-end which will receive the request and also return a response.

It is typical for MVC applications or web API applications to have controllers for each feature. Then inside the controllers you would have methods or as we call them in the _MVC actions_, which would be used for _different functionalities_ within in a _feature_.

-   **Features**:

    -   Management
        -   Movies
        -   Actors
        -   Producers
        -   Cinemas
        -   Account
    -   Shopping
        -   Shopping
        -   Order history

-   **Controllers**:
    -   ActorsController
    -   ProducersController
    -   CinemasController
    -   MoviesController
