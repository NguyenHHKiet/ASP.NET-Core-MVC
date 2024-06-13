# Model-View-Controller

**MVC** stands for _Model View Controller_. It is a design pattern that is employed to separate the business logic, presentation logic, and data. Basically, it provides a pattern to style web application. As per MVC, you can divide the application into 3 Layers as follows:

1. **Model Layer**: The Model component corresponds to all or any of the data-related logic that the user works with. This will represent either the info that’s being transferred between the View and Controller components or the other business logic-related data. For instance, a Customer object will retrieve the customer information from the database, manipulate it, and update its data back to the database or use it to render data.

2. **View Layer**: The View component is employed for all the UI logic of the appliance. For instance, the Customer view will include all the UI components like text boxes, dropdowns, etc. that the ultimate user interacts with.

3. **Controller**: Controllers act as an interface between Model and consider components to process all the business logic and incoming requests, manipulate data using the Model component, and interact with the Views to render the ultimate output. For instance, the Customer controller will handle all the interactions and inputs from the Customer View and update the database using the Customer Model. An equivalent controller won’t be going to view the Customer data.

**ASP.NET** is a server-side web application framework created by Microsoft that runs on Windows and was started in the early 2000s. **ASP.NET** allows developers to make web applications, web services, and dynamic content-driven websites.
