# Domain Model

## Dinner

'''csahrp
	// TODO: Add methods
'''

'''json
{
	"id": { "value": "0000000-000-000-00000000000" },
    "name": "Yammy Dinner",
    "description": "Yammy Dinner Description",
    "startDateTime": "2020-01-01T00:00:00.0000000Z",
    "endDateTime": "2020-01-01T00:00:00.0000000Z",
    "startedDateTime": null,
    "endedDateTime": null,
    "status": "Upcomming", // Upcomming, InProgress, Started, Ended
    "isPublic": true,
    "maxGuests": 10,
    "price": {
        "amount": 10.99,
        "currency": "USD"
    },
	"hostId": { "value": "00000000-0000-0000-0000-000000000000" },
    "menuId": { "value": "00000000-0000-0000-0000-000000000000" },
    "imageUrl": "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png",
    "location": {
        "name": "Dan's Pizza Place",
        "address": "Berlin, Germany",
        "latitude": 52.520008,
        "longitude": 13.404954
    },
    "reservation": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "geustCount": 2,
            "reservationStatus": "Reserved", // Reserved, Cancelled, PendingGuestConfirmation
            "guestId": { "value": "00000000-0000-0000-0000-000000000000" },
            "dinnerId": { "value": "00000000-0000-0000-0000-000000000000" },
            "billId": { "value": "00000000-0000-0000-0000-000000000000" },
            "arrivalDateTime": null,
            "createdDateTime": "2020-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
        }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
'''