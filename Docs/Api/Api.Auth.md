# Delight Dinner API

- [Delight Dinner API](#delight-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

#### Register Request

```js
POST /auth/register
```

```json
{
    "firstName": "Emma",
    "lastName": "Watson",
    "email": "emmawatson@gmail.com",
    "password": "Emma1234!"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Emma",
  "lastName": "Watson",
  "email": "emmawatson@gmail.com",
  "token": "eyJhb..hbbQ"
}
```

### Login

#### Login Request

```js
POST /auth/login
```

```json
{
    "email": "emmawatson@gmail.com",
    "password": "Emma1234!"
}
```

```js
200 OK
```

#### Login Response

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Emma",
  "lastName": "Watson",
  "email": "emmawatson@gmail.com",
  "token": "eyJhb..hbbQ"
}
```