# ParkBee Developer Assessment

We'd like to thank you for taking the time to do our developer assessment. It consists of a [coding test](#coding-test) and [technical questions](#technical-questions).

## Completed assessment

For us to review your completed assessment, please put your answers to the technical questions in the [technical.md](technical.md) file and make sure that your completed coding test is in a single folder. Compress the folder to a zip file and place it on a shared Google Drive folder, DropBox folder, or similar and send the link to your recruiter or ParkBee employee who assigned you the test.

> Please provide us with details on how to run the projects. It **must** compile and run in one step.

## Coding test

ParkBee provides access to parking locations via API to our partners.

Your task is to create an API that can start and stop parking sessions and allows the consumer to get parking session details by id.

To help you get started, we've created a .NET Core Web API with some simple features:

- An in-memory database context with a DB set for Garages and Users.
- An custom authentication middleware that validates an API Key from `x-api-key` header.
- Swagger documentation to help you test the API.

### Additional information

- Each garage contains one or more door(s), doors could be of `Entry`, `Exit`, or `Pedestrian` type.
- To imitate door opening and hardware reachability check, send a ping to the door's IP address.

### Personal choice

You can use any packages, frameworks, or libraries of your choice. You don't have to use Entity Framework or other dependencies from the current API.
You can:

- Refactor (or not) the existing code.
- Add (or don't add) comments, swagger documentation, logging, etc.
- Apply your code style.
- Fix (or don't) bugs if you spot them.

## Requirements

Please spend no more than 4 hours on the assessment. Try your best to meet the following requirements:

- Complete the user story below and make sure that the code meets the acceptance criteria below.
- **The code must compile and run in one step.**
- **You must include tests for the API.**
- Do not include artifacts from your local builds, such as NuGet packages and bin folders.

## User story

As an **integration partner**  
I want to **manage parking sessions of my users**  
So that **I can provide my users with parking at ParkBee locations**

### Acceptance criteria

**Scenario**: Starting a new parking session for a user that has no other running parking sessions

- **Given** user has no running parking session
- **When** Start parking session API endpoint is called
- **Then** Endpoint should return a successful response with parking session id
- **And** Entry door should open

**Scenario**: Starting a new parking session when Entry door hardware is not reachable

- **Given** user has no running parking session **And** Entry door hardware is not reachable
- **When** Start parking session API endpoint is called
- **Then** Endpoint should return an error code
- **And** New parking session should not be created

**Scenario**: Starting a new parking session for a user that already has a running parking session

- **Given** user has a running parking session in any location
- **When** Start parking session API endpoint is called
- **Then** Endpoint should return an error code
- **And** New parking session should not be created

**Scenario**: Stopping running parking session

- **Given** parking session exists and is running
- **When** Stop parking session API endpoint is called
- **Then** Endpoint returns a success code
- **And** Parking session should be stopped
- **And** Exit door should open

**Scenario**: Stopping parking session that was already stopped

- **Given** parking session exists and is stopped
- **When** Stop parking session API endpoint is called
- **Then** Endpoint returns a success code
- **And** Exit door should not be open

### Additional requirements

- To start a parking session API should accept garage identifier and user information (identifier and license plate).
- To stop a parking session API should accept a parking session identifier.
- A single user should not be able to start multiple parking sessions at the same time.

## Technical questions

Please put answers to the following questions in the [technical.md](technical.md) file before adding it to the final zip file:

1. How would you improve the API to make it production-ready (bug fixes, security, performance, etc.)?
2. How would you make the API idempotent?
3. How would you approach the API authentication?
4. What type of storage would you use for this service in production?
5. How would you deploy this API to production? Which infrastructure would you need for that (databases, messaging, etc)?
6. How would you optimize the API endpoints to guarantee low latency under the high load?

We thank you for your time in completing this assessment. If you have questions or comments, please forward them to the person who assigned you the assessment.
