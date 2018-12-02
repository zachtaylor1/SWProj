This is the Final Submission of Group 4s Software Engineering Project. It is a Student Housing System.
This program has two key components, an SQL Server 2012 Database, and a c# interface.
A 'filler' program is also provided to clear and refill the database with different values.

To generate the database, a sample script, "script.sql" is provided. Running this query will create the database, and fill it with data
The c# code is entirely provided
 LOG IN PAGE
Use 'admin' and 'adminpass' as the username and password to enter the system as a generic admin.
Use 'Stacy1' and 'stacy' to enter the username as a student.
These values will only work with the sql script provided. If the 'filler' program is executer, the student value will change.
The Log In page, on a successful log in, will result in the transfer to the page 'Admin Home' or 'Student Home' depending on the username and password.
 Student Home
There are more default students than rooms so if no room data appears, that student has not been assigned a room.
The tabs visible are locked to students, and admin options are disabled.
 The tabs available are : Request Temp Key, Apply For RA, Apply For Residence, View Messages
 Admin Home
all options are available, the admin only options are View Key Requests, Search Rooms, Search Students, Review RA Applications, View Audit,///// and Assign Roomates./////
 View Messages: This screen shows all messages sent from one user to another, allows acknowledging them, and sending messages
Search Rooms: This screen can search for rooms, and view their data
Search Students: This screen searches for students, and displays their information
Review RA Applications: This screen can confirm or deny RA Applications
Apply For RA: This screen can allow students to apply to become an RA
Apply For Residence: This screen allows students to apply for a room on residence
View Key Requests: This screen confirms or denies request for a temporary key. RA and Admin users only
View Audit: This screen shows the full transaction/audits of the system
Request Temp Key: This screen allows students to request a temporary key.
Assign Roomates: This screen allows the Admins to run the student assignment program
 BIG OLE DEPENDANCIES
1. Ensure SQL SERVER 2012 database is installed (may work on other versions)
2. Run the 'script.sql' to generate the database
3. Download the c# code and corresponding xaml code, create a solution.
4. Edit connection string in 'Server.cs' so you can connect. An error will occur if the connection string is left unchanged

 FUNCTIONALITIES
This Student Housing System allows for the following functions:
1. Assigning Applicants to rooms, and pairing roommates
2. View and track Room information, including the furniture inside of it, and moving furniture from room to room,
3. View students on residence and their information.
4. A transaction/audit system
5. Blacklisting and viewing blacklisted students
6. Tracking the temporary keys and allowing for their assignments
7. A Message system for users to message each other for arbitrary items

Note: the main project is contained in the SWProjv1 folder. The other relevant files are in Everything Else. Disregard the other files.
