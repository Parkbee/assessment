# ParkBee Developer Assessment

We'd like to thank you for taking the time to do our developer assessment. It consists of a [coding test](#coding-test) and [technical questions](#technical-questions).

## Completed assessment

For us to review your completed assessment, please put your answers to the technical questions in the [technical.md](technical.md) file and make sure that your completed coding test is in a single folder. Compress the folder to a zip file and place it on a shared Google Drive folder, DropBox folder, or similar and send the link to your recruiter or ParkBee employee who assigned you the test.

> Please provide us with details on how to run the projects. It **must** compile and run in one step.

## Coding test

ParkBee provides access to parking garages via API to our partners.

Your task is to create an API that can:

- start parking session in one of the garages
- stop running parking session
- get number of available spots in the garage

To help you get started, we've created a .NET Core Web API with some simple features:

- An in-memory database context with a DB set for Garages and Users.
- An custom authentication middleware that validates an API Key from `x-api-key` header.
- Swagger documentation to help you test the API.

### Additional information

- Each garage contains one or more door(s), doors could be of `Entry`, `Exit`, or `Pedestrian` type.
- To imitate door opening and hardware reachability check, send a ping to the door's IP address.

## Requirements

Please spend no more than 4 hours on the assessment. Try your best to meet the following requirements:

- Complete the user stories below and make sure that the code meets the acceptance criteria below.
- The code must compile and run in one step
- The solution should contain unit test project
- Do not include artifacts from your local builds, such as NuGet packages, obj and bin folders.

### Main requirements

Create API endpoints that allow integration partners to:

- start parking session in one of the garages
- stop running parking session
- get number of available spots in the garage

To start a parking session API should accept garage identifier and user information (identifier and license plate).
A single user should not be able to start multiple parking sessions at the same time.
User should not be able to start parking session if garage has no availability.
User should not be able to start parking session if garage hardware is not reachable.

## User stories

As an **integration partner**  
I want to **manage parking sessions of my users**  
So that **I can provide my users with parking at ParkBee locations**

### Acceptance criteria

**Scenario**: Starting a new parking session for a user

- **Given** user has no running parking session
- **And** garage has available spots
- **And** locaion hardware is reachable
- **When** Start parking session API endpoint is called
- **Then** Endpoint should return a successful response with parking session id
- **And** Entry door should open

**Scenario**: Starting a new parking session with no available spots in the garage

- **Given** garage has no parking spots available
- **When** Start parking session API endpoint is called
- **Then** Endpoint should return an error code
- **And** New parking session should not be created

**Scenario**: Starting a new parking session when Entry door hardware is not reachable

- **Given** Entry door hardware is not reachable
- **When** Start parking session API endpoint is called
- **Then** Endpoint should return an error code
- **And** New parking session should not be created

**Scenario**: Starting a new parking session for a user that already has a running parking session

- **Given** user has a running parking session in any garage
- **When** Start parking session API endpoint is called
- **Then** Endpoint should return an error code
- **And** New parking session should not be created

**Scenario**: Stopping running parking session

- **Given** parking session exists and is running
- **When** Stop parking session API endpoint is called
- **Then** Endpoint returns a success code
- **And** Parking session should be stopped
- **And** Exit door should open

As an **integration partner**  
I want to **know how many spots are available at the location**  
So that **I can inform my users about availablity**

### Acceptance criteria

**Scenario**: Getting availability for garage with running parking sessions

- **Given** garage X has running parking actions and Y total parking spots
- **When** garage availability API endpoint is called
- **Then** Endpoint should return a successful response with total number of unoccupied spots Z

### Personal choice

You can use any packages, frameworks, or libraries of your choice. You don't have to use Entity Framework or other dependencies from the current API.
You can:

- Refactor (or not) the existing code.
- Add (or don't add) comments, swagger documentation, logging, etc.
- Apply your code style.
- Fix (or don't) bugs if you spot them.

## Technical questions

Please put answers to the following questions in the [technical.md](technical.md) file before adding it to the final zip file:

1. How would you improve the API to make it production-ready (bug fixes, security, performance, etc.)?
2. How would you make the API idempotent?
3. How would you approach the API authentication?
4. What type of storage would you use for this service in production?
5. How would you deploy this API to production? Which infrastructure would you need for that (databases, messaging, etc)?
6. How would you optimize the API endpoints to guarantee low latency under the high load?

We thank you for your time in completing this assessment. If you have questions or comments, please forward them to the person who assigned you the assessment.
