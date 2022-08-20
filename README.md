# Periodic REST API documentation
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
   <Signed JSON Web Token>
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
