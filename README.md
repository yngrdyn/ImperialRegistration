 README 
 ------
 
 Development Environment 
 -----------------------
 Visual Studio 2015
 IIS >= 7.5, IIS Express
 SQL Server >= 2014
 Framework .NET vs 4.5.2
 
 
 Functionalities 
 ---------------

There are 2 user types:
1. User Admin : Has access to this functionalities 
	*  Login and Logout
		- To log in use the following credentials:
			* Username: admin
			* Password: admin
	*  Species List	
	*  Roles 
		- Role Details and Users list with that role
		- Add user to a selected Role
		- Create Role
		- Edit Role
		- Delete Role
	*  Users
		- List of Users
		- Create User
		- Edit User
		- Delete User
		- User Details
	*  Admin Dashboard : This is a list with all the users that registered on the system and need to approve status to Rebel or Imperial Citizen 	
2. Free User that only can Register on the Imperial Registration


Tree Ways to register a User
In Summary we have 3 ways to register a user: From home, From Users, From Roles adding a user to a specific role


Rebels Register

If anybody introduce a name with "skywalker" substring call a remote webservice/webapi that register to a file the identified Tatooine and a datetime.
You can see the file on ImperialRegistration_API\App_Data\Rebel_log\rebels.txt
On client site if "skywalker" is introduced as name,  a cookie is set and the UI interface id bloqued for any change.

A distributed service that can be called from any location over the universe, allows to send a list of strings
with the name of the rebeld and name of the planet, and response true is register goes fine. The regiter has to be done to file with a datetime with the string
"rebeld (name) on (planet) at (datetime)"



 Imperial Register Solution Architecture
 ---------------------------------------
 
 +++++Project 1  ImperialRegister - MVC 5+++++
 
 This is the main project with this structure:
	-  App_Data folder : contains application data files
	-  App_Start folder: contains class files which will be executed when the application starts. 
		 % BundleConfig.cs : To handle js and css files like bundles and not separate files
		 % FilterConfig.cs:  For filter creation
		 % RouteConfig.cs :  Global Routing Configuration
	- Content folder: contains the static files  bootstrap.css, bootstrap.min.css and Site.css with the custom styles for the ImperialRegister.
	- Controllers folder: contains class files for the controllers. Controllers handles users' request and returns a response
	     % HomeController.cs    : handles homepage actions
		 % SpeciesController.cs : handles species actions like the index with the species list
		 % RolesController.cs   : handles roles actions like the index , create, edit, delete, etc actions
		 % UsersController.cs   : handles users actions like the index , create, edit, delete, etc actions
		 % UserAdminController.cs : handles admin actions like login , logout, AdminDashboard
		 % ErrorPageController.cs : handles exceptions Errors, showing an error page
	- Fonts folder :contains custom font files for the application.
	- Models folder: contains the model file using ADO and entity framework to access to the database
	- Scripts folder: contains all the JavaScript files.
	- Views folder: Contains html files for the application.Includes separate folder for each controllers. 
				    Shared folder under View folder contains all the views which will be shared among different controllers like the layout file.
	- Web.config file contains application level configurations
	- NLog.config : Contains the log files configuration , and the Nloger config also (C:Logs/)
	- Security file : Contains the configuration of the authorization Filter that have each controller actions that only the user admin can access.
 
 
 +++++ Project 2  ImperialRegister_API - WFC Api +++++
 
 This is the WFC project for the Imperial Register API Webservices , contains the 
 contracts and implementation of the web services.
 Is separated in 3 tiers : The business tier (Logic Library), The Data tier (Data Library) and the Service Tier
 
 
 +++++ Project 3  UnitTest - Unit Testing +++++
 
 This project contains some Unit test for the Imperial Register
 
 
 +++++ Project 4  Logic +++++
 
 Library with all the business logic of the Services
 
 
 +++++ Project 5  Data +++++
 Library to Manage Files with the Rebel informationt that is registered through the WFC Web Service
 
 
 
 Log and Exception Configuration
 --------------------------------
 For each action there is an exception implemented and handle.
 For each exception there is a instruction to write the error on the project log.
 For eache project on the solution  a log file is created on the C:Logs/ Directory
 
 
 Front End Libraries used
 ------------------------

 * Bootstrap 
 * Jquery
 * jquery.BlockUI


 To Unblock UI
 ----------------
 Browser console
 document.cookie = 'ImperialRegister_rebel=; expires=Thu, 01 Jan 1970 00:00:01 GMT;'
 F5
 
 How to Run the project
 -------------------------
1. First Make Sure that you have installed all the Development Environment.
2. Open Visual Studio .
3. Open the ImperialRegister project solution .
4. Make sure that the project database is attached to the project
5. Make sure that all the projects are included in the Solution (ImperialRegister_API, Logic, Data, UnitTest)
6. Select the Solution Propierties and Allow Multiple startup projects(Select ImperialRegister and ImperialRegister_API) (Link: https://msdn.microsoft.com/en-us/library/jj919165.aspx)
7. Run the project 
8. Go to the browser and explore
9. To check the file with the list of rebels you can go to the Rebel_Log/rebels.txt file



 Developer:
 Yngrid Coello 
 yngrdyn@gmail.com
 May 2017