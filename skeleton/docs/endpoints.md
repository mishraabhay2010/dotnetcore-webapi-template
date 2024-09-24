# API Endpoints

## POST /Players
- **Summary**: Creates a Player
- **Request Body**: 
  - **Description**: Player
  - **Content**: `application/json`
  - **Schema**: [Player](#player-schema)
- **Responses**:
  - **201**: Created
  - **400**: Bad Request
  - **409**: Conflict

## GET /Players
- **Summary**: Retrieves all players
- **Responses**:
  - **200**: OK
  - **404**: Not Found

## GET /Players/{id}
- **Summary**: Retrieves a Player by its Id
- **Parameters**:
  - **id**: Player.Id (integer, required)
- **Responses**:
  - **200**: OK
  - **404**: Not Found

## PUT /Players/{id}
- **Summary**: Updates (entirely) a Player by its Id
- **Parameters**:
  - **id**: Player.Id (integer, required)
- **Request Body**:
  - **Description**: Player
  - **Content**: `application/json`
  - **Schema**: [Player](#player-schema)
- **Responses**:
  - **204**: No Content
  - **400**: Bad Request
  - **404**: Not Found

## DELETE /Players/{id}
- **Summary**: Deletes a Player by its Id
- **Parameters**:
  - **id**: Player.Id (integer, required)
- **Responses**:
  - **204**: No Content
  - **404**: Not Found

## GET /Players/squadNumber/{squadNumber}
- **Summary**: Retrieves a Player by its Squad Number
- **Parameters**:
  - **squadNumber**: Player.SquadNumber (integer, required)
- **Responses**:
  - **200**: OK
  - **404**: Not Found

## Schemas

### Player Schema
- **id**: integer, int64
- **firstName**: string, minLength: 1
- **middleName**: string, nullable: true
- **lastName**: string, minLength: 1
- **dateOfBirth**: string, format: date-time, nullable: true
- **squadNumber**: integer, int32
- **position**: string, minLength: 1
- **abbrPosition**: string, minLength: 1
- **team**: string, nullable: true
- **league**: string, nullable: true
- **starting11**: boolean

### ProblemDetails Schema
- **type**: string, nullable: true
- **title**: string, nullable: true
- **status**: integer, int32, nullable: true
- **detail**: string, nullable: true
- **instance**: string, nullable: true
