# CalendarManagement
 
 Calendar Management is a small application to see Appointments based on different months.
 
 Download the source code. This code contains two projects
1) **Calendar.UI**: This is the frontend site made in Angular language.
2) **Calendar.Management**: This project is created in Asp.Net Core Web API.
   
 ## Installation

Download the repository. Open the visual studio code and navigate to the code location(where you have to download the code).
There you will see two folders. Open the "Calendar.UI" folder in the visual studio code. Open the terminal window and run following commands.

 ```
   npm install
 ```
 ```
   ng serve --port 4200
 ```
 
 This will install the npm package in the project and host the application at 4200 port.
 You can access the site using the following URL:
 ```
 http://localhost:4200
 ```
Open the Visual Studio 2019 or visual studio code and navigate to the code location(where you have to download the code).
This time open the "Calendar.Management" folder. This is the backend code written in c#. Run the solution.

You can access the Rest API using the following URL:
```
http://localhost:5000
```

**NOTE**: The URL to Web API is configured in the environment.ts file in the angular application.
