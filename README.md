# NationBenefits Demo Project

Product API Documentation
Overview


This API provides functionality to retrieve, paginate, and filter products. It supports server-side pagination and filtering by product code.
 
Endpoints
GET /api/GetAllProductsWithPagination
Retrieve a paginated list of products, optionally filtered by product code.
Query Parameters:
int pageNumber=1, int pageSize=10, string? productCode = ABC
|                                                               | |----------------|--------|----------|-----------------------------------------------------------------------------| | pageNumber   | int  | No       | The page number to retrieve. Default is 1. Must be greater than 0.      | | pageSize     | int  | No       | The number of products per page. Default is 10. Must be greater than 0. | | productCode  | string | No       | Filter products by product code (partial or full match).                    |
Response
•	Status Code: 200 OK - Success
• %00 - Internal Error

Features
1.	Pagination: Supports pageNumber and pageSize for efficient data retrieval.
2.	Filtering: Allows filtering products by productCode (partial or full match).
3.	Metadata: Provides total items, total pages, current page, and page size in the response.
 
Setup Instructions
1.	Database Configuration:
•	Ensure the Products table exists with columns like Id, Name, Code, and Price.
•	Index the Code column for efficient filtering.
2.	Dependency Injection:
•	Register the ProductRepository in the DI container:

	
	3.	Run the Application:
•	Use Visual Studio to start the API and test endpoints using tools like Postman or Swagger.
		
. Logging Documentation
	Logging is implemented in this project to track application behavior, errors, and performance. It helps in debugging, monitoring, 
	and auditing the system. The logging mechanism uses a decorator pattern to wrap the repository and log operations.

	#Logging Decorator
The LoggingDecorator class is used to log actions performed by the ProductRepository. It implements the same interface (IProductRepository) as the repository and delegates calls to the actual repository while logging relevant information.
Key Features
1.	Logs method calls (e.g., GetPaginatedProductsAsync, GetTotalCountAsync).
2.	Logs input parameters and results.
3.	Logs exceptions for error tracking.


Log Levels
The following log levels are used:
1.	Information:
•	Logs successful method calls and their results.
•	Example: "Calling GetTotalCountAsync...", "GetTotalCountAsync returned 100".
2.	Error:
•	Logs exceptions with stack traces.
•	Example: "Error occurred in GetPaginatedProductsAsync".
	
Best Practices
1.	Log Context:
•	Include relevant details like method parameters and results.
2.	Avoid Sensitive Data:
•	Do not log sensitive information (e.g., passwords, PII).
3.	Monitor Logs:
•	Use tools like ELK Stack, Azure Monitor, or Splunk for log aggregation and analysis.



1.	Dockerfile:
•	Builds your .NET application using the .NET SDK image.
•	Publishes the application and runs it using the .NET runtime image.
2.	Docker Compose:
•	Defines three services: app, db, and redis.
•	app:
•	Builds the application using the Dockerfile.
•	Connects to PostgreSQL (db) and Redis (redis) using environment variables.
•	db:
•	Uses the official PostgreSQL 13 image.
•	Sets up the database with a username, password, and database name.
•	Persists data using a named volume (postgres_data).
•	redis:
•	Uses the official Redis image.
•	Exposes port 6379 for caching.
3.	Environment Variables:
•	ConnectionStrings__DefaultConnection: Configures the connection string for PostgreSQL.
•	Redis__ConnectionString: Configures the Redis connection string.