# TheraBase

This is an ASP.NET Core MVC project that simulates a mental-health-care-provider database.  The web interface allows the user to view a list of therapists pulled from the database.  Clicking on an individual provider brings up a list of details, such as specialty area, and options for the user to change provider information, set an appointment with the provider (using the Calendly API), etc.  A new provider can be added from the main menu; this is linked to the database.  A photo can be uploaded for the new provider, which is saved in the ~/images/ directory; the path is recorded in the database.  

I generated the database in MySQL and used Dapper to create the object model; the controller logic is written in C#; and the Razor view pages include working with HTML, CSS, and JavaScript.
