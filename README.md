# ASP.NET CORE WEB API

This is the implementation of Accommodation Reservation System.

## Layers
Solution has 3 separate layers: API, Logic, Data.

### API layer
Path: api/accommodation

Allows insertion of new accommodation, retrieval of all accommodations, update of a specific accommodation by id, and delete of a specific accommodation by id through HttpPost, HttpGet, HttpPut and HttpDelete operations.

### Logic layer
Connects API layer (controller) with Data layer (context) with different methods depending on Http request.
- Implemented methods:
  - AddAccommodation
  - GetAccommodations
  - UpdateAccommodationById
  - DeleteAccommodationById

### Data layer

Tables:
  - Accommodations
    - Id
    - Title
    - Subtitle
    - Description
    - Type
    - Categorization
    - PersonCount
    - ImageUrl
    - FreeCancelation
    - Price
