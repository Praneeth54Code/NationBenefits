# NationBenefits Demo Project

Product API Documentation
Overview
This API provides functionality to retrieve, paginate, and filter products. It supports server-side pagination and filtering by product code.
 
Endpoints
GET /api/products
Retrieve a paginated list of products, optionally filtered by product code.
Query Parameters
| Parameter      | Type   | Required | Description                                                                 | |----------------|--------|----------|-----------------------------------------------------------------------------| | pageNumber   | int  | No       | The page number to retrieve. Default is 1. Must be greater than 0.      | | pageSize     | int  | No       | The number of products per page. Default is 10. Must be greater than 0. | | productCode  | string | No       | Filter products by product code (partial or full match).                    |
Response
•	Status Code: 200 OK
•	Body:


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

	1. Setup Instructions
1.	Database Configuration:
•	Ensure the Products table exists with columns like Id, Name, Code, and Price.
•	Index the Code column for efficient filtering.
2.	Dependency Injection:
•	Register the ProductRepository in the DI container:

