# ASP.NET CORE WEB API

This is the backend implementation of Accommodation Reservation System in a form of RESTful API.

## Layers
Solution has 3 separate layers: API, Logic, Data.

### API layer
Path: 
  - api/accommodation
  - api/location
  - api/reservation

Allows: 
  - insertion of a new accommodation
  - retrieval of all accommodations
  - update of a specific accommodation by id
  - delete of a specific accommodation by id
  - adding image to a specific accommodation by id
  - retrieval of accommodation recommendations
  - retrieval of all accommodations for a specific location by id
  - insertion of a new location
  - retrieval of all locations
  - update of a specific location by id
  - delete of a specific location by id
  - insertion of a new reservation
  - retrieval of all reservations
  - update of a specific reservation by id
  - delete of a specific reservation by id

### Logic layer
Connects API layer (controller) with Data layer (context) with different methods depending on Http request.

Services:
  - AccommodationsService:
    - Implemented methods:
      - AddAccommodationWithLocation
      - GetAccommodations
      - UpdateAccommodationById
      - AddImageForAccommodation
      - DeleteAccommodationById
      - GetAccommodationRecommendations
      - GetAccommodationsOfALocation
  - LocationsService:
    - Implemented methods:
      - AddLocation
      - GetAllLocations
      - UpdateLocationById
      - DeleteLocationById
  - ReservationsService:
    - Implemented methods:
      - AddReservationForAccommodation
      - GetAllReservations
      - UpdateReservationById
      - DeleteReservationById

### Data layer

Tables:
  - Accommodations
    - Id (PK)
    - Title
    - Subtitle
    - Description
    - Type
    - Categorization
    - PersonCount
    - ImageTitle
    - ImageData
    - FreeCancelation
    - Price
    - LocationId (FK->Locations.Id)
  - Locations
    - Id (PK)
    - ImageUrl
    - PostalCode
    - Name
  - Reservations
    - Id (PK)
    - Email
    - CheckIn
    - CheckOut
    - PersonCount
    - Confirmed
    - AccommodationId (FK->Accommodations.Id)
