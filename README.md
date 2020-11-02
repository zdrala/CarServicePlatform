# Application for car services 

This is platform for car service businessess. Every owner is able to register his car service on this platform. Users can search all registered car services and send a request for servicing in any car service. After sending a request, administrator of car service will check request, if everything is ok, he will make a schedule for service. During active schedule of servicing, administrator send a offer with categories of car parts what is needed to be replaced/changed. User will select car part for every category which is needed to be replaced. At the end, when admin mark this schedule as finished, user can rate finished services with positive or negative rate.



This project contains 3 interconnected applications:

REST API C# ASP.NET Core application,
Windows forms application,
Xamarin mobile application.

Docker will be used to deliver the application.
# API launching
1. Clone repository
2. Install docker
3. Within the folder where the project is located, enter the following commands on the CMD:

   docker-compose build
   
   docker-compose up
