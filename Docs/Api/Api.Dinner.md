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
        - [List Dinners](#list-dinners)
            - [List Dinners Request](#list-dinners-request)
            - [List Dinners Response](#list-dinners-response)
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
    "name": "string",
    "description": "string",
    "startDateTime": "2018-01-01T00:00:00.000Z",
    "endDateTime": "2018-01-01T00:00:00.000Z",
    "isPublic": true,
    "maxGuests": 10,
    "price": {
        "amount": 10.99,
        "currency": "USD"
    },
    "menuId": "00000000-0000-0000-0000-000000000000",
    "imageUrl": "http://example.com/image.jpg",
    "location": {
        "name": "string",
        "address": "string",
        "latitude": 0,
        "longitude": 0
    }
}
```
#### Create Dinner Response