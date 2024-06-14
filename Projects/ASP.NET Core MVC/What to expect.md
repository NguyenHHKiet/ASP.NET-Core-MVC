# WHAT TO EXPECT?

-   **What is MVC?**

    -   A `Model` is just _a C# class_ that represents a table in the SQL Server. So it basically serves as a _data blueprint_ and can also be used to define the _data relations_.
    -   A `view`, as the name already indicates, is what the user gets to see. So it is a file that represents the _user interface_, and an MVC view is a _CSHTML file_ where CS stands for C sharp and HTML for the HTML code. You can trigger the request or the events that get handled by the controllers.
    -   A `Controller` will _receive the events_, then we'll prepare a response and then just _return the response to the view_. A controller is just a c sharp class that inherits from the controller base class.

-   **DbContext file**

    -   The `Dbcontext` file is also known as the translator file because it serves as a _translator between your models and the database_.

    So let us say you have a `model`, and then on the other side you have the `database`. And then we have said that we use the model to send data to the database or get data from the database. But for the database, which in this case is going to be an SQL database to understand the C-sharp code and vice versa, you need to have a file in between. And that is going to be the `Dbcontext` file, which understands both _C-sharp_ and _SQL_.

-   **CRUD data using EFCore**
-   **Services**
-   **ViewComponents**
-   **Authentication and Authorization**
-   **PayPal SDK for online payments**
-   **Dependency Injection**
-   **Model binding**
-   **Routing**
-   **Model validation**
-   **Tag helpers**
