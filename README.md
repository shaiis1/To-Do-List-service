This project contains To-Do List service in ASP.NET Core with connection to MSSQL.

This project is a server side for a project that contains a simple api requests to get Tasks list by id, and the project contains the following main things:
1. Working with .NET CORE.
2. Working with Entity Framework.

To build api request, please follow the examples:

1. Get All Tasks:
url - your localhost + '/Tasks/getTasks' - Post request.

2. Delete Task:
url - your localhost + '/Tasks/deleteTask?id={taskId}' taskId = your task id (for example: 3) - Get request.

2. Update Task:
url - your localhost + '/Tasks/updateTask?id={taskId}' taskId = your task id (for example: 3) - Get request.

2. Add Task:
url - your localhost + '/Tasks/addTask' - Post request.
please Create a json object in your request's body with the property 'Name'.
please make sure that the 'Name' property isn't an empty string.
*all other properties will fill automtaically on the server side.
