# GuestBook-APIs
This is API for Guestbook implemented with .net 6

In order to run the project first use need to run a Microsoft SQL Server get the connection string and change the exsisting connection string from appsettings.json

There are 6 Endpoints
1. POST: register (for signup)
2. POST: login (for login)
3. POST: send (for sending a message)
4. PUT: update (update message)
5. DELETE: delete (delete message)
6. POST: post (reply message)

Needed to be done next:
1. Complete JWT Configurations.
2. Check for identity of the issuer of update and delete messages.
3. Check that email is unique in SignUp
4. Complete More Scenarios for Unit Tests.
5. Make a docker-compose for both database and backend.

