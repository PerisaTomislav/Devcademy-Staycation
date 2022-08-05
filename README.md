# ASP.NET CORE WEB API

This is the implementation of Accommodation Reservation System.

## Layers
Solution has 3 separate layers: API, Logic, Data.

### API layer
Path: 
  - api/accommodation
  - api/location

Allows insertion of new accommodation and location, retrieval of all accommodations, update of a specific accommodation by id, and delete of a specific accommodation by id through HttpPost, HttpGet, HttpPut and HttpDelete operations.

### Logic layer
Connects API layer (controller) with Data layer (context) with different methods depending on Http request.

Services:
  - AccommodationsService:
    - Implemented methods:
      - AddAccommodationWithLocation
      - GetAccommodations
      - UpdateAccommodationById
      - DeleteAccommodationById
  - LocationsService:
    - Implemented methods:
      - AddLocation

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
    - ImageUrl
    - FreeCancelation
    - Price
    - LocationId (FK->Locations.Id)
  - Locations
    - Id (PK)
    - Name
    - PostalCode
