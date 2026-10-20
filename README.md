# User Management API

## Project Overview

User Management API is an ASP.NET Core Web API developed for TechHive Solutions. The API allows administrators to manage user records through CRUD operations.

## Features

- Retrieve all users
- Retrieve a user by ID
- Create a new user
- Update an existing user
- Delete a user
- Input validation
- Error handling
- Request/response logging
- Token-based authentication

## Validation

The API validates user input before processing requests.

Validation includes:

- First name cannot be empty
- Last name cannot be empty
- Email cannot be empty
- Email must be in a valid format
- Duplicate emails are not allowed

## Middleware

### Logging Middleware

Logs:

- HTTP Method
- Request Path
- Response Status Code

### Error Handling Middleware

- Catches unhandled exceptions
- Returns consistent JSON error responses

Example:

```json
{
  "error": "Internal server error."
}
```

### Authentication Middleware

- Validates incoming tokens
- Returns 401 Unauthorized for invalid or missing tokens

## Testing

The API was tested using:

- HTTP file requests
- Browser testing
- Manual endpoint verification

Tested scenarios:

- Valid requests
- Invalid email formats
- Missing required fields
- Non-existent user IDs
- Invalid authentication tokens

## Microsoft Copilot Contributions

Microsoft Copilot assisted with:

- Generating CRUD endpoint scaffolding
- Debugging routing and localhost issues
- Adding input validation
- Improving error handling
- Generating middleware implementations
- Suggesting API best practices

## Technologies Used

- ASP.NET Core Web API
- C#
- .NET
- Microsoft Copilot
- GitHub

## Author

Created as part of the Back-End Development with .NET course project.
