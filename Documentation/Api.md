# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response-_200-ok_)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response-_200-ok_)

## Auth

### Register

```http request
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Amichai",
  "lastName":  "Mantinband",
  "email":     "amichai@mantinband.com",
  "password":  "Amiko1232!"
}
```

#### Register Response _(200 OK)_

```json
{
  "id":        "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Amichai",
  "lastName":  "Mantinband",
  "email":     "amichai@mantinband.com",
  "token":     "eyJhb..z9dqcnXoY"
}
```

### Login

```http request
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email":    "amichai@mantinband.com",
  "password": "Amiko1232!"
}
```

#### Login Response _(200 OK)_

```json
{
  "id":        "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Amichai",
  "lastName":  "Mantinband",
  "email":     "amichai@mantinband.com",
  "token":     "eyJhb..hbbQ"
}
```
