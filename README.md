# Periodic REST API

This API serves as backend for Periodic application that tracks your net-worth based on your income, posted transactions and scheduled transactions.

### Cloud, Security:

* Cloud native - used `ForwardedHeaders Middleware` so appliction can scale behind an Application Load Balancer.
* Database connection string, JWT Signing Key are fetched from `AWS Secrets Manager`, JWT SigningKey is rotated every 30 days. Secrets Manager triggers an `AWS Lambda function` every 30 days that generates a random string as new SigningKey. Same for AWS RDS credentials.
* HTTPS termination at load balancer. Communication between LoadBalancer and Client is always encrypted.
* Every end-point except for api/auth/login and api/auth/signup are secured using `Authentication` and `Authorization` middleware.

### Data Access and Persistence Layer:

* `EntityFrameworkCore` code-first approach.
* `Dependency Injection` that makes it easier to switch from RDS to Local Repo for ease of testing.
* Repository Pattern keeps Controllers lean and simple.


# API Documentation
> :warning: under construction

All responses come in standard JSON. All requests must include a `content-type` of `application/json` and the body must be valid JSON.

## Response Codes 
### Response Codes
```
200: Success
400: Bad request
401: Unauthorized
404: Cannot be found
405: Method not allowed
50X: Server Error
```

## Login
**You send:**  Your  login credentials.
**You get:** A `JSON Web Token` with wich you can make further requests.

**Request:**
```json
POST api/auth/login
Accept: application/json
Content-Type: application/json

{
    "userName": "foo",
    "password": "1234567" 
}
```
**Successful Response:**
```json
200 OK
Server: My RESTful API
Content-Type: application/json
Content-Length: xy

{
   "userName": "foo",
   "token": "dfkhdkg.fgkjsdhg.ghfgdjgf"
}

```
**Failed Response:**
```json
401 Unauthorized
Server: My RESTful API
Content-Type: application/json

{
  "invalid crendetials"
}
``` 
