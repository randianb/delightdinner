# Delight Dinner API

- [Delight Dinner API](#delight-dinner-api)
    - [Dinner](#dinner)
        - [Create Dinner](#create-dinner)
            - [Create Dinner Request](#create-dinner-request)
            - [Create Dinner Response](#dinner-response)
        - [Update Dinner](#update-dinner)
            - [Update Dinner Request](#update-dinner-request)
            - [Update Dinner Response](#update-dinner-response)
        - [Delete Dinner](#delete-dinner)
            - [Delete Dinner Request](#delete-dinner-request)
            - [Delete Dinner Response](#delete-dinner-response)
        - [Get Dinner](#get-dinner)
            - [Get Dinner Request](#get-dinner-request)
            - [Get Dinner Response](#get-dinner-response)
        - [List Dinner Guests](#list-dinner-guests)
            - [List Dinner Guests Request](#list-dinner-guests-request)
            - [List Dinner Guests Response](#list-dinner-guests-response)
        - [List Dinner Guests](#list-dinner-guests)
            - [List Dinner Guests Request](#list-dinner-guests-request)
            - [List Dinner Guests Response](#list-dinner-guests-response)    
        - [Start Dinner](#start-dinner)
            - [Start Dinner Request](#start-dinner-request)
            - [Start Dinner Response](#start-dinner-response)
        - [End Dinner](#end-dinner)
            - [End Dinner Request](#end-dinner-request)
            - [End Dinner Response](#end-dinner-response)
        - [Cancel Dinner](#cancel-dinner)
            - [Cancel Dinner Request](#cancel-dinner-request)
            - [Cancel Dinner Response](#cancel-dinner-response)

## Dinner

### Create Dinner

#### Create Dinner Request
```js
POST /host/{hostId}/dinners
POST me/dinners
```

```json
{
    "name": "Pizza & Pasta",
    "description": "Join us for a night of Pizza and Jazz! After dinner we will continue the fun at the BRB bar.",
    "startDateTime": "2018-01-01T00:00:00.000Z",
    "endDateTime": "2018-01-01T00:00:00.000Z",
    "isPublic": true,
    "maxGuests": 30,
    "price": {
        "amount": 29.99,
        "currency": "USD"
    },
    "menuId": "00000000-0000-0000-0000-000000000000",
    "imageUrl": "http://example.com/image.jpg",
    "location": {
        "name": "string",
        "address": "string",
        "latitude": 60.391262,
        "longitude": 5.322054
    }
}
```
#### Create Dinner Response
```js
201 Created
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Pizza & Pasta",
    "description": "Join us for a night of Pizza and Jazz! After dinner we will continue the fun at the BRB bar.",
    "startDateTime": "2018-01-01T00:00:00.000Z",
    "endDateTime": "2018-01-01T00:00:00.000Z",
    "startedDateTime": null,
    "endedDateTime": null,
    "status": "Upcomming", // Upcomming, InProgress, Ended
    "isPublic": true,
    "maxGuests": 30,
    "price": {
        "amount": 29.99,
        "currency": "USD"
    },
    "hostId": "00000000-0000-0000-0000-000000000000",
    "menuId": "00000000-0000-0000-0000-000000000000",
    "imageUrl": "http://example.com/image.jpg",
    "location": {
        "name": "string",
        "address": "string",
        "latitude": 60.391262,
        "longitude": 5.322054
    },
    "status": "Draft",
    "guests": [],
    "host": {
        "id": "00000000-0000-0000-0000-000000000000",
        "name": "string",
        "imageUrl": "string"
    },
    "createdDateTime": "2019-01-01T00:00:00.000Z",
    "updatedDateTime": "2019-01-01T00:00:00.000Z"
}
```

### Update Dinner

#### Update Dinner Request
```js
PUT /host/{hostId}/dinners/{dinnerId}
PUT me/dinners/{dinnerId}
```

```json
{
    "name": "Pizza & Pasta",
    "description": "Join us for a night of Pizza and Jazz! After dinner we will continue the fun at the BRB bar.",
    "startDateTime": "2018-01-01T00:00:00.000Z",
    "endDateTime": "2018-01-01T00:00:00.000Z",
    "maxGuests": 30,
    "menuId": "00000000-0000-0000-0000-000000000000",
    "imageUrl": "http://example.com/image.jpg"
}
```
#### Update Dinner Response
```js
204 Content
```

### Delete Dinner

#### Delete Dinner Request
```js
DELETE /host/{hostId}/dinners/{dinnerId}
DELETE me/dinners/{dinnerId}
```

#### Delete Dinner Response
```js
204 Content
```

### Get Dinner

#### Get Dinner Request
```js
GET /host/{hostId}/dinners/{dinnerId}
GET me/dinners/{dinnerId}
```

#### Get Dinner Response
```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Pizza & Pasta",
    "description": "Join us for a night of Pizza and Jazz! After dinner we will continue the fun at the BRB bar.",
    "startDateTime": "2018-01-01T00:00:00.000Z",
    "endDateTime": "2018-01-01T00:00:00.000Z",
    "startedDateTime": null,
    "endedDateTime": null,
    "status": "Upcomming", // Upcomming, InProgress, Ended
    "isPublic": true,
    "maxGuests": 30,
    "price": {
        "amount": 29.99,
        "currency": "USD"
    },
    "hostId": "00000000-0000-0000-0000-000000000000",
    "menuId": "00000000-0000-0000-0000-000000000000",
    "imageUrl": "http://example.com/image.jpg",
    "location": {
        "name": "string",
        "address": "string",
        "latitude": 60.391262,
        "longitude": 5.322054
    },
    "status": "Draft",
    "guests": [],
    "host": {
        "id": "00000000-0000-0000-0000-000000000000",
        "name": "string",
        "imageUrl": "string"
    },
    "createdDateTime": "2019-01-01T00:00:00.000Z",
    "updatedDateTime": "2019-01-01T00:00:00.000Z"
}
```
### List Dinner Guests

#### List Dinner Guests Request
```js
GET /host/{hostId}/dinners/{dinnerId}/guests
GET me/dinners/{dinnerId}/guests
```

#### List Dinner Guests Response
```json
[
    {
        "id": "00000000-0000-0000-0000-000000000000",
        "firstName": "John",
        "lastName": "Cayenne",
        "profileImageUrl": "http://example.com/image.jpg"
    }
]
```

### Start Dinner

#### Start Dinner Request
```js
GET /host/{hostId}/dinners/{dinnerId}/start
GET me/dinners/{dinnerId}/start
```

#### Start Dinner Response
```js
200 Ok
```

### End Dinner

#### End Dinner Request
```js
GET /host/{hostId}/dinners/{dinnerId}/end
GET me/dinners/{dinnerId}/end
```

### End Dinner Response
```js
200 Ok
```

### Cancel Dinner

#### Cancel Dinner Request
```js
GET /host/{hostId}/dinners/{dinnerId}/cancel
GET me/dinners/{dinnerId}/cancel
```

#### Cancel Dinner Response
```js
200 Ok
```